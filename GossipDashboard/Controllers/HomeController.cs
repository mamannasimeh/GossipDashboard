using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GossipDashboard.Models;
using System.IO;
using System.Text;
using GossipDashboard.Helper;
using GossipDashboard.Repository;
using System.Timers;
using System.Text.RegularExpressions;
using GossipDashboard.ViewModel;

namespace GossipDashboard.Controllers
{
    public class HomeController : Controller
    {
        private HtmlNode result;
        private LogRepository repoLog = new Repository.LogRepository();
        private LogErrorRepository repoErrorLog = new Repository.LogErrorRepository();

        public HomeController()
        {
            //Timer aTimer = new Timer();
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //aTimer.Interval = 60000;
            //aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            CreateIndex();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateIndex()
        {
            string path = "";
            path = ControllerContext.HttpContext.Server.MapPath("~");
            PostManagement postManagement = new PostManagement(path);

            PostRepository repo = new PostRepository();

            //ایجاد پست ها
            repo.CreatePost();

            //ایجاد صفحه اصلی
            CreateIndexPage(path, postManagement);

            //ایجاد صفحه کتگوری ها
            PostController postCtr = new PostController();
            postCtr.CreateAllCategory(path);

            return View("Index");
        }

        List<VM_Post> postNewOrder = new List<VM_Post>();
        List<VM_Post> postNewOrder1 = new List<VM_Post>();
        List<string> listSourceSiteName = new List<string>();
        private void CreatePostNewOrder(List<VM_Post> posts, int index, int i, int postDistinctCount)
        {
            if (posts.Count == index + 1)
                return;

            if (!postNewOrder.Contains(posts[index]))
            {
                postNewOrder.Add(posts[index]);
                i += 1;
            }

            if (i == postDistinctCount)
            {
                postNewOrder1.AddRange(postNewOrder);

                postNewOrder = new List<VM_Post>();
                i = 0;
            }

            index += 1;
            CreatePostNewOrder(posts, index, i, postDistinctCount);
        }

        //ایجاد صفحه اصلی
        private void CreateIndexPage(string path, PostManagement postManagement)
        {
            var repo = new PostRepository();
            var docIndex = new HtmlDocument();
            /////////////////////////////create bloglist/////////////////////////////
            //وسط صفحه 
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-author-grid
                postManagement.ClearContentNode(nodesIndex, "author-grid");

                //ایجاد  تگ آرتیکل به ازای هر پست
                int i = 0; List<string> duplicateImage = new List<string>();
                var posts = repo.SelectPostUser().OrderByDescending(p => p.PostID).Take(200).ToList();
                ////var postsShuffle = posts.OrderBy(p => Guid.NewGuid());

                List<VM_Post> postNewOrder = new List<VM_Post>();
                List<string> listSourceSiteName = new List<string>();
                var postDistinct = posts.Select(p => p.SourceSiteName).Distinct().ToList();
                int isContinue = 0;
                foreach (var item in posts)
                {
                    if (listSourceSiteName.Count == postDistinct.Count)
                        isContinue = 0;

                    if (listSourceSiteName.Contains(item.SourceSiteName) && isContinue != 0)
                        continue;

                    postNewOrder.Add(item);

                    listSourceSiteName.Add(item.SourceSiteName);
                    isContinue += 1;
                }


                foreach (var item in posts)
                {
                    //برای قسمت اصلی داشتن  تصویر مهم است
                    //if ((item.Image1_1 != null || item.ScriptAparat != null) && i < 30)
                    if (item.Image1_1 != null && i < 30)
                    {
                        //در صفحه اصلی عکس تکراری نداشته باشیم
                        if (duplicateImage.FirstOrDefault(x => x == item.Image1_1) == null)
                        {
                            item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                            //ايجاد محتوا براي وسط صفحه-- author-grid
                            var itSelfNode = postManagement.CreateBloglist(item);
                            if (itSelfNode != null)
                            {
                                result = postManagement.AddHeadToContentDiv(nodesIndex, "author-grid", itSelfNode);
                            }

                            i += 1;
                            duplicateImage.Add(item.Image1_1);
                        }
                    }

                    ////برای قسمت اصلی داشتن  تصویر مهم است
                    //if (item.ScriptAparat != null)
                    //{
                    //    //در صفحه اصلی عکس تکراری نداشته باشیم
                    //    if (duplicateImage.FirstOrDefault(x => x == item.Image1_1) == null)
                    //    {
                    //        item.JalaliModifyDate = item.ModifyDate.ToPersianDateTime();

                    //        //ايجاد محتوا براي وسط صفحه-- author-grid
                    //        var itSelfNode = postManagement.CreateBloglist(item);
                    //        if (itSelfNode != null)
                    //        {
                    //            result = postManagement.AddHeadToContentDiv(nodesIndex, "author-grid", itSelfNode);
                    //        }

                    //        i += 1;
                    //        duplicateImage.Add(item.Image1_1);
                    //    }
                    //}
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
                    PostName = "Create Main Page",
                    PostID = -100
                });

            }

