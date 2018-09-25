using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GossipDashboard.Models;
using System.IO;
using System.Text;

namespace GossipDashboard.Controllers
{
    public class HomeController : Controller
    {
        GossipSiteEntities context = new GossipSiteEntities();

        public ActionResult Index()
        {
            //string path = ControllerContext.HttpContext.Server.MapPath("~/Templates/category-quiz.html");
            string path = ControllerContext.HttpContext.Server.MapPath("~");

            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + "/Templates/category-quiz.html", System.Text.Encoding.UTF8);

            var docIndex = new HtmlDocument();
            docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
            var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

            //حذف محتويات ند بلاك-author-grid
            foreach (var itemNode in nodesIndex)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    if (itemAttr.Value == "author-grid")
                    {
                        itemNode.RemoveAllChildren();
                        break;
                    }
                }
            }


            var postQuiz = context.Posts.ToList();
            foreach (var item in postQuiz)
            {
                var itSelfNode = CreateHead(docTemplates, item);
                if (itSelfNode != null)
                {
                   var result =  AddHeadToContent(nodesIndex, itSelfNode);

                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(result.OuterHtml);

                    htmlDoc.Save("Mountain1.html", Encoding.UTF8);
                }
            }
            return View();
        }


        //ايجاد محتوا براي وسط صفحه-- author-grid 
        private HtmlNode CreateHead(HtmlDocument docTemplates, Post item)
        {
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");
            foreach (var itemNode in nodes)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    //entry-cover پيدا كردن تگ ديو با كلاس 
                    if (itemAttr.Value == "entry-cover")
                    {
                        //ايجاد entry-cover
                        HtmlNode oldChild = itemNode.FirstChild;
                        HtmlNode newChild = HtmlNode.CreateNode("<a href='" + item.Url + "' name='" + item.PostID + "'>  <img width='290' height='170' src='" + item.Image1 + "'  alt='" + item.Subject + "' />  </a>");
                        itemNode.ReplaceChild(newChild, oldChild);

                        //برادر بعدي
                        //ايجاد entry-content


                        // برادر بعدي
                        //ايجاد entry-footer


                        //article ايجاد تگ 
                        HtmlNode articleNode = HtmlNode.CreateNode("<article class='col-md-4 format-standard hentry category-quiz'></article>");
                        articleNode.AppendChild(nodes.FirstOrDefault());
                        return articleNode;
                    }
                }
            }  

            return null;
        }

        //اضافه كردن محتوا به وسط صفحه -- author-grid 
        private HtmlNode AddHeadToContent(HtmlNodeCollection nodesIndex, HtmlNode itSelfNode)
        {
            foreach (var itemNode in nodesIndex)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    if (itemAttr.Value == "author-grid")
                    {
                        itemNode.AppendChild(itSelfNode);
                        return nodesIndex.FirstOrDefault();
                    }
                }
            }

            return null;
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