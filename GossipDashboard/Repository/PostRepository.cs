using GossipDashboard.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GossipDashboard.Models;

namespace GossipDashboard.Repository
{
    public class PostRepository : IRepository<Post>
    {
        GossipSiteEntities context = new GossipSiteEntities();

        public Post Add(Post entity)
        {
            context.Posts.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public IQueryable<VM_Post> SelectPostUser()
        {
            var res = from P in context.Posts
                       join UP in context.UserPosts on P.PostID equals UP.PostID_fk
                       join U in context.Users on UP.UserID_fk equals U.UserID
                       select new VM_Post
                       {
                           PostID = P.PostID,
                           ContentPost = P.ContentPost,
                           DislikePost = P.DislikePost,
                           Image1 = P.Image1,
                           Image2 = P.Image2,
                           LikePost = P.LikePost,
                           ModifyDate = P.ModifyDate,
                           ModifyUserID = P.ModifyUserID,
                           PublishCount = P.PublishCount,
                           Subject = P.Subject,
                           Url = P.Url,
                           Views = P.Views,
                           UserID_fk = UP.UserID_fk,
                           FirstName = U.FirstName,
                           LastName = U.LastName,
                           Fullname = U.FirstName + " " + U.LastName,
                           CommentCount = context.PostComments.Count(x => x.PostID_fk == P.PostID)
                       };
            return res;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Post Select(int id)
        {
            throw new NotImplementedException();
        }

        public Post Update(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}