            //////////////////////Create catlist///////////////////////////////////////
            //دیگر رويدادها
            try
            {
                var startDaysAgo = DateTime.Now.AddDays(-10);
                var endDaysAgo = DateTime.Now.AddDays(-5);
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-catlist
                postManagement.ClearContentNode(nodesIndex, "tab-content");

                //ایجاد  محتواي تب هاي کت ليست
                var posts = repo.SelectPostUser().Where(p => p.ModifyDate >= startDaysAgo && p.ModifyDate <= endDaysAgo).OrderByDescending(p => p.PostID).Take(50).ToList();
                foreach (var item in posts)
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
                    PostName = "Create Main Page",
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
                var posts = repo.SelectPostUser().OrderBy(x => x.CommentCount).Take(10).ToList();
                foreach (var item in posts)
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
                    PostName = "Create Main Page",
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
                var posts = repo.SelectPostUser().Take(5).ToList();
                foreach (var item in posts)
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
                    PostName = "Create Main Page",
                    PostID = -100
                });
            }

            //اسلایدر پایینی
            //////////////////////Create postslider-container slider-image-bottom///////////////////////////////////////
            var startDateSliderButtom = DateTime.Now.AddDays(-4);
            var endDateSliderButtom = DateTime.Now.AddDays(-2);
            var postSliderButton = repo.SelectPostUser().Where(p => p.ModifyDate >= startDateSliderButtom && p.ModifyDate <= endDateSliderButtom && p.Image1_1 != null).OrderByDescending(p => p.LikePost).Take(6).ToList();
            try
            {
                var someDaysAgo = DateTime.Now.AddDays(-5);
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-slider-image-bottom
                postManagement.ClearContentNode(nodesIndex, "sp-slides sp-slider-image");

                //ایجاد  محتواي slider-image-bottom
                foreach (var item in postSliderButton)
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
                    PostName = "Create Main Page",
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
                foreach (var item in postSliderButton)
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
                    PostName = "Create Main Page",
                    PostID = -100
                });
            }


            //اسلایدر بالایی
            ////////////////////////sp-slides sp-slider-image-top///////////////////////////////////////
            var someDaysAgoSliderTop = DateTime.Now.AddDays(-5);
            var postSliderTop = repo.SelectPostUser().Where(p => p.ModifyDate >= someDaysAgoSliderTop && p.ModifyDate < DateTime.Now && p.Image1_1 != null).OrderByDescending(p => p.Views).Take(6).ToList();
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند
                postManagement.ClearContentNode(nodesIndex, "sp-slides sp-slider-image-top");

                //ایجاد  محتوا
                foreach (var item in postSliderTop)
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
                    PostName = "Create Main Page",
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
                foreach (var item in postSliderTop)
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
                    PostName = "Create Main Page",
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
                var posts = repo.SelectPostUser().Where(p => p.ModifyDate > someDaysAgo).OrderByDescending(p => p.Views).Take(5).ToList();
                foreach (var item in posts)
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
                    PostName = "Create Main Page",
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
                var posts = repo.SelectPostUser().Where(p => p.ModifyDate > someDaysAgo).OrderByDescending(x => x.LikePost).Take(5).ToList();
                foreach (var item in posts)
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
                    PostName = "Create Main Page",
                    PostID = -100
                });
            }

            ////////////////////////// آخرين پست ها///////////////////////////////////////
            try
            {
                docIndex.Load(path + "/Views/Shared/_Layout.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//ul");

                //حذف محتويات ند
                postManagement.ClearContentNode(nodesIndex, "superior-posts recent_posts_wid");

                //ایجاد  محتوا
                int rowID = 1;
                var posts = repo.SelectPostUser().OrderByDescending(x => x.PostID).Take(6).ToList();
                foreach (var item in posts)
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
                    PostName = "Create Main Page",
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
