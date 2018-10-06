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
            string postClassArticle = "", postClassCategory = "", postCol = "col-md-4";
            string urlCategory = "";
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
                urlCategory = " " + post.PostCategory.ToList().First().NameEn + "/Index";

                categoryAboveClass += " " + item.AbobeClassName + " ";
                categoryAboveName += " " + item.NameFa + " ";
            }
            if (post.PostCol.ToList().Count() > 0)
                postCol = "";
            foreach (var item in post.PostCol)
            {
                postCol = " " +  item.ClassName + " " ;
            }

            //هر پست یک فرمت پست دارد
            var postFormat = post.PostFormat.ToList().FirstOrDefault();
            if (postFormat != null)
                formatPostName = postFormat.NameEn;

            switch (formatPostName)
            {
                case "standard":
                    docTemplates.Load(path + "/Templates/format-standard.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadStandard(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates);
                    break;
                case "audio":
                    docTemplates.Load(path + "/Templates/format-audio.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadAudio(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates);
                    break;
                case "video":
                    docTemplates.Load(path + "/Templates/format-video.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadVideo(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates);
                    break;
                case "gallery":
                    docTemplates.Load(path + "/Templates/format-gallery.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadGallery(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates);
                    break;
                case "link":
                    docTemplates.Load(path + "/Templates/format-link.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadLink(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates);
                    break;
                case "quote":
                    docTemplates.Load(path + "/Templates/format-quote.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadQuote(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates);
                    break;
                case "image ":
                    docTemplates.Load(path + "/Templates/format-image.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadimage(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates);
                    break;
                case "status":
                    docTemplates.Load(path + "/Templates/format-status.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadStatus(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates);
                    break;
                default:
                    docTemplates.Load(path + "/Templates/format-standard.html", System.Text.Encoding.UTF8);
                    nodes = CreateHeadStandard(post, categoryAboveClass, categoryAboveName, urlCategory, docTemplates);
                    break;
            }



            //article ايجاد تگ 
            HtmlNode articleNode = HtmlNode.CreateNode("<article class='" + postCol + " hentry " + postClassArticle + postClassCategory + "'></article>");
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
        private HtmlNodeCollection CreateHeadStandard(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates)
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
                        newChild = HtmlNode.CreateNode(@"<div class='post-category'><a href='" + urlCategory + "' class='" + categoryAboveClass + "'>" + categoryAboveName + "</a></div>");
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

        private HtmlNodeCollection CreateHeadAudio(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates)
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
                                                                                "<a href='" + post.Url + "'>" +
                                                                                    "<img width='290' height='170' src='" + post.Image1 + "'" +
                                                                                         "class='attachment-viralnews-catlist-big size-viralnews-catlist-big wp-post-image'" +
                                                                                         "alt='" + post.Subject + "' />" +
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
                                                                            "<a href='Quiz/'" + post.Url + "' class='special-rm-arrow'>" +
                                                                                "<i class='fa fa-arrow-right'></i>" +
                                                                            "</a>" +

                                                                            "<a href='post/post-21.html' class='special-rm-arrow'>" +
                                                                                "<i class='fa fa-arrow-right'></i>" +
                                                                            "</a>" +
                                                                        "</div>" +
                                                                        "<div class='entry-content'>" +
                                                                            "<h3 class='entry-title'>" +
                                                                                "<a href='Quiz/'" + post.PostID + "'>" + post.Subject + "</a>" +
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

        private HtmlNodeCollection CreateHeadGallery(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates)
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
                                                                                    "<img src='" + post.Image3 + "' class='blog-post-img'" +
                                                                                            "alt='" + post.Subject + "' width='665' height='315' />" +
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

        private HtmlNodeCollection CreateHeadimage(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates)
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
                        HtmlNode newChild = HtmlNode.CreateNode(" <div class='post-box' style='background-repeat:no-repeat; background-size:cover; background-image:url(" + post.Image1 + ")'>" +
                                                                    "<div class='bg-overlay' style='background-color:rgba(0,0,0, 0.8)'></div>" +
                                                                    "<div class='entry-cover'>" +
                                                                        "<div class='post-category'>" +
                                                                            "<a href = '" + urlCategory + "' class='" + categoryAboveClass + "'>" + categoryAboveName + "</a>" +
                                                                        "</div>" +
                                                                    "</div>" +
                                                                    "<div class='entry-content'>" +
                                                                        "<h3 class='entry-title'>" +
                                                                            "<a href = '" + post.Url + "' >" + post.Subject + "</a>" +
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

        private HtmlNodeCollection CreateHeadLink(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates)
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
                                                                        "<div class='bg-overlay' style='background-color:rgba(" + post.BackgroundColor + ")'></div>" +
                                                                        "<h3>" +
                                                                           post.Subject +
                                                                        "</h3>" +
                                                                       " <a href = '" + post.Url + "' > " +
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

        private HtmlNodeCollection CreateHeadQuote(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates)
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
                                                                    "<div class='entry-content img-responsive' style='background-image:url(" + post.Image1 + ")'>" +
                                                                        "<div class='bg-overlay' style='background-color:rgba(" + post.BackgroundColor + ")'></div>" +
                                                                        "<blockquote>" +
                                                                            "<h4>" +
                                                                                "<a href = '" + post.Url + "' >" + post.Subject + "</a>" +
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

        private HtmlNodeCollection CreateHeadStatus(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates)
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

        private HtmlNodeCollection CreateHeadVideo(VM_Post post, string categoryAboveClass, string categoryAboveName, string urlCategory, HtmlDocument docTemplates)
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
                                                                        "<a href = 'Video/" + post.Url + "' class='special-rm-arrow'>" +
                                                                            "<i class='fa fa-arrow-right'></i>" +
                                                                        "</a>" +
                                                                    "</div>" +
                                                                    "<div class='entry-content'>" +
                                                                        "<h3 class='entry-title'>" +
                                                                            "<a href = '" + post.Url + "' >" + post.Subject + "</a>" +
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