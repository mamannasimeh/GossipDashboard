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
    public class BizarreController : Controller
    {
        PostRepository repo = new PostRepository();
        private HtmlNode result;
        private string path;

        public BizarreController()
        {

        }

        public BizarreController(string path)
        {
            this.path = path;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post(int postID)
        {
            repo.UpdatePostViews(postID);

            var res = repo.SelectPostUser().Where(p => p.PostID == postID).FirstOrDefault();
            if (res != null)
                res.JalaliModifyDate = res.ModifyDate.ToPersianDateTime();
            return View("~/Views/Post/Index.cshtml", res);
        }

        public ActionResult VideoPost(int postID)
        {
            repo.UpdatePostViews(postID);

            var res = repo.SelectPostUser().Where(p => p.PostID == postID).FirstOrDefault();
            if (res != null)
                res.JalaliModifyDate = res.ModifyDate.ToPersianDateTime();
            return View("~/Views/Post/VideoIndex.cshtml", res);
        }

        public ActionResult AudioPost(int postID)
        {
            repo.UpdatePostViews(postID);

            var res = repo.SelectPostUser().Where(p => p.PostID == postID).FirstOrDefault();
            if (res != null)
                res.JalaliModifyDate = res.ModifyDate.ToPersianDateTime();
            return View("~/Views/Post/AudioIndex.cshtml", res);
        }

        public ActionResult CreateContentCategory(string path)
        {
            //path = ControllerContext.HttpContext.Server.MapPath("~");
            PostManagement postManagement = new PostManagement(path);

            var docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Bizarre/Index.cshtml", Encoding.UTF8);
            var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

            //حذف محتويات ند بلاك-author-grid
            postManagement.ClearContentNode(nodesIndex, "author-grid");

            //ایجاد  تگ آرتیکل به ازای هر پست
            var repo = new PostRepository();
            var postQuiz = repo.SelectPostByCategory("bizarre").ToList();
            foreach (var item in postQuiz)
            {
                //ايجاد محتوا براي وسط صفحه-- author-grid 
                var itSelfNode = postManagement.CreateBloglist(item);
                if (itSelfNode != null)
                {
                    result = postManagement.AddHeadToContentDiv(nodesIndex, "author-grid", itSelfNode);
                }
            }


            try
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Bizarre/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception)
            {

            }


            return View("Index");
        }
    }
}
