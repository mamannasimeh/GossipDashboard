//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GossipDashboard.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            this.PostAttributes = new HashSet<PostAttribute>();
            this.PostComments = new HashSet<PostComment>();
            this.UserPosts = new HashSet<UserPost>();
        }
    
        public int PostID { get; set; }
        public string Subject { get; set; }
        public string ContentPost { get; set; }
        public string Url { get; set; }
        public Nullable<int> Views { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public Nullable<int> LikePost { get; set; }
        public Nullable<int> DislikePost { get; set; }
        public Nullable<int> PublishCount { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostAttribute> PostAttributes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostComment> PostComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserPost> UserPosts { get; set; }
    }
}
