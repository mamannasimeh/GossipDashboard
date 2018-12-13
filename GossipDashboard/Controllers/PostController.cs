using GossipDashboard.Helper;
using GossipDashboard.Models;
using GossipDashboard.Repository;
using GossipDashboard.ViewModel;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Web;
using System.Web.Mvc;

namespace GossipDashboard.Controllers
{
    public class PostController : Controller
    {
        private HtmlNode result;
        private LogRepository repoLog = new Repository.LogRepository();
        private LogErrorRepository repoErrorLog = new Repository.LogErrorRepository();
        private PostRepository repo = new PostRepository();
        private ManagementPostRepository repoManagementPost = new ManagementPostRepository();
        private UserRepository repoUser = new UserRepository();

        public PostController()
        {
            //Timer aTimer = new Timer();
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //aTimer.Interval = 60000;
            //aTimer.Enabled = true;
        }

 
        public ActionResult Index()
        {
            return View(new VM_Post());
        }

        public ActionResult CreateAllCategory(string path)
        {
            //string path = ControllerContext.HttpContext.Server.MapPath("~");
            BizarreController bizarre = new BizarreController(path);
            bizarre.CreateContentCategory(path);

            AmazingController amazing = new AmazingController(path);
            amazing.CreateContentCategory(path);

            CuteController cute = new CuteController(path);
            cute.CreateContentCategory(path);

            EntertainmentController entertainment = new EntertainmentController(path);
            entertainment.CreateContentCategory(path);

            FilmsController films = new FilmsController(path);
            films.CreateContentCategory(path);

            PlacesController places = new PlacesController(path);
            places.CreateContentCategory(path);

            QuizController quiz = new QuizController(path);
            quiz.CreateContentCategory(path);

            SexyController sexy = new SexyController(path);
            sexy.CreateContentCategory(path);

            return View("/Home/Index");
        }


        public ActionResult ShowImage(int id)
        {
            var post = repoUser.Select(id);
            if (post == null || post.Image == null)
                return null;
            return File(post.Image, "image/jpg");
        }

        [Authorize]
        [HttpPost]
        public ActionResult SaveImage(HttpPostedFileBase UploadFile)
        {
            if (UploadFile != null)
            {

                byte[] fileContect = new byte[UploadFile.InputStream.Length];
                UploadFile.InputStream.Read(fileContect, 0, fileContect.Length);

                var user = new User
                {
                    FirstName = "ارسلان",
                    AboutUser = "يکي از نويسنده هاي نامدار ايران",
                    Image = fileContect,
                    LastName = "آرماني",
                    ModifyDate = DateTime.Now,
                    ModifyUserID = 1,
                    Password = "123",
                    Salt = "123",
                    UserName = "admin",
                };

                repoUser.Add(user);
                return Json("OK");
            }


            return Json("Fails");
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            CreateIndex();
        }

        public ActionResult CreateIndex()
        {
            string path = "";
            path = ControllerContext.HttpContext.Server.MapPath("~");
            PostManagement postManagement = new PostManagement(path);

            //ایجاد پست ها
            repo.CreatePost();

            //ایجاد صفحه اصلی
            CreateIndexPage(path, postManagement);

            //ایجاد صفحه کتگوری ها
            PostController postCtr = new PostController();
            postCtr.CreateAllCategory(path);

            return View("Index");
        }

