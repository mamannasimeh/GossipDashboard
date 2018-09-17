﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GossipDashboard.Models;

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
                var nodes = docTemplates.DocumentNode.SelectNodes("//div");
                foreach (var itemNode in nodes)
                {
                    var attrs = itemNode.Attributes;
                    foreach (var itemAttr in attrs)
                    {
                        if (itemAttr.Value == "entry-cover")
                        {
                            HtmlNode oldChild = itemNode.ChildNodes[1];

                            HtmlNode newChild = HtmlNode.CreateNode("<a href='' name='imagequiz'>  <img width='290' height='170' src='Image/book/jTest.jpeg'  alt='براي تست' />  </a>");

                            itemNode.ReplaceChild(newChild, oldChild);
                        }
                    }
                }
            }

    



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