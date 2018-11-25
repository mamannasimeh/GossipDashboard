﻿using HtmlAgilityPack;
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

namespace GossipDashboard.Controllers
{
    public class HomeController : Controller
    {
        private HtmlNode result;

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

        //ایجاد صفحه اصلی
        private void CreateIndexPage(string path, PostManagement postManagement)
        {
            var repo = new PostRepository();
            var docIndex = new HtmlDocument();
            /////////////////////////////create bloglist/////////////////////////////
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-author-grid
                postManagement.ClearContentNode(nodesIndex, "author-grid");

                //ایجاد  تگ آرتیکل به ازای هر پست
                int i = 0; List<string> duplicateImage = new List<string>();
                var postQuiz = repo.SelectPostUser().OrderByDescending(p => p.PostID).ToList();
                foreach (var item in postQuiz)
                {
                    //برای قسمت اصلی داشتن  تصویر مهم است
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
                }


                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.OuterHtml);
                htmlDoc.Save(path + "/Views/Home/Index.cshtml", Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }

            //////////////////////Create catlist///////////////////////////////////////
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-catlist
                postManagement.ClearContentNode(nodesIndex, "tab-content");

                //ایجاد  محتواي تب هاي کت ليست
                var postQuiz = repo.SelectPostUser().ToList();
                foreach (var item in postQuiz)
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
            }

            //////////////////////Create bloglist-content///////////////////////////////////////
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-catlist
                postManagement.ClearContentNode(nodesIndex, "row bloglist-content");

                //ایجاد  محتواي تب هاي کت ليست
                var postQuiz = repo.SelectPostUser().OrderBy(x => x.CommentCount).Take(7).ToList();
                foreach (var item in postQuiz)
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
            }

            //////////////////////Create bloglist-default///////////////////////////////////////
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-catlist
                postManagement.ClearContentNode(nodesIndex, "bloglist default");

                //ایجاد  محتواي bloglist default
                var postQuiz = repo.SelectPostUser().Take(5).ToList();
                foreach (var item in postQuiz)
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
            }

            //////////////////////Create postslider-container slider-image-bottom///////////////////////////////////////
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-slider-image-bottom
                postManagement.ClearContentNode(nodesIndex, "sp-slides sp-slider-image");

                //ایجاد  محتواي slider-image-bottom
                var postQuiz = repo.SelectPostUser().Take(7).ToList();
                foreach (var item in postQuiz)
                {
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
            }

            //////////////////////Create postslider-container slider-image-bottom sp-thumbnails sp-slider-image///////////////////////////////////////
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند بلاك-slider-image-bottom
                postManagement.ClearContentNode(nodesIndex, "sp-thumbnails sp-slider-image");

                //ایجاد  محتواي slider-image-bottom
                var postQuiz = repo.SelectPostUser().Take(7).ToList();
                foreach (var item in postQuiz)
                {
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
            }


            ////////////////////////sp-slides sp-slider-image-top///////////////////////////////////////
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند
                postManagement.ClearContentNode(nodesIndex, "sp-slides sp-slider-image-top");

                //ایجاد  محتوا
                var postQuiz = repo.SelectPostUser().OrderBy(x => x.PostID).Skip(7).Take(8).ToList();
                foreach (var item in postQuiz)
                {
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
            }

            ////////////////////////sp-thumbnails sp-slider-image-top///////////////////////////////////////
            try
            {
                docIndex.Load(path + "/Views/Home/Index.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//div");

                //حذف محتويات ند
                postManagement.ClearContentNode(nodesIndex, "sp-thumbnails sp-slider-image-top");

                //ایجاد  محتوا
                var postQuiz = repo.SelectPostUser().OrderBy(x => x.PostID).Skip(7).Take(8).ToList();
                foreach (var item in postQuiz)
                {
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
            }



            ////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////// sidebar-widget mostviewed///////////////////////////////////////
            try
            {
                docIndex.Load(path + "/Views/Shared/_Layout.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//ul");

                ////حذف محتويات ند بلاك-slider-image-bottom
                postManagement.ClearContentNode(nodesIndex, "recent_posts_wid right-slider1");

                ////ایجاد  محتوا
                int rowID = 1;
                var postQuiz = repo.SelectPostUser().OrderByDescending(p => p.Views).Take(5).ToList();
                foreach (var item in postQuiz)
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
            }

            //////////////////////// sidebar-widget popular///////////////////////////////////////
            try
            {
                docIndex.Load(path + "/Views/Shared/_Layout.cshtml", System.Text.Encoding.UTF8);
                var nodesIndex = docIndex.DocumentNode.SelectNodes("//ul");

                //حذف محتويات ند بلاك-slider-image-bottom
                postManagement.ClearContentNode(nodesIndex, "recent_posts_wid right-slider2");

                //ایجاد  محتوا
                int rowID = 1;
                var postQuiz = repo.SelectPostUser().OrderByDescending(x => x.LikePost).Take(5).ToList();
                foreach (var item in postQuiz)
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
                var postQuiz = repo.SelectPostUser().OrderByDescending(x => x.PostID).Take(6).ToList();
                foreach (var item in postQuiz)
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
            }
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

        //ایجاد پست ها از جدول جدول پست به جدول پست
        public JsonResult CreatePost()
        {
            return null;
        }
    }
}
