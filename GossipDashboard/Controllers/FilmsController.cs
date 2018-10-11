using GossipDashboard.Helper;
using GossipDashboard.Models;
using GossipDashboard.Repository;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GossipDashboard.Controllers
{
    public class FilmsController : Controller
    {
        PostRepository repo = new PostRepository();
        private HtmlNode result;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post(int postID)
        {
            var res = repo.SelectPostUser().Where(p => p.PostID == postID).FirstOrDefault();
            return View("~/Views/Post/Index.cshtml", res);
        }

        public ActionResult CreateContentCategory()
        {
            string path = "";
            path = ControllerContext.HttpContext.Server.MapPath("~");
            PostManagement postManagement = new PostManagement(path);

            var docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Films/Index.cshtml", Encoding.UTF8);
            var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

            //حذف محتويات ند بلاك-author-grid
            postManagement.ClearContentNode(nodesIndex, "author-grid");

            //ایجاد  تگ آرتیکل به ازای هر پست
            var repo = new PostRepository();
            var postQuiz = repo.SelectPostByCategory("films").ToList();
            foreach (var item in postQuiz)
            {
                //ايجاد محتوا براي وسط صفحه-- author-grid 
                var itSelfNode = postManagement.CreateHead(item);
                if (itSelfNode != null)
                {
                    result = postManagement.AddHeadToContent(nodesIndex, "author-grid", itSelfNode);
                }
            }

            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Films/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {

            }


            return View("Index");
        }
    }
}