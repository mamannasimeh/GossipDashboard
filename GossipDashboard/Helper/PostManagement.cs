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
        /// ساخت آرتیکل های شوخی وسط صفحه
        /// </summary>
        /// <param name="post">شی پست</param>
        /// <param name="templateCategory">تمپلیتی که قصد داریم از روی آن آرتیکل را بسازیم</param>
        /// <returns></returns>
        internal HtmlNode CreateHead(VM_Post post, PostType postType, string templateCategory)
        {
            string categoryClass = "", articleClass = "";
            string categoryName = "";
            var docTemplates = new HtmlDocument();
            docTemplates.Load(path + templateCategory, System.Text.Encoding.UTF8);

            switch (postType)
            {
                case PostType.Quiz:
                     categoryClass = "cat-quiz";
                     categoryName = "شوخی";
                    articleClass = "category-quiz";
                    break;
                case PostType.Cute:
                    categoryClass = "cat-cute";
                    categoryName = "ناز";
                    articleClass = "category-cute category-entertainment";
                    break;
                default:
                    categoryClass = "cat-quiz";
                    categoryName = "شوخی";
                    articleClass = "category-quiz";
                    break;
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
                        newChild = HtmlNode.CreateNode(@"<div class='post-category'><a href='Quiz/Index' class='" + categoryClass + "'>" + categoryName + "</a></div>");
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
            HtmlNode articleNode = HtmlNode.CreateNode("<article class='col-md-4 format-standard hentry " + articleClass + "'></article>");
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