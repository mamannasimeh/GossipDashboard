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

namespace GossipDashboard.Controllers
{
    public class HomeController : Controller
    {
        private HtmlNode result;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateIndex()
        {
            string path = "";
            path = ControllerContext.HttpContext.Server.MapPath("~");
            PostManagement postManagement = new PostManagement(path);

            /////////////////////////////create bloglist/////////////////////////////
            var docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
            var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

            //حذف محتويات ند بلاك-author-grid
            postManagement.ClearContentNode(nodesIndex, "author-grid");

            //ایجاد  تگ آرتیکل به ازای هر پست
            var repo = new PostRepository();
            var postQuiz = repo.SelectPostUser().ToList();
            foreach (var item in postQuiz)
            {
                //ايجاد محتوا براي وسط صفحه-- author-grid 
                var itSelfNode = postManagement.CreateBloglist(item);
                if (itSelfNode != null)
                {
                    result = postManagement.AddHeadToContent(nodesIndex, "author-grid", itSelfNode);
                }
            }

            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {

            }

            //////////////////////Create catlist///////////////////////////////////////
             docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
             nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

            //حذف محتويات ند بلاك-catlist
            postManagement.ClearContentNode(nodesIndex, "catlist");

            //ایجاد هد برای کت لیست
            //به دست آوردن طبقه بندی ها از دیتا بیس
            Repository.PubBaseRepository repoPubBase = new Repository.PubBaseRepository();
            var cats = repoPubBase.SelectByParentName("PostCategory").ToList();
            var itSelfHead =  postManagement.CreateCatListHeading(cats);
            if (itSelfHead != null)
            {
                result = postManagement.AddHeadToContent(nodesIndex, "author-grid", itSelfHead);
            }

            //ایجاد  تگ آرتیکل به ازای هر پست
            repo = new PostRepository();
            postQuiz = repo.SelectPostUser().ToList();
            foreach (var item in postQuiz)
            {
                //ايجاد محتوا براي قسمت طبقه بندی-- catlist 
                var itSelfNode = postManagement.CreateBloglist(item);
                if (itSelfNode != null)
                {
                    result = postManagement.AddHeadToContent(nodesIndex, "author-grid", itSelfNode);
                }
            }

            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {

            }


            return View("Index");
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