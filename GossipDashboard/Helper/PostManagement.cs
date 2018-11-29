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
        //private LogRepository repoLog = new Repository.LogRepository();
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
        internal HtmlNode CreateBloglist(VM_Post post)
        {
            string postClassArticle = "", postClassCategory = "", postCol = "col-md-4";
            string urlCategory = "", postUrl = "";
            string categoryAboveClass = "", categoryAboveName = "";
            var docTemplates = new HtmlDocument();
            HtmlNodeCollection nodes = new HtmlNodeCollection(HtmlNode.CreateNode("div"));
            string formatPostName = "standard";

            foreach (var item in post.PostFormat)
            {
                postClassArticle += " " + item.ClassName + " ";
            }
            foreach (var item in post.PostCategory)
            {
                postClassCategory += " " + item.ClassName + " ";

                //urlCategory = " " + post.PostCategory.ToList().First().NameEn + "/Index";
                urlCategory = "@Url.Action(\"Index\",\"" + post.PostCategory.ToList().First().NameEn + "\")";
                postUrl = "@Url.Action(\"Post\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                categoryAboveClass += " " + item.AbobeClassName + " ";
                categoryAboveName += " " + item.NameFa + " ";
            }
            if (post.PostCol.ToList().Count() > 0)
                postCol = "";
            foreach (var item in post.PostCol)
            {
                postCol = " " + item.ClassName + " ";
            }

            //هر پست یک فرمت پست دارد
            var postFormat = post.PostFormat.ToList().FirstOrDefault();
            if (postFormat != null)
                formatPostName = postFormat.NameEn;

            switch (formatPostName)
            {
                case "standard":
                    docTemplates.Load(path + "/Templates/format-standard.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadStandard(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates, postUrl);
                    break;

                case "audio":
                    var pv = post.PostCategory.ToList().FirstOrDefault();
                    if (pv != null)
                        postUrl = "@Url.Action(\"AudioPost\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                    docTemplates.Load(path + "/Templates/format-audio.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadAudio(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates, postUrl);
                    break;

                case "video":
                    var pv1 = post.PostCategory.ToList().FirstOrDefault();
                    if (pv1 != null)
                        postUrl = "@Url.Action(\"VideoPost\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                    docTemplates.Load(path + "/Templates/format-video.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadVideo(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates, postUrl);
                    break;

                case "gallery":
                    docTemplates.Load(path + "/Templates/format-gallery.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadGallery(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates, postUrl);
                    break;

                case "link":
                    docTemplates.Load(path + "/Templates/format-link.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadLink(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates, postUrl);
                    break;

                case "quote":
                    docTemplates.Load(path + "/Templates/format-quote.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadQuote(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates, postUrl);
                    break;

                case "image ":
                    docTemplates.Load(path + "/Templates/format-image.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadimage(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates, postUrl);
                    break;

                case "status":
                    docTemplates.Load(path + "/Templates/format-status.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadStatus(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates, postUrl);
                    break;

                default:
                    docTemplates.Load(path + "/Templates/format-standard.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadStandard(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates, postUrl);
                    break;
            }

            //article ايجاد تگ
            HtmlNode articleNode = HtmlNode.CreateNode("<article class='" + postCol + " hentry " + postClassArticle + postClassCategory + "'></article>");
            articleNode.AppendChild(nodes.FirstOrDefault());

            //repoLog.Add(new VM_Log()
            //{
            //    IP = "",
            //    ModifyDateTime = DateTime.Now,
            //    PostName = "CreateBloglist",
            //    PostID = -100,
            //    LogTypeID_fk = 59,
            //});

            return articleNode;
        }

        /// <summary>
        /// ساخت آرتیکل های استاندارد وسط صفحه
        /// </summary>
        /// <param name="post">شی پست</param>
        /// <param name="templateCategory">تمپلیتی که قصد داریم از روی آن آرتیکل را بسازیم</param>
        /// <returns></returns>
        //private HtmlNode CreateHeadStandard(VM_Post post, string templateCategory)
        private HtmlNodeCollection CreateHeadStandard(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates, string postUrl)
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
                        HtmlNode newChild = HtmlNode.CreateNode("<a href='" + postUrl + "' name='" + post.PostID + "'>  <img width='290' height='170' src='" + post.Image1_1 + "'  alt='" + post.Subject1 + "' />  </a>");
                        itemNode.ReplaceChild(newChild, oldChild);

                        //برادر بعدي
                        oldChild = itemNode.SelectSingleNode("//div/div/div");
                        newChild = HtmlNode.CreateNode(@"<div class='post-category'><a href='" + urlCategory + "' class='" + categoryAboveClass + "'>" + categoryAboveName + "</a></div>");
                        itemNode.ReplaceChild(newChild, oldChild);

                        // برادر بعدي
                        oldChild = itemNode.SelectSingleNode("/article[1]/div[1]/div[1]/a[2]");
                        newChild = HtmlNode.CreateNode(@"<a href='" + postUrl + "' class='special-rm-arrow'><i class='fa fa-arrow-right'></i></a>");
                        itemNode.ReplaceChild(newChild, oldChild);
                    }

                    //entry-content پيدا كردن تگ ديو با كلاس
                    if (itemAttr.Value == "entry-content")
                    {
                        //ايجاد entry-content
                        HtmlNode oldChild = itemNode.SelectSingleNode("/article[1]/div[1]/div[2]/h3");
                        HtmlNode newChild = HtmlNode.CreateNode(@"<h3 class=""entry-title""> <a href='" + postUrl + "'>" + post.Subject1 + "</a></h3>");
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

        private HtmlNodeCollection CreateHeadAudio(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates, string postUrl)
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
                                                                            "<div class='entry-cover'>" +
                                                                                "<a href='" + postUrl + "'>" +
                                                                                    "<img width='290' height='170' src='" + post.Image1_1 + "'" +
                                                                                         "class='  '" +
                                                                                         "alt='" + post.Subject1 + "' />" +
                                                                                "</a>" +
                                                                            "</div>" +
                                                                            "<div class='audio-container'>" +
                                                                                "<!--[if lt IE 9]><script>document.createElement('audio');</script><![endif]-->" +
                                                                                "<audio class='wp-audio-shortcode' id='" + post.PostID + "' preload='none' style='width: 100%;' controls='controls'>" +
                                                                                    "<source type='audio/mpeg' src='" + post.UrlMP3 + "'?_=1' />" +
                                                                                    "<a href='" + post.UrlMP3 + "'>" + post.UrlMP3 + "</a>" +
                                                                                "</audio>" +
                                                                            "</div>" +
                                                                            "<div class='post-category'>" +
                                                                                "<a href='" + urlCategory + "' class='" + categoryAboveClass + "'>" + categoryAboveName + " </a>" +
                                                                            "</div>" +
                                                                            "<a href='" + postUrl + "' class='special-rm-arrow'>" +
                                                                                "<i class='fa fa-arrow-right'></i>" +
                                                                            "</a>" +

                                                                        //"<a href='post/post-21.html' class='special-rm-arrow'>" +
                                                                        //    "<i class='fa fa-arrow-right'></i>" +
                                                                        //"</a>" +
                                                                        "</div>" +
                                                                        "<div class='entry-content'>" +
                                                                            "<h3 class='entry-title'>" +
                                                                                "<a href='" + postUrl + "'>" + post.Subject1 + "</a>" +
                                                                            "</h3>" +
                                                                        "</div>" +
                                                                        "<div class='entry-footer'>" +
                                                                            "<div class=' row'>" +
                                                                                "<div class='col-md-12'>" +
                                                                                    "<ul class='common-meta'>" +
                                                                                        "<li>" +
                                                                                            "<i class='fa fa-user'></i>" +
                                                                                            "<a href='Admin/'" + post.PostID + "' title=ایجاد شده توسط'" + post.Fullname + "' rel='author'>" + post.Fullname + "</a>" +
                                                                                       " </li>" +

                                                                                        "<li>" +
                                                                                            "<i class='fa fa-comment'></i>" +
                                                                                            "<a href='Comment/'" + post.PostID + "'>" + post.CommentCount + "</a> " +
                                                                                        "</li> " +
                                                                                        "<li class='post-like'>" +
                                                                                            "<a href='#'> " +
                                                                                                "<i class='fa fa-eye'></i>" + post.Views + "" +
                                                                                            "</a>" +
                                                                                        "</li>" +
                                                                                    "</ul>" +
                                                                                "</div>" +
                                                                           " </div>" +
                                                                        "</div>" +
                                                                   "</div>");
                        itemNode.ReplaceChild(newChild, oldChild);
                    }
                }
            }

            return nodes;
        }

        private HtmlNodeCollection CreateHeadGallery(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates, string postUrl)
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
                                                                                    "<img src='" + post.Image1_1 + "' class='blog-post-img'" +
                                                                                            "alt='" + post.Subject1 + "' width='665' height='315' />" +
                                                                                "</div>" +
                                                                                "<div class='item'>" +
                                                                                    "<img src='" + post.Image1_2 + "' class='blog-post-img'" +
                                                                                            "alt='" + post.Subject1 + "' width='665' height='315' />" +
                                                                                "</div>" +
                                                                                "<div class='item'>" +
                                                                                    "<img src='" + post.Image1_3 + "' class='blog-post-img'" +
                                                                                            "alt='" + post.Subject1 + "' width='665' height='315' />" +
                                                                                "</div>" +
                                                                            "</div>" +
                                                                            "<a class='left carousel-control' href='#galpost" + post.PostID + "' role='button' data-slide='prev'>" +
                                                                                "<span class='glyphicon glyphicon-chevron-left' aria-hidden='true'></span>" +
                                                                                "<span class='sr-only'>قبلی</span>" +
                                                                            "</a>" +
                                                                            "<a class='right carousel-control' href='#galpost" + post.PostID + "' role='button' data-slide='next'>" +
                                                                                "<span class='glyphicon glyphicon-chevron-right' aria-hidden='true'></span>" +
                                                                                "<span class='sr-only'>بعدی</span>" +
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
                                                                            "<a href='" + urlCategory + "' class='" + categoryAboveClass + "'>" + categoryAboveName + "</a>" +
                                                                        "</div>" +
                                                                        "<a href='" + postUrl + "' class='special-rm-arrow'>" +
                                                                            "<i class='fa fa-arrow-right'></i>" +
                                                                        "</a>" +
                                                                    "</div>" +
                                                                    "<div class='entry-content'>" +
                                                                        "<h3 class='entry-title'>" +
                                                                            "<a href='" + postUrl + "'>" + post.Subject1 + "</a>" +
                                                                        "</h3>" +
                                                                    "</div>" +
                                                                    "<div class='entry-footer'>" +
                                                                        "<div class=' row'>" +
                                                                            "<div class='col-md-12'>" +
                                                                                "<ul class='common-meta'>" +
                                                                                    "<li>" +
                                                                                        "<i class='fa fa-user'></i>" +
                                                                                        "<a href='Admin/" + post.Fullname + "' title='ایجاد شده توسط' rel='author'>" + post.Fullname + "</a>" +
                                                                                    "</li>" +
                                                                                    "<li>" +
                                                                                        "<i class='fa fa-comment'></i>" +
                                                                                        "<a href='Comment/" + post.PostID + "'>" + post.CommentCount + "</a> " +
                                                                                    "</li> " +
                                                                                    "<li class='post-like'>" +
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

        private HtmlNodeCollection CreateHeadimage(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates, string postUrl)
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
                        HtmlNode newChild = HtmlNode.CreateNode(" <div class='post-box' style='background-repeat:no-repeat; background-size:cover; background-image:url(" + post.Image1_1 + ")'>" +
                                                                    "<div class='bg-overlay' style='background-color:rgba(0,0,0, 0.8)'></div>" +
                                                                    "<div class='entry-cover'>" +
                                                                        "<div class='post-category'>" +
                                                                            "<a href = '" + urlCategory + "' class='" + categoryAboveClass + "'>" + categoryAboveName + "</a>" +
                                                                        "</div>" +
                                                                    "</div>" +
                                                                    "<div class='entry-content'>" +
                                                                        "<h3 class='entry-title'>" +
                                                                            "<a href = '" + postUrl + "' >" + post.Subject1 + "</a>" +
                                                                        "</h3>" +
                                                                    "</div>" +
                                                                    "<div class='entry-footer'>" +
                                                                        "<div class=' row'>" +
                                                                            "<div class='col-md-12'>" +
                                                                                "<ul class='common-meta'>" +
                                                                                    "<li>" +
                                                                                        "<i class='fa fa-user'></i>" +
                                                                                        "<a href = 'Admin/" + post.Fullname + "' title=ایجاد شده توسط'" + post.Fullname + "' rel='author'>" + post.Fullname + "</a>" +
                                                                                    "</li>" +
                                                                                    "<li>" +
                                                                                        "<i class='fa fa-comment'></i>" +
                                                                                        "<a href = 'Comment/'" + post.CommentCount + " > 0 </ a > " +
                                                                                    "</li > " +
                                                                                    "<li class='post-like'>" +
                                                                                        "<a href = '#' > " +
                                                                                            "<i class='fa fa-eye'></i>" + post.Views +
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

        private HtmlNodeCollection CreateHeadLink(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates, string postUrl)
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
                                                                        "<div class='bg-overlay' style='background-color:" + post.BackgroundColor + "'></div>" +
                                                                        "<h3>" +
                                                                           post.Subject1 +
                                                                        "</h3>" +
                                                                       " <a href = '" + postUrl + "' > " +
                                                                            "<i class='fa fa-link'></i> لینک خبر" +
                                                                        "</a>" +
                                                                    "</div>" +
                                                                "</div>");
                        itemNode.ReplaceChild(newChild, oldChild);
                    }
                }
            }

            return nodes;
        }

        private HtmlNodeCollection CreateHeadQuote(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates, string postUrl)
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
                        HtmlNode newChild = HtmlNode.CreateNode("<div class='post-box imgwrapper'>" +
                                                                    "<div class='entry-content img-responsive' style='background-image:url(" + post.Image1_1 + ")'>" +
                                                                        "<div class='bg-overlay' style='background-color:" + post.BackgroundColor + "'></div>" +
                                                                        "<blockquote>" +
                                                                            "<h4>" +
                                                                                "<a href = '" + postUrl + "' >" + post.Subject1 + "</a>" +
                                                                            "</h4>" +
                                                                            "<cite>" + post.QuotedFrom + "</cite>" +
                                                                        "</blockquote>" +
                                                                    "</div>" +
                                                                "</div>");

                        itemNode.ReplaceChild(newChild, oldChild);
                    }
                }
            }

            return nodes;
        }

        private HtmlNodeCollection CreateHeadStatus(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates, string postUrl)
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
                                                                        "<h3 class='status lead'>" + post.Subject1 + "</h3>" +
                                                                    "</div>" +
                                                                "</div>");
                        itemNode.ReplaceChild(newChild, oldChild);
                    }
                }
            }

            return nodes;
        }

        private HtmlNodeCollection CreateHeadVideo(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates, string postUrl)
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
                                                                                    "<source type = 'video/mp4' src='" + post.UrlVideo + "?_=1'/>" +
                                                                                    "<a href = '" + post.UrlVideo + "' >" + post.UrlVideo + " </a> " +
                                                                                "</video> " +
                                                                            "</div> " +
                                                                        "</div> " +
                                                                        "<div class='post-category'>" +
                                                                             "<a href='" + urlCategory + "' class='" + categoryAboveClass + "'>" + categoryAboveName + "</a>" +
                                                                        "</div>" +
                                                                        "<a href = '" + postUrl + "' class='special-rm-arrow'>" +
                                                                            "<i class='fa fa-arrow-right'></i>" +
                                                                        "</a>" +
                                                                    "</div>" +
                                                                    "<div class='entry-content'>" +
                                                                        "<h3 class='entry-title'>" +
                                                                            "<a href = '" + postUrl + "' >" + post.Subject1 + "</a>" +
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
        internal HtmlNode AddHeadToContentDiv(HtmlNodeCollection nodesIndex, string attrValue, HtmlNode itSelfNode)
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


        //
        internal HtmlNode AddHeadToContent(HtmlNodeCollection nodesIndex, string attrValue, HtmlNode itSelfNode)
        {
            var itemNode = nodesIndex.FirstOrDefault(x => x.Attributes.FirstOrDefault().Value == attrValue);
            if (itemNode != null)
            {
                itemNode.AppendChild(itSelfNode);
                return itemNode;
            }

            return null;
        }

        internal HtmlNode GetContentNode(HtmlNodeCollection nodesIndex, string attrValue)
        {
            var itemNode = nodesIndex.FirstOrDefault(x => x.Attributes.FirstOrDefault().Value == attrValue);
            return itemNode;
        }

        /// <summary>
        /// پاک کردن محتوایات ند
        /// </summary>
        /// <param name="nodesIndex">
        /// ندی که قصد دارید تمامی محتوا یا قسمتی از محتوای آن را حذف کنید
        /// </param>
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

        //catlist-heading
        public HtmlNode CreateCatListHeading(List<PubBase> category)
        {
            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + "/Templates/cat-list.html", System.Text.Encoding.UTF8);
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");
            foreach (var itemNode in nodes)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    //catlist-heading پيدا كردن تگ ديو با كلاس
                    if (itemAttr.Value.Contains("catlist-heading"))
                    {
                        var ul = "ul class='nav nav-tabs";
                        int i = 0;
                        foreach (var item in category)
                        {
                            if (i == 0)
                                ul += "<li>" + "<a href = '#' data-filter='." + item.NameEn + "' class='active'>" + item.NameFa + "</a>" + "</li>";
                            else
                                ul += "<li>" + "<a href = '#' data-filter='." + item.NameEn + "' class=''>" + item.NameFa + "</a>" + "</li>";

                            i++;
                        }
                        ul += "</ul>";

                        HtmlNode oldChild = itemNode.SelectSingleNode("/div[1]/div[1]/div[1]");
                        HtmlNode newChild = HtmlNode.CreateNode("<div><h4>" +
                                                                    "<span class='catlist-title'>آخرين رويدادها</span>" +
                                                                "</h4>"
                                                                + ul + "</div>"
                                                                );

                        return itemNode.ReplaceChild(newChild, oldChild);
                    }
                }
            }

            return null;
        }

        public HtmlNode CreateCatListContent(VM_Post post)
        {
            string catListClass = "";
            string urlCategory = "", postUrl = "";
            foreach (var item in post.PostCategory)
            {
                urlCategory = "@Url.Action(\"Index\",\"" + post.PostCategory.ToList().First().NameEn + "\")";
                postUrl = "@Url.Action(\"Post\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                var postFormat = post.PostFormat.ToList().FirstOrDefault();
                if (postFormat != null && postFormat.NameEn == "video")
                    postUrl = "@Url.Action(\"VideoPost\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";
                else if (postFormat != null && postFormat.NameEn == "audio")
                    postUrl = "@Url.Action(\"AudioPost\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                catListClass += " " + item.NameEn + " ";
            }

            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + "/Templates/cat-list.html", System.Text.Encoding.UTF8);
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");
            foreach (var itemNode in nodes)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    //tab-content پيدا كردن تگ ديو با كلاس
                    if (itemAttr.Value.Contains("tab-content"))
                    {
                        HtmlNode oldChild = itemNode.SelectSingleNode("/div[1]/div[2]/div[1]");
                        HtmlNode newChild = HtmlNode.CreateNode("<div class='col-md-6 catlist-posts small-posts " + catListClass + "  ' style='position: absolute; display: none;'>" +
                                                                    "<a href = '" + postUrl + "' > " +
                                                                        "<img width = '70' height = '70' src = '" + post.Image1_1 + "' class='' alt='' srcset='' sizes='(max-width: 70px) 100vw, 70px'>" +
                                                                    "</a>" +
                                                                    "<div class='catitem-sm-content'>" +
                                                                        "<h4 class='catitem-title'>" +
                                                                            "<a href = '" + postUrl + "'> " + post.Subject1 + "</a>" +
                                                                        "</h4>" +
                                                                        "<div class='catitem-meta'>" +
                                                                            "<span class='catitem-date'>" +
                                                                                "<i class='fa fa-calendar'></i>" + post.JalaliModifyDate + "" +
                                                                            "</span>" +
                                                                            "<span class='catitem-author'>" +
                                                                                "<i class='fa fa-user'></i> " + post.Fullname + "" +
                                                                            "</span>" +
                                                                        "</div>" +
                                                                    "</div>" +
                                                                "</div>");

                        return itemNode.ReplaceChild(newChild, oldChild);
                    }
                }
            }

            return null;
        }


        internal HtmlNode CreateBloglistContent(VM_Post post)
        {
            string urlCategory = "", postUrl = "";
            string categoryAboveClass = "", categoryAboveName = "";


            foreach (var item in post.PostCategory)
            {
                urlCategory = "@Url.Action(\"Index\",\"" + post.PostCategory.ToList().First().NameEn + "\")";
                postUrl = "@Url.Action(\"Post\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                var postFormat = post.PostFormat.ToList().FirstOrDefault();
                if (postFormat != null && postFormat.NameEn == "video")
                    postUrl = "@Url.Action(\"VideoPost\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";
                else if (postFormat != null && postFormat.NameEn == "audio")
                    postUrl = "@Url.Action(\"AudioPost\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                categoryAboveClass += " " + item.AbobeClassName + " ";
                categoryAboveName += " " + item.NameFa + " ";
            }

            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + "/Templates/bloglist-content.html", System.Text.Encoding.UTF8);
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");

            var itemNode = nodes.FirstOrDefault(x => x.Attributes.FirstOrDefault().Value == "row bloglist-content");
            if (itemNode != null)
            {
                HtmlNode oldChild = itemNode.SelectSingleNode("/div[1]/article[1]");
                HtmlNode newChild = HtmlNode.CreateNode("<article class='col-md-4'>" +
                                                               "<div class='post-object' style=' background-image:url(" + post.Image1_1 + "); background-size:cover; background-repeat:no-repeat'>" +
                                                                   "<div class='overlay'></div>" +
                                                                   "<div class='post-content'>" +
                                                                       "<a href = '" + urlCategory + "' class='post-cat " + categoryAboveClass + "'>" + categoryAboveName + "</a>" +
                                                                       "<h3 class='title'>" +
                                                                           "<a href = '" + postUrl + "' > " + post.Subject1 + "</a>" +
                                                                       "</h3>" +
                                                                       "<a href = '" + urlCategory + "' class='readmore'>بيشتر</a>" +
                                                                   "</div>" +
                                                               "</div>" +
                                                           "</article>");

                return itemNode.ReplaceChild(newChild, oldChild);
            }

            return null;
        }


        internal HtmlNode CreateBloglistDefault(VM_Post post)
        {
            string urlCategory = "", postUrl = "";
            string categoryAboveClass = "", categoryAboveName = "";


            foreach (var item in post.PostCategory)
            {
                urlCategory = "@Url.Action(\"Index\",\"" + post.PostCategory.ToList().First().NameEn + "\")";
                postUrl = "@Url.Action(\"Post\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                var postFormat = post.PostFormat.ToList().FirstOrDefault();
                if (postFormat != null && postFormat.NameEn == "video")
                    postUrl = "@Url.Action(\"VideoPost\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";
                else if (postFormat != null && postFormat.NameEn == "audio")
                    postUrl = "@Url.Action(\"AudioPost\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";


                categoryAboveClass += " " + item.AbobeClassName + " ";
                categoryAboveName += " " + item.NameFa + " ";
            }

            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + "/Templates/bloglist-default.html", System.Text.Encoding.UTF8);
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");

            var itemNode = nodes.FirstOrDefault(x => x.Attributes.FirstOrDefault().Value == "bloglist default");
            if (itemNode != null)
            {
                HtmlNode oldChild = itemNode.SelectSingleNode("/div[1]/div[1]");
                HtmlNode newChild = HtmlNode.CreateNode("<div class='bloglist-posts'>" +
                                                            "<article class='row'>" +
                                                                "<div class='blogitem-media col-md-4'>" +
                                                                    "<a href = '" + postUrl + "' > " +
                                                                        "<img width='290' height='170' src='" + post.Image1_1 + "' class='' alt=''>" +
                                                                    "</a>" +
                                                                    "<a href = '" + urlCategory + "' class='post-cat " + categoryAboveClass + "'>" + categoryAboveName + "</a>" +
                                                                "</div>" +
                                                                "<div class='col-md-8'>" +
                                                                    "<div class='blogitem-content'>" +
                                                                        "<h4 class='blogitem-title'>" +
                                                                            "<a href = '" + postUrl + "' > " + post.Subject11 + "</a>" +
                                                                        "</h4>" +
                                                                        "<div class='blogitem-excerpt'>" + post.ContentPost1_1.Substring(0, (post.ContentPost1_1.Length>200 ? 200 : post.ContentPost1_1.Length)) + "</div>" +
                                                                        "<div class='blogitem-meta'>" +
                                                                            "<span class='blogitem-author'>" +
                                                                                "<i class='fa fa-user'></i> " + post.Fullname +
                                                                            "</span>" +
                                                                            "<span class='blogitem-comment'>" +
                                                                                "<i class='fa fa-comment'></i> " + post.CommentCount +
                                                                            "</span>" +
                                                                            "<span class='blogitem-view'>" +
                                                                                "<i class='fa fa-eye'></i>" + post.Views +
                                                                            "</span>" +
                                                                            "<span class='blogitem-date'>" +
                                                                                "<i class='fa fa-calendar'></i>ا" + post.JalaliModifyDate +
                                                                            "</span>" +
                                                                        "</div>" +
                                                                    "</div>" +
                                                                "</div>" +
                                                            "</article>" +
                                                            "<a href = '" + postUrl + "' class='readmore'>" +
                                                                "<span>بیشتر بخوانيد</span>" +
                                                            "</a>" +
                                                        "</div>");

                return itemNode.ReplaceChild(newChild, oldChild);
            }

            return null;
        }



        internal HtmlNode CreateSliderImageBottom(VM_Post post)
        {
            string urlCategory = "", postUrl = "";
            string categoryAboveClass = "", categoryAboveName = "";


            foreach (var item in post.PostCategory)
            {
                urlCategory = "@Url.Action(\"Index\",\"" + post.PostCategory.ToList().First().NameEn + "\")";
                postUrl = "@Url.Action(\"Post\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                categoryAboveClass += " " + item.AbobeClassName + " ";
                categoryAboveName += " " + item.NameFa + " ";
            }

            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + "/Templates/postslider-container-slider-image-bottom.html", System.Text.Encoding.UTF8);
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");

            var itemNode = nodes.FirstOrDefault(x => x.Attributes.FirstOrDefault().Value == "sp-slides sp-slider-image");
            if (itemNode != null)
            {
                HtmlNode oldChild = itemNode.SelectSingleNode("/div[1]/div[1]/div[1]/div[1]");
                HtmlNode newChild = HtmlNode.CreateNode("<div class='sp-slide'>" +
                                                            "<a href = '" + postUrl + "' > " +
                                                                "<img width = '640' height = '426' src = '" + post.Image1_1 + "' class='sp-image ' alt='' srcset='' sizes='(max-width: 640px) 100vw, 640px'>" +
                                                            "</a>" +
                                                            "<a href = '" + urlCategory + "' class='post-cat " + categoryAboveClass + "'>" + categoryAboveName + "</a>" +
                                                            "<div class='sp-layer sp-black sp-padding' data-position='bottomLeft' data-vertical='0' data-width='100%' data-show-transition='up'>" +
                                                                "<h4>" +
                                                                    "<a href = '" + postUrl + "' >" + post.Subject1 + "</a>" +
                                                                "</h4>" +
                                                                "<a href = '" + postUrl + "' class='special-rm-arrow pull-right'>" +
                                                                    "<i class='fa fa-arrow-right'></i>" +
                                                                "</a>" +
                                                            "</div>" +
                                                        "</div>");

                return itemNode.ReplaceChild(newChild, oldChild);
            }

            return null;
        }



        internal HtmlNode CreateSliderImageBottom_ImageBottom(VM_Post post)
        {
            string urlCategory = "", postUrl = "";
            string categoryAboveClass = "", categoryAboveName = "";


            foreach (var item in post.PostCategory)
            {
                urlCategory = "@Url.Action(\"Index\",\"" + post.PostCategory.ToList().First().NameEn + "\")";
                postUrl = "@Url.Action(\"Post\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                categoryAboveClass += " " + item.AbobeClassName + " ";
                categoryAboveName += " " + item.NameFa + " ";
            }

            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + "/Templates/postslider-container-slider-image-bottom.html", System.Text.Encoding.UTF8);
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");

            var itemNode = nodes.FirstOrDefault(x => x.Attributes.FirstOrDefault().Value == "sp-thumbnails sp-slider-image");
            if (itemNode != null)
            {
                HtmlNode oldChild = itemNode.SelectSingleNode("/div[1]/div[1]/div[2]/img[1]");
                HtmlNode newChild = HtmlNode.CreateNode("<img class='sp-thumbnail' src='" + post.Image1_1 + "' width='70' height='70' alt=''>");

                return itemNode.ReplaceChild(newChild, oldChild);
            }

            return null;
        }

        internal HtmlNode CreatePostMostViewed(VM_Post post, int rowID)
        {
            string urlCategory = "", postUrl = "";
            string categoryAboveClass = "", categoryAboveName = "";


            foreach (var item in post.PostCategory)
            {
                urlCategory = "@Url.Action(\"Index\",\"" + post.PostCategory.ToList().First().NameEn + "\")";
                postUrl = "@Url.Action(\"Post\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                var postFormat = post.PostFormat.ToList().FirstOrDefault();
                if (postFormat != null && postFormat.NameEn == "video")
                    postUrl = "@Url.Action(\"VideoPost\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";
                else if (postFormat != null && postFormat.NameEn == "audio")
                    postUrl = "@Url.Action(\"AudioPost\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                categoryAboveClass += " " + item.AbobeClassName + " ";
                categoryAboveName += " " + item.NameFa + " ";
            }

            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + "/Templates/sidebar-widget.html", System.Text.Encoding.UTF8);
            var nodes = docTemplates.DocumentNode.SelectNodes("//ul");

            var itemNode = nodes.FirstOrDefault(x => x.Attributes.FirstOrDefault().Value == "recent_posts_wid right-slider1");
            if (itemNode != null)
            {
                HtmlNode oldChild = itemNode.SelectSingleNode("/aside[1]/div[1]/div[1]/div[1]/ul[1]/li[1]");
                HtmlNode newChild = HtmlNode.CreateNode("<li class='post-item'>" +
                                                            "<div class='media'>" +
                                                                "<a class='item-img media-left' href='" + postUrl + "'>" +
                                                                    rowID.ToString() +
                                                               "</a>" +
                                                                "<div class='media-body'>" +
                                                                    "<h4 class='media-heading item-title'>" +
                                                                        "<a href = '" + postUrl + "' > " + post.Subject1 + "</a>" +
                                                                    "</h4>" +
                                                                    "<ul class='item-meta'>" +
                                                                        "<li class='item-date'>" +
                                                                              "<i class='fa fa-calendar'></i>" + post.JalaliModifyDate + "" +
                                                                        "</li>" +
                                                                        "<li class='item-count'>" +
                                                                            "<i class='fa fa-eye'></i>" + post.Views +
                                                                       "</li>" +
                                                                    "</ul>" +
                                                                "</div>" +
                                                           "</div>" +
                                                       "</li>");

                return itemNode.ReplaceChild(newChild, oldChild);
            }

            return null;
        }

        internal HtmlNode CreatePostPopular(VM_Post post, int rowID)
        {
            string urlCategory = "", postUrl = "";
            string categoryAboveClass = "", categoryAboveName = "";


            foreach (var item in post.PostCategory)
            {
                urlCategory = "@Url.Action(\"Index\",\"" + post.PostCategory.ToList().First().NameEn + "\")";
                postUrl = "@Url.Action(\"Post\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                var postFormat = post.PostFormat.ToList().FirstOrDefault();
                if (postFormat != null && postFormat.NameEn == "video")
                    postUrl = "@Url.Action(\"VideoPost\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";
                else if (postFormat != null && postFormat.NameEn == "audio")
                    postUrl = "@Url.Action(\"AudioPost\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";


                categoryAboveClass += " " + item.AbobeClassName + " ";
                categoryAboveName += " " + item.NameFa + " ";
            }

            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + "/Templates/sidebar-widget.html", System.Text.Encoding.UTF8);
            var nodes = docTemplates.DocumentNode.SelectNodes("//ul");

            var itemNode = nodes.FirstOrDefault(x => x.Attributes.FirstOrDefault().Value == "recent_posts_wid right-slider2");
            if (itemNode != null)
            {
                HtmlNode oldChild = itemNode.SelectSingleNode("/aside[1]/div[1]/div[1]/div[2]/ul[1]/li[1]");
                HtmlNode newChild = HtmlNode.CreateNode("<li class='post-item'>" +
                                                            "<div class='media'>" +
                                                                "<a class='item-img media-left' href='" + postUrl + "'>" +
                                                                    rowID.ToString() +
                                                                "</a>" +
                                                                "<div class='media-body'>" +
                                                                    "<h4 class='media-heading item-title'>" +
                                                                        "<a href = '" + postUrl + "' >" + post.Subject1 + "</a>" +
                                                                    "</h4>" +
                                                                    "<ul class='item-meta'>" +
                                                                        "<li class='item-date'>" +
                                                                           "<i class='fa fa-calendar'></i>" + post.JalaliModifyDate + "" +
                                                                        "</li>" +
                                                                        "<li>" +
                                                                            "<a class='item-comment-count' href='" + postUrl + "'>" + post.CommentCount + "</a>" +
                                                                       "</li>" +
                                                                    "</ul>" +
                                                                "</div>" +
                                                            "</div>" +
                                                        "</li>");

                return itemNode.ReplaceChild(newChild, oldChild);
            }

            return null;
        }



        internal HtmlNode CreatePostSuperiorr(VM_Post post, int rowID)
        {
            string urlCategory = "", postUrl = "";
            string categoryAboveClass = "", categoryAboveName = "";


            foreach (var item in post.PostCategory)
            {
                urlCategory = "@Url.Action(\"Index\",\"" + post.PostCategory.ToList().First().NameEn + "\")";
                postUrl = "@Url.Action(\"Post\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                var postFormat = post.PostFormat.ToList().FirstOrDefault();
                if (postFormat != null && postFormat.NameEn == "video")
                    postUrl = "@Url.Action(\"VideoPost\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";
                else if (postFormat != null && postFormat.NameEn == "audio")
                    postUrl = "@Url.Action(\"AudioPost\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";



                categoryAboveClass += " " + item.AbobeClassName + " ";
                categoryAboveName += " " + item.NameFa + " ";
            }

            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + "/Templates/superior-posts.html", System.Text.Encoding.UTF8);
            var nodes = docTemplates.DocumentNode.SelectNodes("//ul");

            var itemNode = nodes.FirstOrDefault(x => x.Attributes.FirstOrDefault().Value == "superior-posts recent_posts_wid");
            if (itemNode != null)
            {
                HtmlNode oldChild = itemNode.SelectSingleNode("/aside[1]/ul[1]/li[1]");
                HtmlNode newChild = HtmlNode.CreateNode("<li class='post-item'>" +
                                                            "<div class='media'>" +
                                                                "<a class='item-img media-left' href='" + postUrl + "'>" +
                                                                    "<img width = '70' height='70' src='" + post.Image1_1 + "' class='  ' alt='' srcset='' sizes='(max-width: 70px) 100vw, 70px'>" +
                                                                "</a>" +
                                                                "<div class='media-body'>" +
                                                                    "<h4 class='media-heading item-title'>" +
                                                                        "<a href = '" + postUrl + "' > " + post.Subject1 + "</a>" +
                                                                    "</h4>" +
                                                                    "<ul class='item-meta'>" +
                                                                        "<li class='item-date'>" +
                                                                            "<i class='fa fa-calendar'></i>" + post.JalaliModifyDate + "" +
                                                                        "</li>" +
                                                                    "</ul>" +
                                                                "</div>" +
                                                            "</div>" +
                                                        "</li>");

                return itemNode.ReplaceChild(newChild, oldChild);
            }

            return null;
        }



        internal HtmlNode CreateSliderTop(VM_Post post)
        {
            string urlCategory = "", postUrl = "";
            string categoryAboveClass = "", categoryAboveName = "";


            foreach (var item in post.PostCategory)
            {
                urlCategory = "@Url.Action(\"Index\",\"" + post.PostCategory.ToList().First().NameEn + "\")";
                postUrl = "@Url.Action(\"Post\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                urlCategory = "@Url.Action(\"Index\",\"" + post.PostCategory.ToList().First().NameEn + "\")";
                categoryAboveClass += " " + item.AbobeClassName + " ";
                categoryAboveName += " " + item.NameFa + " ";
            }

            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + "/Templates/postslider-container-slider-top.html", System.Text.Encoding.UTF8);
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");

            var itemNode = nodes.FirstOrDefault(x => x.Attributes.FirstOrDefault().Value == "sp-slides sp-slider-image-top");
            if (itemNode != null)
            {
                HtmlNode oldChild = itemNode.SelectSingleNode("/div[1]/div[1]/div[1]/div[1]");
                HtmlNode newChild = HtmlNode.CreateNode("<div class='sp-slide'>" +
                                                            "<a href = '" + postUrl + "' > " +
                                                                "<img width = '640' height = '315' src = '" + post.Image1_1 + "' class='sp-image ' alt='" + post.Subject1 + "'>" +
                                                            "</a>" +
                                                            "<a href = '" + urlCategory + "' class='post-cat " + categoryAboveClass + "'>" + categoryAboveName + "</a>" +
                                                            "<div class='sp-layer sp-black sp-padding' data-position='bottomLeft' data-vertical='0' data-width='100%' data-show-transition='up'>" +
                                                                "<h4>" +
                                                                    "<a href = '" + postUrl + "' > " + post.Subject1 + "</a>" +
                                                                "</h4>" +
                                                                "<a href = '" + postUrl + "' class='special-rm-arrow pull-right'>" +
                                                                    "<i class='fa fa-arrow-right'></i>" +
                                                                "</a>" +
                                                            "</div>" +
                                                        "</div>");

                return itemNode.ReplaceChild(newChild, oldChild);
            }

            return null;
        }



        internal HtmlNode CreateSliderTopThumbnails(VM_Post post)
        {
            string urlCategory = "", postUrl = "";
            string categoryAboveClass = "", categoryAboveName = "";


            foreach (var item in post.PostCategory)
            {
                urlCategory = "@Url.Action(\"Index\",\"" + post.PostCategory.ToList().First().NameEn + "\")";
                postUrl = "@Url.Action(\"Post\",\"" + post.PostCategory.ToList().First().NameEn + "\", new {postID = " + post.PostID + "})";

                urlCategory = "@Url.Action(\"Index\",\"" + post.PostCategory.ToList().First().NameEn + "\")";
                categoryAboveClass += " " + item.AbobeClassName + " ";
                categoryAboveName += " " + item.NameFa + " ";
            }

            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + "/Templates/postslider-container-slider-top.html", System.Text.Encoding.UTF8);
            var nodes = docTemplates.DocumentNode.SelectNodes("//div");

            var itemNode = nodes.FirstOrDefault(x => x.Attributes.FirstOrDefault().Value == "sp-thumbnails sp-slider-image-top");
            if (itemNode != null)
            {
                HtmlNode oldChild = itemNode.SelectSingleNode("/div[1]/div[1]/div[2]/div[1]");
                HtmlNode newChild = HtmlNode.CreateNode("<div class='sp-thumbnail'>" +
                                                            "<div class='sp-thumbnail-text'>" +
                                                                "<div class='sp-thumbnail-title'>" + post.Subject1 + "</div>" +
                                                            "</div>" +
                                                            "<div class='sp-thumbnail-image-container'>" +
                                                                "<img width = '70' height='70' src='" + post.Image1_1 + "' class='sp-thumbnail-image ' alt='" + post.Subject1 + "' srcset='' sizes='(max-width: 70px) 100vw, 70px'>" +
                                                            "</div>" +
                                                        "</div>");

                return itemNode.ReplaceChild(newChild, oldChild);
            }

            return null;
        }


    }
}
