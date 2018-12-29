using GossipDashboard.Helper;
using GossipDashboard.Repository;
using GossipDashboard.ViewModel;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GossipDashboard.Controllers
{
    public class AnimalController : Controller
    {
        private PostRepository repo = new PostRepository();
        private HtmlNode result;
        private LogErrorRepository repoErrorLog = new Repository.LogErrorRepository();

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult CreateAnimalMenu(string path)
        {
            PostManagement postManagement = new PostManagement(path);

            List<VM_Post> listAll = new List<VM_Post>();
            var docIndex = new HtmlDocument();

            try
            {
                docIndex.Load(path + "/Views/Animal/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-catlist
                postManagement.ClearContentNode(nodesIndex, "bloglist default");

                //ایجاد  محتواي bloglist default
                var posts = repo.SelectPostUser().Where(p => p.SourceSiteUrl.Contains("motamem") || p.SourceSiteUrl.Contains("yjc") || p.SourceSiteUrl.Contains("alef")).Take(150).ToList();
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
                htmlDoc.Save(path + "/Views/Animal/Index.cshtml", Encoding.UTF8);

                return Json( true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //repoErrorLog.Add(new VM_LogError()
                //{
                //    ErrorDescription = ex.ToString(),
                //    IP = Request.UserHostAddress,
                //    ModifyDateTime = DateTime.Now,
                //    PostName = "Create Main Page - PlaceInMainPage.BloglistDefault",
                //    PostID = -100
                //});

                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}