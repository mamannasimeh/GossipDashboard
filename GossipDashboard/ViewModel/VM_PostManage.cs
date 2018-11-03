using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GossipDashboard.Models;

namespace GossipDashboard.ViewModel
{
    public class VM_PostManage
    {
        [DisplayName("شناسایی")]
        public int PostID { get; set; }
        [DisplayName("عنوان")]
        public string Subject { get; set; }
        [DisplayName("محتوا")]
        public string ContentPost { get; set; }
        [DisplayName("بازدید")]
        public Nullable<int> Views { get; set; }
        [DisplayName("تصویر 1")]
        public string Image1 { get; set; }
        [DisplayName("تصویر 2")]
        public string Image2 { get; set; }
        [DisplayName("Like")]
        public Nullable<int> LikePost { get; set; }
        [DisplayName("Dislike")]
        public Nullable<int> DislikePost { get; set; }
        [DisplayName("")]
        public Nullable<System.DateTime> ModifyDate { get; set; }
        [DisplayName("")]
        public string Url { get; set; }
        [DisplayName("")]
        public Nullable<int> PublishCount { get; set; }
        [DisplayName("شناسایی کاربر")]
        public Nullable<int> ModifyUserID { get; set; }

        [DisplayName("نام")]
        public string FirstName { get;  set; }
        [DisplayName("نام خانوادگی")]
        public string LastName { get;  set; }
        [DisplayName("نویسنده")]
        public string Fullname { get;  set; }
        [DisplayName("کامنت")]
        public int CommentCount { get;  set; }
        [DisplayName("نقل قول شده از")]
        public string QuotedFrom { get; set; }

        [DisplayName("UrlMP3")]
        public string UrlMP3 { get;  set; }
        [DisplayName("UrlVideo")]
        public string UrlVideo { get;  set; }
        [DisplayName("رنگ پس زمینه")]
        public string BackgroundColor { get;  set; }
        [DisplayName("تصویر 3")]
        public string Image3 { get;  set; }

        [DisplayName("تصویر 4")]
        public string Image4 { get;  set; }

        [DisplayName("عنوان 1 ")]
        public string Subject1 { get;  set; }

        [DisplayName("عنوان 2")]
        public string Subject2 { get;  set; }

        [DisplayName("محتوا 1")]
        public string ContentPost1 { get;  set; }

        [DisplayName("محتوا 2")]
        public string ContentPost2 { get;  set; }

        [DisplayName("درباره نویسنده")]
        public string AboutUser { get;  set; }

        [DisplayName("تصویر نویسنده")]
        public byte[] ImageUser { get;  set; }

        [DisplayName("تاریخ")]
        public string JalaliModifyDate { get;  set; }

        [DisplayName("طبقه بندی")]
        public string PostCategoryName { get; set; }
        [DisplayName("فرمت")]
        public string PostFormatName { get; set; }
        [DisplayName("تعداد ستون")]
        public string PostColName { get; set; }


        [DisplayName("طبقه بندی")]
        public int PostCategoryID { get; set; }
        [DisplayName("فرمت")]
        public int PostFormatID { get; set; }
        [DisplayName("تعداد ستون")]
        public int PostColID { get; set; }
        public int UserID_fk { get;  set; }
        public string ContentPostSmall { get;  set; }
        public string ContentPost1Small { get;  set; }
        public string ContentPost2Small { get;  set; }
        public string SubjectSmall { get;  set; }
        public string Subject1Small { get;  set; }
        public string Subject2Small { get;  set; }
    }
}