        //ایجاد صفحه اصلی
        private void CreateIndexPage(string path, PostManagement postManagement)
        {
            List<VM_Post> listAll = new List<VM_Post>();
            var docIndex = new HtmlDocument();
            /////////////////////////////create bloglist/////////////////////////////
            //وسط صفحه 
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-author-grid
                postManagement.ClearContentNode(nodesIndex, "author-grid");

                ///// در هر گروه بر اساس نام سایت، بالاترین مقادیر را یکی یکی خارج می کند و لیست جدید می سازد
                //پست نوع استاتوس  و لینک را در داخل متد سورت گروپ ليست مقدار دهي مي کنيم
                var posts = repo.SelectPostUser().Where(p => p.PostFormat.FirstOrDefault().NameEn != "status"
                        && p.PostFormat.FirstOrDefault().NameEn != "link" && p.PostFormat.FirstOrDefault().NameEn != "video"
                        && p.PostFormat.FirstOrDefault().NameEn != "audio").OrderByDescending(p => p.PostID).Take(200).ToList();
                listAll = Utilty.SortGroupsList(posts, PlaceInMainPage.MiddleIndex);

                //ایجاد  تگ آرتیکل به ازای هر پست
                int i = 0; List<string> duplicateImage = new List<string>();
                foreach (var item in listAll)
                {
                    // برای قسمت اصلی داشتن  تصویر مهم است یا پست آپارات باشد یا استاتوس باشد يا ويديو یا صوتی 
                    // 30 پست ایجاد گردد --------  i < 30
                    if ((item.Image1_1 != null && i < 30) || (item.ScriptAparat != null && i < 30) || (item.Status != null && i < 30)
                        || (item.UrlVideo != null && i < 30) || (item.UrlMP3 != null && i < 30))
                    {
                        //در صفحه اصلی عکس تکراری نداشته باشیم
                        if (duplicateImage.FirstOrDefault(x => x == item.Image1_1) == null)
                        {
                            item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                            //ايجاد محتوا براي وسط صفحه-- author-grid
                            var itSelfNode = postManagement.CreateBloglist(item, "CreateIndexPage", i);
                            if (itSelfNode != null)
                            {
                                result = postManagement.AddHeadToContentDiv(nodesIndex, "author-grid", itSelfNode);

                                //این قسمت مرحله ای است که پابلیش هر پست نهایی می شود
                                // یک عدد به فیلد پابلیش کانت آنها اضافه کنیم
                                repoManagementPost.UpdatePublishCount(item.PostID);
                            }

                            i += 1;
                            duplicateImage.Add(item.Image1_1);
                        }
                    }
                }

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                repoErrorLog.Add(new VM_LogError()
                {
                    ErrorDescription = ex.ToString(),
                    IP = Request.UserHostAddress,
                    ModifyDateTime = DateTime.Now,
                    PostName = "Create Main Page - PlaceInMainPage.MiddleIndex",
                    PostID = -100
                });

            }

            //////////////////////Create catlist///////////////////////////////////////
            //آخرین رويدادها
            try
            {
                var startDaysAgo = DateTime.Now.AddDays(-10);
                var endDaysAgo = DateTime.Now.AddDays(-5);
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-catlist
                postManagement.ClearContentNode(nodesIndex, "tab-content");

                //ایجاد  محتواي تب هاي کت ليست
                var posts = repo.SelectPostUser().Where(p => p.ModifyDate >= startDaysAgo && p.ModifyDate <= endDaysAgo && p.Status == null).OrderByDescending(p => p.PostID).Take(50).ToList();
                listAll = Utilty.SortGroupsList(posts, PlaceInMainPage.LastEvent);
                foreach (var item in listAll)
                {
                    item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                    //ايجاد محتوا براي قسمت طبقه بندی-- catlist
                    var itSelfNode = postManagement.CreateCatListContent(item);
                    if (itSelfNode != null)
                    {
                        result = postManagement.AddHeadToContentDiv(nodesIndex, "tab-content", itSelfNode);
                    }
                }


                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                repoErrorLog.Add(new VM_LogError()
                {
                    ErrorDescription = ex.ToString(),
                    IP = Request.UserHostAddress,
                    ModifyDateTime = DateTime.Now,
                    PostName = "Create Main Page - PlaceInMainPage.LastEvent",
                    PostID = -100
                });
            }

            //////////////////////Create bloglist-content///////////////////////////////////////
            //مطالب جالب
            //قسمت کتگوری لیست که ترانسپرنت است
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-catlist
                postManagement.ClearContentNode(nodesIndex, "row bloglist-content");

