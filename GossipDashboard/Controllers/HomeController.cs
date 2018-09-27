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

namespace GossipDashboard.Controllers
{
    public class HomeController : Controller
    {
        GossipSiteEntities context = new GossipSiteEntities();
        private HtmlNode result;
        string path = "";

        public ActionResult Index()
        {
            //string path = ControllerContext.HttpContext.Server.MapPath("~/Templates/category-quiz.html");
            path = ControllerContext.HttpContext.Server.MapPath("~");
            PostManagement postManagement = new PostManagement(path);

            var docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
            var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

            //حذف محتويات ند بلاك-author-grid
            postManagement.ClearContentNode(nodesIndex, "author-grid");

            //ایجاد  تگ آرتیکل به ازای هر پست
            var postQuiz = context.Posts.ToList();
            foreach (var item in postQuiz)
            {
                //ايجاد محتوا براي وسط صفحه-- author-grid 
                var itSelfNode = postManagement.CreateHead(item, "/Templates/category-quiz.html");
                if (itSelfNode != null)
                {
                    result = postManagement.AddHeadToContent(nodesIndex, "author-grid", itSelfNode);
                }
            }

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(result.OuterHtml);
            htmlDoc.Save("Mountain1.html", Encoding.UTF8);

            return View();
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