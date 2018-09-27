using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}