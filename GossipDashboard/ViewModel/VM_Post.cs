﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GossipDashboard.Models;

namespace GossipDashboard.ViewModel
{
    public class VM_Post
    {

        public int PostID { get; set; }
        public string Subject { get; set; }
        public string ContentPost { get; set; }
        public Nullable<int> Views { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public Nullable<int> LikePost { get; set; }
        public Nullable<int> DislikePost { get; set; }
        public Nullable<int> ModifyUserID_fk { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string Url { get; set; }
        public Nullable<int> PublishCount { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public int UserID_fk { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Fullname { get;  set; }
        public int CommentCount { get;  set; }
        public string QuotedFrom { get; set; }
        public IQueryable<VM_PubBase> PostCategory { get;  set; }
        public IQueryable<VM_PubBase> PostFormat { get;  set; }
        //public IQueryable<VM_PubBase> LinkToAllPostCategory { get;  set; }
        public IQueryable<VM_PubBase> PostCol { get;  set; }
        public string UrlMP3 { get;  set; }
        public string UrlVideo { get;  set; }
        public string BackgroundColor { get;  set; }
        public string Image3 { get;  set; }
        public string Image4 { get;  set; }
        public string Subject1 { get; internal set; }
        public string Subject2 { get; internal set; }
        public string ContentPost1 { get;  set; }
        public string ContentPost2 { get;  set; }
        public string AboutUser { get;  set; }
        public byte[] ImageUser { get;  set; }
        public string JalaliModifyDate { get;  set; }
    }
}