using GossipDashboard.Models;
using GossipDashboard.ViewModel;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GossipDashboard.Helper
{
    public class PostManagement
    {
        private string path;

        public PostManagement()
        {

        }

        public PostManagement(string path)
        {
            this.path = path;
        }



        /// <summary>
        /// ساخت آرتیکل های وسط صفحه
        /// </summary>
        /// <param name="post">شی پست</param>
        /// <param name="templateCategory">تمپلیتی که قصد داریم از روی آن آرتیکل را بسازیم</param>
        /// <returns></returns>
        internal HtmlNode CreateHead(VM_Post post)
        {
            string postClassArticle = "", postClassCategory = "";
            //string postClassArticle = "", postClassCategory = "";
            string categoryAboveClass = "", categoryAboveName = "";
            var docTemplates = new HtmlDocument();
            HtmlNodeCollection nodes = new HtmlNodeCollection(HtmlNode.CreateNode("div"));
            string formatPostName = "standard";

            foreach (var item in post.PostFormat)
            {
                postClassArticle += item.ClassName + " ";
            }
            foreach (var item in post.PostCategory)
            {
                postClassCategory += " " + item.ClassName + " ";
            }
            foreach (var item in post.LinkToAllPostCategory)
            {
                categoryAboveClass += item.ClassName + " ";
                categoryAboveName += item.NameFa + " ";
            }

            //هر پست یک فرمت پست دارد
            var postFormat = post.PostFormat.ToList().FirstOrDefault();
            if (postFormat != null)
                formatPostName = postFormat.NameEn;

            switch (formatPostName)
            {
                case "standard":
                    docTemplates.Load(path + "/Templates/format-standard.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadStandard(post, categoryAboveClass, categoryAboveName, docTemplates);
                    break;
                case "audio":
                    docTemplates.Load(path + "/Templates/format-audio.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadAudio(post, categoryAboveClass, categoryAboveName, docTemplates);
                    break;
                case "video":
                    docTemplates.Load(path + "/Templates/format-video.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadVideo(post, categoryAboveClass, categoryAboveName, docTemplates);
                    break;
                case "gallery":
                    docTemplates.Load(path + "/Templates/format-gallery.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadGallery(post, categoryAboveClass, categoryAboveName, docTemplates);
                    break;
                case "link":
                    docTemplates.Load(path + "/Templates/format-link.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadLink(post, categoryAboveClass, categoryAboveName, docTemplates);
                    break;
                case "quote":
                    docTemplates.Load(path + "/Templates/format-quote.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadQuote(post, categoryAboveClass, categoryAboveName, docTemplates);
                    break;
                case "image ":
                    docTemplates.Load(path + "/Templates/format-image.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadimage(post, categoryAboveClass, categoryAboveName, docTemplates);
                    break;
                case "status":
                    docTemplates.Load(path + "/Templates/format-status.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadStatus(post, categoryAboveClass, categoryAboveName, docTemplates);
                    break;
                default:
                    docTemplates.Load(path + "/Templates/format-standard.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadStandard(post, categoryAboveClass, categoryAboveName, docTemplates);
                    break;
            }

            //article ايجاد تگ 
            HtmlNode articleNode = HtmlNode.CreateNode("<article class='col-md-4 hentry " + postClassArticle + postClassCategory + "'></article>");
            articleNode.AppendChild(nodes.FirstOrDefault());
            return articleNode;
        }


        /// <summary>
        /// ساخت آرتیکل های استاندارد وسط صفحه
        /// </summary>
        /// <param name="post">شی پست</param>
        /// <param name="templateCategory">تمپلیتی که قصد داریم از روی آن آرتیکل را بسازیم</param>
        /// <returns></returns>
        ///   
        //private HtmlNode CreateHeadStandard(VM_Post post, string templateCategory)
        private HtmlNodeCollection CreateHeadStandard(VM_Post post, string categoryAboveClass, string categoryAboveName, HtmlDocument docTemplates)
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
                        //برادر اول
                        HtmlNode oldChild = itemNode.SelectSingleNode("//a");
                        HtmlNode newChild = HtmlNode.CreateNode("<a href='" + post.Url + "' name='" + post.PostID + "'>  <img width='290' height='170' src='" + post.Image1 + "'  alt='" + post.Subject + "' />  </a>");
                        itemNode.ReplaceChild(newChild, oldChild);

                        //برادر بعدي
                        oldChild = itemNode.SelectSingleNode("//div/div/div");
                        newChild = HtmlNode.CreateNode(@"<div class='post-category'><a href='Quiz/Index' class='" + categoryAboveClass + "'>" + categoryAboveName + "</a></div>");
                        itemNode.ReplaceChild(newChild, oldChild);

                        // برادر بعدي
                        oldChild = itemNode.SelectSingleNode("/article[1]/div[1]/div[1]/a[2]");
                        newChild = HtmlNode.CreateNode(@"<a href='" + post.Url + "' class='special-rm-arrow'><i class='fa fa-arrow-right'></i></a>");
                        itemNode.ReplaceChild(newChild, oldChild);
                    }

                    //entry-content پيدا كردن تگ ديو با كلاس 
                    if (itemAttr.Value == "entry-content")
                    {
                        //ايجاد entry-content
                        HtmlNode oldChild = itemNode.SelectSingleNode("/article[1]/div[1]/div[2]/h3");
                        HtmlNode newChild = HtmlNode.CreateNode(@"<h3 class=""entry-title""> <a href='" + post.Url + "'>" + post.Subject + "</a></h3>");
                        itemNode.ReplaceChild(newChild, oldChild);
                    }

                    //entry-footer پيدا كردن تگ ديو با كلاس 
                    if (itemAttr.Value == "entry-footer")
                    {
                        HtmlNode oldChild = itemNode.SelectSingleNode("/article[1]/div[1]/div[3]/div[1]");
                        HtmlNode newChild = HtmlNode.CreateNode(@"<div class=' row'>
                                                                        <div class='col-md-12'>
                                                                            <ul class='common-meta' style='width:auto'>
                                                                                <li>
                                                                                    <i class='fa fa-user'></i>
                                                                                    <a href='Admin/" + post.Fullname + "' title=ایجادکننده'" + post.Fullname + "' rel='author'>" + post.Fullname + "</a>" +
                                                                                "</li>" +
                                                                                "<li>" +
                                                                                    "<i class='fa fa-comment'> " + post.CommentCount + "</i>" +
                                                                                    "<a href='Comment/" + post.PostID + "' > " +
                                                                                "</li>" +
                                                                                "<li class='post-like'>" +
                                                                                    "<a href='#'>" +
                                                                                        "<p class='fa fa-eye'></p> " + post.Views +
                                                                                   "</a>" +
                                                                                "</li>" +
                                                                            "</ul>" +
                                                                        "</div>" +
                                                                    "</div>");
                        itemNode.ReplaceChild(newChild, oldChild);
                    }
                }
            }

            return nodes;
        }

        private HtmlNodeCollection CreateHeadAudio(VM_Post post, string categoryAboveClass, string categoryAboveName, HtmlDocument docTemplates)
        {
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");
            foreach (var itemNode in nodes)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    //defaultForAllPost پيدا كردن تگ ديو با كلاس 
                    if (itemAttr.Value.Contains("defaultForAllPost"))
                    {
                        HtmlNode oldChild = itemNode.SelectSingleNode("/article[1]/div[1]/div[1]");
                        HtmlNode newChild = HtmlNode.CreateNode(@"<div class='post-box'>" +
                                                                        "<div class='entry-cover'>" +
                                                                            "<div id='" + post.PostID + "' class='carousel slide gallery_post' data-ride='carousel'>" +
                                                                                "<div class='carousel-inner' role='listbox'>" +
                                                                                    "<div class='item'>" +
                                                                                        "<img src='http://viralnews.weblusive-themes.com/wp-content/uploads/2016/02/animal-92728_1280-665x315.jpg' class='blog-post-img'" +
                                                                                             "alt='' width='665' height='315' />" +
                                                                                    "</div>" +
                                                                                    "<div class='item'>" +
                                                                                        "<img src='http://viralnews.weblusive-themes.com/wp-content/uploads/2016/02/chihuahua-624924_1280-665x315.jpg' class='blog-post-img'" +
                                                                                             "alt='' width='665' height='315' />" +
                                                                                   "</div>" +
                                                                                    "<div class='item'>" +
                                                                                        "<img src='http://viralnews.weblusive-themes.com/wp-content/uploads/2016/02/deer-952744_1280-665x315.jpg' class='blog-post-img'" +
                                                                                            " alt='' width='665' height='315' />" +
                                                                                   "</div>" +
                                                                                "</div>" +
                                                                                "<a class='left carousel-control' href='#galpost_924' role='button' data-slide='prev'>" +
                                                                                    "<span class='glyphicon glyphicon-chevron-left' aria-hidden='true'></span>" +
                                                                                    "<span class='sr-only'>Previous</span>" +
                                                                               "</a>" +
                                                                                "<a class='right carousel-control' href='#galpost_924' role='button' data-slide='next'>" +
                                                                                    "<span class='glyphicon glyphicon-chevron-right' aria-hidden='true'></span>" +
                                                                                    "<span class='sr-only'>Next</span>" +
                                                                               "</a>" +
                                                                            "</div>" +
                                                                           " <script type='text/javascript'> " +
                                                                                "jQuery('document').ready(function () {" +
                                                                                    "jQuery('.gallery_post .carousel-inner div.item').first().addClass('active'); " +
                                                                                    "jQuery('.carousel').carousel({" +
                                                                                       " interval: 3000" +
                                                                                    "}); " +
                                                                                "})" +
                                                                            "</script>" +
                                                                            "<div class='post-category'>" +
                                                                                "<a href='Post/Post-5.html' class='cat-amazing'>حیرت آور</a>" +
                                                                            "</div>" +
                                                                            "<a href='post/post-32.html' class='special-rm-arrow'>" +
                                                                                "<i class='fa fa-arrow-right'></i>" +
                                                                            "</a>" +
                                                                        "</div>" +
                                                                       " <div class='entry-content'>" +
                                                                           " <h3 class='entry-title'>" +
                                                                               " <a href='post/post-32.html'>خانه های منحصر به فرد ملی جغرافیایی جهان (12 عکس)</a>" +
                                                                            "</h3>" +
                                                                        "</div>" +
                                                                        "<div class='entry-footer'>" +
                                                                            "<div class=' row'>" +
                                                                                "<div class='col-md-12'>" +
                                                                                    "<ul class='common-meta'>" +
                                                                                        "<li>" +
                                                                                            "<i class='fa fa-user'></i>" +
                                                                                            "<a href='post/admin.html' title='Posts by admin' rel='author'>مدير</a>" +
                                                                                        "</li>" +
                                                                                        "<li>" +
                                                                                            "<i class='fa fa-comment'></i>" +
                                                                                            "<a href='post/post-32.html#respond'>0</a> " +
                                                                                        "</li> " +
                                                                                        "<li class='post-like'>" +
                                                                                            "<a href='#'> " +
                                                                                                "<i class='fa fa-eye'></i>1169" +
                                                                                            "</a>" +
                                                                                        "</li>" +
                                                                                    "</ul>" +
                                                                                "</div>" +
                                                                            "</div>" +
                                                                       "</div>" +
                                                                    "</div>");
                        itemNode.ReplaceChild(newChild, oldChild);
                    }
                }
            }

            return nodes;
        }

        private HtmlNodeCollection CreateHeadGallery(VM_Post post, string categoryAboveClass, string categoryAboveName, HtmlDocument docTemplates)
        {
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");
            foreach (var itemNode in nodes)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    //defaultForAllPost پيدا كردن تگ ديو با كلاس 
                    if (itemAttr.Value.Contains("defaultForAllPost"))
                    {
                        HtmlNode oldChild = itemNode.SelectSingleNode("/article[1]/div[1]/div[1]");
                        HtmlNode newChild = HtmlNode.CreateNode("<div class='post-box'>" +
                                                                    "<div class='entry-cover'>" +
                                                                        "<div id='galpost" + post.PostID + "' class='carousel slide gallery_post' data-ride='carousel'>" +
                                                                            "<div class='carousel-inner' role='listbox'>" +
                                                                                "<div class='item'>" +
                                                                                    "<img src='" + post.Image1 + "' class='blog-post-img'" +
                                                                                            "alt='" + post.Subject + "' width='665' height='315' />" +
                                                                                "</div>" +
                                                                                "<div class='item'>" +
                                                                                    "<img src='" + post.Image2 + "' class='blog-post-img'" +
                                                                                            "alt='" + post.Subject + "' width='665' height='315' />" +
                                                                                "</div>" +
                                                                                "<div class='item'>" +
                                                                                    "<img src='post.Image3' class='blog-post-img'" +
                                                                                            "alt='" + post.Subject + "' width='665' height='315' />" +
                                                                                "</div>" +
                                                                            "</div>" +
                                                                            "<a class='left carousel-control' href='#galpost" + post.PostID + "' role='button' data-slide='prev'>" +
                                                                                "<span class='glyphicon glyphicon-chevron-left' aria-hidden='true'></span>" +
                                                                                "<span class='sr-only'>Previous</span>" +
                                                                            "</a>" +
                                                                            "<a class='right carousel-control' href='#galpost" + post.PostID + "' role='button' data-slide='next'>" +
                                                                                "<span class='glyphicon glyphicon-chevron-right' aria-hidden='true'></span>" +
                                                                                "<span class='sr-only'>Next</span>" +
                                                                            "</a>" +
                                                                        "</div>" +
                                                                        "<script type='text/javascript'> " +
                                                                            "jQuery('document').ready(function () {" +
                                                                                "jQuery('.gallery_post .carousel-inner div.item').first().addClass('active'); " +
                                                                                "jQuery('.carousel').carousel({" +
                                                                                    "interval: 3000" +
                                                                                "}); " +
                                                                            "})" +
                                                                        "</script>" +
                                                                        "<div class='post-category'>" +
                                                                            "<a href='" + categoryAboveName + "' class='cat-amazing'>" + categoryAboveName + "</a>" +
                                                                        "</div>" +
                                                                        "<a href='" + post.Url + "' class='special-rm-arrow'>" +
                                                                            "<i class='fa fa-arrow-right'></i>" +
                                                                        "</a>" +
                                                                    "</div>" +
                                                                    "<div class='entry-content'>" +
                                                                        "<h3 class='entry-title'>" +
                                                                            "<a href='" + post.Url + "'>" + post.Subject + "</a>" +
                                                                        "</h3>" +
                                                                    "</div>" +
                                                                    "<div class='entry-footer'>" +
                                                                        "<div class=' row'>" +
                                                                            "<div class='col-md-12'>" +
                                                                                "<ul class='common-meta'>" +
                                                                                    "<li>" +
                                                                                        "<i class='fa fa-user'></i>" +
                                                                                        "<a href='Admin/" + post.Fullname + "' title='Posts by admin' rel='author'>" + post.Fullname + "</a>" +
                                                                                    "</li>" +
                                                                                    "<li>" +
                                                                                        "<i class='fa fa-comment'></i>" +
                                                                                        "<a href='Comment/" + post.PostID + "'>" + post.CommentCount + "</a> " +
                                                                                    "</li> " +
                                                                                    "< li class='post-like'>" +
                                                                                        "<a href='#'> " +
                                                                                            "<i class='fa fa-eye'></i>" + post.Views + "" +
                                                                                        "</a>" +
                                                                                    "</li>" +
                                                                                "</ul>" +
                                                                            "</div>" +
                                                                        "</div>" +
                                                                    "</div>" +
                                                                 "</div>");
                        itemNode.ReplaceChild(newChild, oldChild);
                    }
                }
            }

            return nodes;
        }

        private HtmlNodeCollection CreateHeadimage(VM_Post post, string categoryAboveClass, string categoryAboveName, HtmlDocument docTemplates)
        {
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");
            foreach (var itemNode in nodes)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    //defaultForAllPost پيدا كردن تگ ديو با كلاس 
                    if (itemAttr.Value.Contains("defaultForAllPost"))
                    {
                        HtmlNode oldChild = itemNode.SelectSingleNode("/article[1]/div[1]/div[1]");
                        HtmlNode newChild = HtmlNode.CreateNode(" <div class='post-box' style='background-repeat:no-repeat; background-size:cover; background-image:url(http://viralnews.weblusive-themes.com/wp-content/uploads/2016/03/14574561403248-1-290x170.jpg'>" +
                                                                    "<div class='bg-overlay' style='background-color:rgba(0,0,0, 0.8)'></div>" +
                                                                    "<div class='entry-cover'>" +
                                                                        "<div class='post-category'>" +
                                                                            "<a href = 'Post/Post-6.html' class='cat-bizarre'>عجیب و غریب</a>" +
                                                                        "</div>" +
                                                                    "</div>" +
                                                                    "<div class='entry-content'>" +
                                                                        "<h3 class='entry-title'>" +
                                                                            "<a href = 'Post/Post-3.html' > همانطور که مود ولچ comedian افسردگی را به یک comet ملودی خنده دار Instagram هدایت کرد</a>" +
                                                                        "</h3>" +
                                                                    "</div>" +
                                                                    "<div class='entry-footer'>" +
                                                                        "<div class=' row'>" +
                                                                            "<div class='col-md-12'>" +
                                                                                "<ul class='common-meta'>" +
                                                                                    "<li>" +
                                                                                        "<i class='fa fa-user'></i>" +
                                                                                        "<a href = 'post/admin.html' title='Posts by admin' rel='author'>مدير</a>" +
                                                                                    "</li>" +
                                                                                    "<li>" +
                                                                                        "<i class='fa fa-comment'></i>" +
                                                                                        "<a href = 'Post/Post-3.html#respond' > 0 </ a > " +
                                                                                    "</li > " +
                                                                                    "<li class='post-like'>" +
                                                                                        "<a href = '#' > " +
                                                                                            "<i class='fa fa-eye'></i>868" +
                                                                                        "</a>" +
                                                                                    "</li>" +
                                                                                "</ul>" +
                                                                            "</div>" +
                                                                        "</div>" +
                                                                    "</div>" +
                                                                "</div>");
                        itemNode.ReplaceChild(newChild, oldChild);
                    }
                }
            }

            return nodes;
        }

        private HtmlNodeCollection CreateHeadLink(VM_Post post, string categoryAboveClass, string categoryAboveName, HtmlDocument docTemplates)
        {
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");
            foreach (var itemNode in nodes)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    //defaultForAllPost پيدا كردن تگ ديو با كلاس 
                    if (itemAttr.Value.Contains("defaultForAllPost"))
                    {
                        HtmlNode oldChild = itemNode.SelectSingleNode("/article[1]/div[1]/div[1]");
                        HtmlNode newChild = HtmlNode.CreateNode("<div class='post-box'>" +
                                                                    "<div class='entry-content'>" +
                                                                        "<div class='bg-overlay' style='background-color:rgba(238,28,37, 0.8)'></div>" +
                                                                        "<h3>" +
                                                                           " لینک ویژه برجسته امروز یک وب سایت است که فرایند تولید مواد غذایی را هنر می کند" +
                                                                        "</h3>" +
                                                                       " <a href = 'http://www.google.com' > " +
                                                                            "< i class='fa fa-link'></i>http://www.google.com" +
                                                                        "</a>" +
                                                                    "</div>" +
                                                                "</div>");
                        itemNode.ReplaceChild(newChild, oldChild);
                    }
                }
            }

            return nodes;
        }

        private HtmlNodeCollection CreateHeadQuote(VM_Post post, string categoryAboveClass, string categoryAboveName, HtmlDocument docTemplates)
        {
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");
            foreach (var itemNode in nodes)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    //defaultForAllPost پيدا كردن تگ ديو با كلاس 
                    if (itemAttr.Value.Contains("defaultForAllPost"))
                    {
                        HtmlNode oldChild = itemNode.SelectSingleNode("/article[1]/div[1]/div[1]");
                        HtmlNode newChild = HtmlNode.CreateNode("<div class='post-box'>" +
                                                                    "< div class='entry-content' style='background-image:url(http://viralnews.weblusive-themes.com/wp-content/uploads/2016/03/40.jpg'>" +
                                                                        "<div class='bg-overlay' style='background-color:rgba(130,184,245, 0.8)'></div>" +
                                                                        "<blockquote>" +
                                                                            "<h4>" +
                                                                                "<a href = 'post/post-30.html' > طراحی وب پاسخگو به ما یک راه پیش رو ارائه می دهد، و در نهایت به ما اجازه می دهد که طراحی و برنامه ریزی شده برای ریزش و جریان چیزها را طراحی کنیم.</a>" +
                                                                            "</h4>" +
                                                                            "<cite>جاناتان لیوینگستون</cite>" +
                                                                        "</blockquote>" +
                                                                    "</div>" +
                                                                "</div>");

                        itemNode.ReplaceChild(newChild, oldChild);
                    }
                }
            }

            return nodes;
        }

        private HtmlNodeCollection CreateHeadStatus(VM_Post post, string categoryAboveClass, string categoryAboveName, HtmlDocument docTemplates)
        {
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");
            foreach (var itemNode in nodes)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    //defaultForAllPost پيدا كردن تگ ديو با كلاس 
                    if (itemAttr.Value.Contains("defaultForAllPost"))
                    {
                        HtmlNode oldChild = itemNode.SelectSingleNode("/article[1]/div[1]/div[1]");
                        HtmlNode newChild = HtmlNode.CreateNode("<div class='post-box'>" +
                                                                    "<div class='entry-content'>" +
                                                                        "<h3 class='status lead'>" + post.Subject + "</h3>" +
                                                                    "</div>" +
                                                                "</div>");
                        itemNode.ReplaceChild(newChild, oldChild);
                    }
                }
            }

            return nodes;
        }

        private HtmlNodeCollection CreateHeadVideo(VM_Post post, string categoryAboveClass, string categoryAboveName, HtmlDocument docTemplates)
        {
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");
            foreach (var itemNode in nodes)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    //defaultForAllPost پيدا كردن تگ ديو با كلاس 
                    if (itemAttr.Value.Contains("defaultForAllPost"))
                    {
                        HtmlNode oldChild = itemNode.SelectSingleNode("/article[1]/div[1]/div[1]");
                        HtmlNode newChild = HtmlNode.CreateNode("<div class='post-box'>" +
                                                                    "<div class='entry-cover'>" +
                                                                        "<div class='flex-video'>" +
                                                                            "<div style = 'width: 640px;' class='wp-video'>" +
                                                                                "<!--[if lt IE 9]><script>document.createElement('video');</script><![endif]-->" +
                                                                                "<video class='wp-video-shortcode' id='video-" + post.PostID + "' width='640' height='360' preload='metadata' controls='controls'>" +
                                                                                    "<source type = 'video/mp4' src='" + post.Url + "?_=1'/>" +
                                                                                    "<a href = '" + post.Url + "' >" + post.Url + " </a> " +
                                                                                "</video> " +
                                                                            "</div> " +
                                                                        "</div> " +
                                                                        "<div class='post-category'>" +
                                                                            "<a href = 'Video/Video1' class='" + categoryAboveClass + "'>" + categoryAboveName + "</a>" +
                                                                        "</div>" +
                                                                        "<a href = 'Video/" + post.PostID + "' class='special-rm-arrow'>" +
                                                                            "<i class='fa fa-arrow-right'></i>" +
                                                                        "</a>" +
                                                                    "</div>" +
                                                                    "<div class='entry-content'>" +
                                                                        "<h3 class='entry-title'>" +
                                                                            "<a href = 'Video/" + post.PostID + "' >" + post.Subject + "</a>" +
                                                                        "</h3>" +
                                                                   " </div>" +
                                                                    "<div class='entry-footer'>" +
                                                                        "<div class=' row'>" +
                                                                            "<div class='col-md-12'>" +
                                                                                "<ul class='common-meta'>" +
                                                                                    "<li>" +
                                                                                        "<i class='fa fa-user'></i>" +
                                                                                        "<a href = 'Admin/" + post.PostID + "' title='" + post.Fullname + "' rel='author'>" + post.Fullname + "</a>" +
                                                                                    "</li>" +
                                                                                    "<li>" +
                                                                                        "<i class='fa fa-comment'></i>" +
                                                                                        "<a href = 'Comment/'" + post.CommentCount + "> 0 </a> " +
                                                                                    "</li> " +
                                                                                    "<li class='post-like'>" +
                                                                                        "<a href = '#' > " +
                                                                                            "<i class='fa fa-eye'></i>" + post.Views + "" +
                                                                                        "</a>" +
                                                                                    "</li>" +
                                                                                "</ul>" +
                                                                            "</div>" +
                                                                        "</div>" +
                                                                    "</div>" +
                                                                "</div>");
                        itemNode.ReplaceChild(newChild, oldChild);
                    }
                }
            }

            return nodes;
        }


        /// <summary>
        /// اضافه كردن محتوا به وسط صفحه
        /// </summary>
        /// <param name="nodesIndex">ند محتوا</param>
        /// <param name="attrValue">نام کلاسی که مشخص می کند محتوای این قسمت را می خواهیم</param>
        /// <param name="itSelfNode">ندی که می خواهید به محتوا اضافه کنید</param>
        /// <returns></returns>
        internal HtmlNode AddHeadToContent(HtmlNodeCollection nodesIndex, string attrValue, HtmlNode itSelfNode)
        {
            foreach (var itemNode in nodesIndex)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    if (itemAttr.Value == attrValue)
                    {
                        itemNode.AppendChild(itSelfNode);
                        return nodesIndex.FirstOrDefault();
                    }
                }
            }

            return null;
        }


        /// <summary>
        /// پاک کردن محتوایات ند
        /// </summary>
        /// <param name="nodesIndex">ندی که قصد دارید تمامی محتوا یا قسمتی از محتوای آن را حذف کنید</param>
        /// <param name="attrValue">نام کلاسی که مشخص می کند محتوا از این قسمت پاک گردد</param>
        /// <returns>bool</returns>
        internal bool ClearContentNode(HtmlNodeCollection nodesIndex, string attrValue)
        {
            foreach (var itemNode in nodesIndex)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    if (itemAttr.Value == attrValue)
                    {
                        itemNode.RemoveAllChildren();
                        return true;
                    }
                }
            }

            return false;
        }
    }
}