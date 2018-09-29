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
        /// ساخت آرتیکل های استاندارد وسط صفحه
        /// </summary>
        /// <param name="post">شی پست</param>
        /// <param name="templateCategory">تمپلیتی که قصد داریم از روی آن آرتیکل را بسازیم</param>
        /// <returns></returns>
        internal HtmlNode CreateHeadStandard(VM_Post post, string templateCategory)
        {
            string postFormat = "", postCategory = "";
            string categoryAboveClass = "", categoryAboveName = "";

            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + templateCategory, System.Text.Encoding.UTF8);

            foreach (var item in post.PostFormat)
            {
                postFormat += item.ClassName + " ";
            }
            foreach (var item in post.PostCategory)
            {
                postCategory += " " + item.ClassName + " ";
            }
            foreach (var item in post.LinkToAllPostCategory)
            {
                categoryAboveClass += item.ClassName + " ";
                categoryAboveName += item.NameFa + " ";
            }

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
            //article ايجاد تگ 
            HtmlNode articleNode = HtmlNode.CreateNode("<article class='col-md-4 hentry " + postFormat + postCategory + "'></article>");
            articleNode.AppendChild(nodes.FirstOrDefault());
            return articleNode;
        }


        /// <summary>
        /// ساخت آرتیکل های استاندارد وسط صفحه
        /// </summary>
        /// <param name="post">شی پست</param>
        /// <param name="templateCategory">تمپلیتی که قصد داریم از روی آن آرتیکل را بسازیم</param>
        /// <returns></returns>
        internal HtmlNode CreateHeadAudio(VM_Post post, string templateCategory)
        {
            string postFormat = "", postCategory = "";
            string categoryAboveClass = "", categoryAboveName = "";

            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + templateCategory, System.Text.Encoding.UTF8);

            foreach (var item in post.PostFormat)
            {
                postFormat += item.ClassName + " ";
            }
            foreach (var item in post.PostCategory)
            {
                postCategory += " " + item.ClassName + " ";
            }
            foreach (var item in post.LinkToAllPostCategory)
            {
                categoryAboveClass += item.ClassName + " ";
                categoryAboveName += item.NameFa + " ";
            }

            var nodes = docTemplates.DocumentNode.SelectNodes("//div");
            foreach (var itemNode in nodes)
            {
                var attrs = itemNode.Attributes;
                foreach (var itemAttr in attrs)
                {
                    //post-box پيدا كردن تگ ديو با كلاس 
                    if (itemAttr.Value == "post-box")
                    {
                        HtmlNode oldChild = itemNode.SelectSingleNode("/article[1]/div[1]");
                        HtmlNode newChild = HtmlNode.CreateNode(@"<div class='post-box'>"+
                                                                        "<div class='entry-cover'>"+
                                                                            "<div class='entry-cover'>"+
                                                                                "<a href='"+post.Url+"'>"+
                                                                                    "<img width='290' height='170' src='"+post.Image1+"'"+
                                                                                         "class='attachment-viralnews-catlist-big size-viralnews-catlist-big wp-post-image'"+
                                                                                         "alt='"+post.Subject+"' />"+
                                                                                "</a>"+
                                                                            "</div>"+
                                                                            "<div class='audio-container'>"+
                                                                                "<!--[if lt IE 9]><script>document.createElement('audio');</script><![endif]-->"+
                                                                                "<audio class='wp-audio-shortcode' id='"+post.PostID+"' preload='none' style='width: 100%;' controls='controls'>"+
                                                                                    "<source type='audio/mpeg' src='"+post.Url+"'?_=1' />"+
                                                                                    "<a href='"+post.Url+"'>"+post.Url+"</a>"+
                                                                                "</audio>"+
                                                                            "</div>"+
                                                                            "<div class='post-category'>"+
                                                                                "<a href='Quiz/'"+post.PostID+"' class='"+categoryAboveClass+"'>"+categoryAboveName+" </a>"+
                                                                            "</div>"+
                                                                            "<a href='Quiz/'" + post.PostID + "' class='special-rm-arrow'>" +
                                                                                "<i class='fa fa-arrow-right'></i>"+
                                                                            "</a>"+

                                                                            "<a href='post/post-21.html' class='special-rm-arrow'>"+
                                                                                "<i class='fa fa-arrow-right'></i>"+
                                                                            "</a>"+
                                                                        "</div>"+
                                                                        "<div class='entry-content'>"+
                                                                            "<h3 class='entry-title'>"+
                                                                                "<a href='Quiz/'" + post.PostID + "'>"+post.Subject+"</a>" +
                                                                            "</h3>"+
                                                                        "</div>"+
                                                                        "<div class='entry-footer'>"+
                                                                            "<div class=' row'>" +
                                                                                "<div class='col-md-12'>" +
                                                                                    "<ul class='common-meta'>" +
                                                                                        "<li>" +
                                                                                            "<i class='fa fa-user'></i>" +
                                                                                            "<a href='Admin/'" + post.PostID + "' title=ایجاد شده توسط'"+post.Fullname+"' rel='author'>"+post.Fullname+"</a>" +
                                                                                       " </li>" +

                                                                                        "<li>" +
                                                                                            "<i class='fa fa-comment'></i>" +
                                                                                            "<a href='Comment/'" + post.PostID + "'>"+post.CommentCount+"</a> " +
                                                                                        "</li> " +
                                                                                        "<li class='post-like'>" +
                                                                                            "<a href='#'> " +
                                                                                                "<i class='fa fa-eye'></i>"+post.Views+"" +
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
            //article ايجاد تگ 
            HtmlNode articleNode = HtmlNode.CreateNode("<article class='col-md-4 hentry " + postFormat + postCategory + "'></article>");
            articleNode.AppendChild(nodes.FirstOrDefault());
            return articleNode;
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