                //ایجاد  محتواي تب هاي کت ليست
                var posts = repo.SelectPostUser().Where(p => p.Status == null).OrderBy(x => x.CommentCount).Take(12).ToList();
                listAll = Utilty.SortGroupsList(posts, PlaceInMainPage.InterestingStuff);
                foreach (var item in listAll)
                {
                    item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                    //ايجاد محتوا براي قسمت طبقه بندی-- catlist
                    var itSelfNode = postManagement.CreateBloglistContent(item);
                    if (itSelfNode != null)
                    {
                        result = postManagement.AddHeadToContentDiv(nodesIndex, "row bloglist-content", itSelfNode);
                    }
                }


                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                repoErrorLog.Add(new VM_LogError()
                {
                    ErrorDescription = ex.ToString(),
                    IP = Request.UserHostAddress,
                    ModifyDateTime = DateTime.Now,
                    PostName = "Create Main Page - PlaceInMainPage.InterestingStuff",
                    PostID = -100
                });
            }

            //////////////////////Create bloglist-default///////////////////////////////////////
            // قسمتی که عکس در سمت راست و توضیجات در سمت راست دارد-- زیر مطالب جالب
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-catlist
                postManagement.ClearContentNode(nodesIndex, "bloglist default");

                //ایجاد  محتواي bloglist default
                var posts = repo.SelectPostUser().Where(p => p.Status == null).Take(5).ToList();
                listAll = Utilty.SortGroupsList(posts, PlaceInMainPage.BloglistDefault);
                foreach (var item in listAll)
                {
                    item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                    //ايجاد محتوا براي -- bloglist default
                    var itSelfNode = postManagement.CreateBloglistDefault(item);
                    if (itSelfNode != null)
                    {
                        result = postManagement.AddHeadToContentDiv(nodesIndex, "bloglist default", itSelfNode);
                    }
                }


                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                repoErrorLog.Add(new VM_LogError()
                {
                    ErrorDescription = ex.ToString(),
                    IP = Request.UserHostAddress,
                    ModifyDateTime = DateTime.Now,
                    PostName = "Create Main Page - PlaceInMainPage.BloglistDefault",
                    PostID = -100
                });
            }

            //اسلایدر پایینی
            //////////////////////Create postslider-container slider-image-bottom///////////////////////////////////////
            var startDateSliderButtom = DateTime.Now.AddDays(-4);
            var endDateSliderButtom = DateTime.Now.AddDays(-2);
            var postSliderButton = repo.SelectPostUser().Where(p => p.ModifyDate >= startDateSliderButtom && p.ModifyDate <= endDateSliderButtom && p.Image1_1 != null && p.Status == null).OrderByDescending(p => p.LikePost).Take(6).ToList();
            listAll = Utilty.SortGroupsList(postSliderButton, PlaceInMainPage.SliderBottom);
            try
            {
                var someDaysAgo = DateTime.Now.AddDays(-5);
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-slider-image-bottom
                postManagement.ClearContentNode(nodesIndex, "sp-slides sp-slider-image");

                //ایجاد  محتواي slider-image-bottom
                foreach (var item in listAll)
                {
                    //اسلایدر بالا حتما عکس داشته باشد
                    if (item.Image1_1.Trim() == "")
                        continue;

                    item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                    //ايجاد محتوا براي -- bloglist default
                    var itSelfNode = postManagement.CreateSliderImageBottom(item);
                    if (itSelfNode != null)
                    {
                        result = postManagement.AddHeadToContentDiv(nodesIndex, "sp-slides sp-slider-image", itSelfNode);
                    }
                }


                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                repoErrorLog.Add(new VM_LogError()
                {
                    ErrorDescription = ex.ToString(),
                    IP = Request.UserHostAddress,
                    ModifyDateTime = DateTime.Now,
                    PostName = "Create Main Page - PlaceInMainPage.SliderBottom",
                    PostID = -100
                });
            }

            //عکس های زیر اسلایدر پایینی 
            //////////////////////Create postslider-container slider-image-bottom sp-thumbnails sp-slider-image///////////////////////////////////////
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-slider-image-bottom
                postManagement.ClearContentNode(nodesIndex, "sp-thumbnails sp-slider-image");

                //ایجاد  محتواي slider-image-bottom
                foreach (var item in listAll)
                {
                    //اسلایدر بالا حتما عکس داشته باشد
                    if (item.Image1_1.Trim() == "")
                        continue;

                    item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                    //ايجاد محتوا براي -- bloglist default
                    var itSelfNode = postManagement.CreateSliderImageBottom_ImageBottom(item);
                    if (itSelfNode != null)
                    {
                        result = postManagement.AddHeadToContentDiv(nodesIndex, "sp-thumbnails sp-slider-image", itSelfNode);
                    }
                }


                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                repoErrorLog.Add(new VM_LogError()
                {
                    ErrorDescription = ex.ToString(),
                    IP = Request.UserHostAddress,
                    ModifyDateTime = DateTime.Now,
                    PostName = "Create Main Page - PlaceInMainPage.SliderBottom - Picture",
                    PostID = -100
                });
            }


            //اسلایدر بالایی
            ////////////////////////sp-slides sp-slider-image-top///////////////////////////////////////
            var someDaysAgoSliderTop = DateTime.Now.AddDays(-5);
            var postSliderTop = repo.SelectPostUser().Where(p => p.ModifyDate >= someDaysAgoSliderTop && p.ModifyDate < DateTime.Now && p.Image1_1 != null && p.Status == null).OrderByDescending(p => p.Views).Take(6).ToList();
            listAll = Utilty.SortGroupsList(postSliderTop, PlaceInMainPage.SliderTop);
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند
                postManagement.ClearContentNode(nodesIndex, "sp-slides sp-slider-image-top");

                //ایجاد  محتوا
                foreach (var item in listAll)
                {
                    //اسلایدر بالا حتما عکس داشته باشد
                    if (item.Image1_1.Trim() == "")
                        continue;

                    item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                    //ايجاد محتوا براي
                    var itSelfNode = postManagement.CreateSliderTop(item);
                    if (itSelfNode != null)
                    {
                        postManagement.AddHeadToContent(nodesIndex, "sp-slides sp-slider-image-top", itSelfNode);
                    }
                }


                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(docIndex.DocumentNode.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                repoErrorLog.Add(new VM_LogError()
                {
                    ErrorDescription = ex.ToString(),
                    IP = Request.UserHostAddress,
                    ModifyDateTime = DateTime.Now,
                    PostName = "Create Main Page - PlaceInMainPage.SliderTop",
                    PostID = -100
                });
            }

            //عکس های سمت چپ اسلایدر بالایی
            ////////////////////////sp-thumbnails sp-slider-image-top///////////////////////////////////////
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند
                postManagement.ClearContentNode(nodesIndex, "sp-thumbnails sp-slider-image-top");

                //ایجاد  محتوا
                foreach (var item in listAll)
                {
                    //اسلایدر بالا حتما عکس داشته باشد
                    if (item.Image1_1.Trim() == "")
                        continue;

                    item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                    //ايجاد محتوا براي
                    var itSelfNode = postManagement.CreateSliderTopThumbnails(item);
                    if (itSelfNode != null)
                    {
                        postManagement.AddHeadToContent(nodesIndex, "sp-thumbnails sp-slider-image-top", itSelfNode);
                    }
                }


                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(docIndex.DocumentNode.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                repoErrorLog.Add(new VM_LogError()
                {
                    ErrorDescription = ex.ToString(),
                    IP = Request.UserHostAddress,
                    ModifyDateTime = DateTime.Now,
                    PostName = "Create Main Page - PlaceInMainPage.SliderTop - Picture",
                    PostID = -100
                });
            }



            ////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////// sidebar-widget mostviewed///////////////////////////////////////
            //بیشترین بازدید
            try
            {
                var someDaysAgo = DateTime.Now.AddDays(-5);
                docIndex.Load(path + "/Views/Shared/_Layout.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//ul");

                ////حذف محتويات ند بلاك-slider-image-bottom
                postManagement.ClearContentNode(nodesIndex, "recent_posts_wid right-slider1");

                ////ایجاد  محتوا
                int rowID = 1;
                var posts = repo.SelectPostUser().Where(p => p.ModifyDate > someDaysAgo && p.Status == null).OrderByDescending(p => p.Views).Take(5).ToList();
                listAll = Utilty.SortGroupsList(posts, PlaceInMainPage.Mostviewed);
                foreach (var item in listAll)
                {
                    item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                    //ايجاد محتوا براي
                    var itSelfNode = postManagement.CreatePostMostViewed(item, rowID);
                    if (itSelfNode != null)
                    {
                        postManagement.AddHeadToContent(nodesIndex, "recent_posts_wid right-slider1", itSelfNode);
                    }
                    rowID++;
                }


                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(docIndex.DocumentNode.OuterHtml);
                htmlDoc.Save(path + "/Views/Shared/_Layout.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                repoErrorLog.Add(new VM_LogError()
                {
                    ErrorDescription = ex.ToString(),
                    IP = Request.UserHostAddress,
                    ModifyDateTime = DateTime.Now,
                    PostName = "Create Main Page - PlaceInMainPage.Mostviewed",
                    PostID = -100
                });
            }

            //////////////////////// sidebar-widget popular///////////////////////////////////////
            //محبوب
            try
            {
                var someDaysAgo = DateTime.Now.AddDays(-8);
                docIndex.Load(path + "/Views/Shared/_Layout.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//ul");

                //حذف محتويات ند بلاك-slider-image-bottom
                postManagement.ClearContentNode(nodesIndex, "recent_posts_wid right-slider2");

                //ایجاد  محتوا
                int rowID = 1;
                var posts = repo.SelectPostUser().Where(p => p.ModifyDate > someDaysAgo && p.Status == null).OrderByDescending(x => x.LikePost).Take(5).ToList();
                listAll = Utilty.SortGroupsList(posts, PlaceInMainPage.Popular);
                foreach (var item in listAll)
                {
                    item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                    //ايجاد محتوا براي
                    var itSelfNode = postManagement.CreatePostPopular(item, rowID);
                    if (itSelfNode != null)
                    {
                        postManagement.AddHeadToContent(nodesIndex, "recent_posts_wid right-slider2", itSelfNode);
                    }
                    rowID++;
                }


                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(docIndex.DocumentNode.OuterHtml);
                htmlDoc.Save(path + "/Views/Shared/_Layout.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                repoErrorLog.Add(new VM_LogError()
                {
                    ErrorDescription = ex.ToString(),
                    IP = Request.UserHostAddress,
                    ModifyDateTime = DateTime.Now,
                    PostName = "Create Main Page - PlaceInMainPage.Popular",
                    PostID = -100
                });
            }

            ////////////////////////// آخرين خبرها///////////////////////////////////////
            try
            {
                docIndex.Load(path + "/Views/Shared/_Layout.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//ul");

                //حذف محتويات ند
                postManagement.ClearContentNode(nodesIndex, "superior-posts recent_posts_wid");

                //ایجاد  محتوا
                int rowID = 1;
                var posts = repo.SelectPostUser().Where(p => p.Status == null).OrderByDescending(x => x.PostID).Take(6).ToList();
                listAll = Utilty.SortGroupsList(posts, PlaceInMainPage.LaseNews);
                foreach (var item in listAll)
                {
                    item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                    //ايجاد محتوا براي
                    var itSelfNode = postManagement.CreatePostSuperiorr(item, rowID);
                    if (itSelfNode != null)
                    {
                        postManagement.AddHeadToContent(nodesIndex, "superior-posts recent_posts_wid", itSelfNode);
                    }
                    rowID++;
                }


                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(docIndex.DocumentNode.OuterHtml);
                htmlDoc.Save(path + "/Views/Shared/_Layout.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                repoErrorLog.Add(new VM_LogError()
                {
                    ErrorDescription = ex.ToString(),
                    IP = Request.UserHostAddress,
                    ModifyDateTime = DateTime.Now,
                    PostName = "Create Main Page - PlaceInMainPage.LaseNews",
                    PostID = -100
                });
            }


            //ایجاد لاگ به ازای هر بار انجام فرایندهای مربوط به ایجاد صفحه اصلی
            repoLog.Add(new VM_Log()
            {
                IP = Request.UserHostAddress,
                ModifyDateTime = DateTime.Now,
                PostName = "Create Main Page",
                PostID = -100,
                LogTypeID_fk = 59,
            });
        }
    }
}