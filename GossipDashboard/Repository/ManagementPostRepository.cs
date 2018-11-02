using GossipDashboard.Models;
using GossipDashboard.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GossipDashboard.Repository
{
    public class ManagementPostRepository : IRepository<VM_PostManage>
    {
        private GossipSiteEntities context = new GossipSiteEntities();

        public IQueryable<VM_PostManage> ReadPost()
        {
            var postCategoryID = context.PubBases.First(p => p.NameEn == "PostCategory").PubBaseID;
            var postFormatID = context.PubBases.First(p => p.NameEn == "PostFormat").PubBaseID;
            var PostColID = context.PubBases.First(p => p.NameEn == "PostCol").PubBaseID;

            var res = from P in context.Posts
                      join UP in context.UserPosts on P.PostID equals UP.PostID_fk
                      join U in context.Users on UP.UserID_fk equals U.UserID
                      select new VM_PostManage
                      {
                          PostID = P.PostID,
                          ContentPost = P.ContentPost,
                          ContentPost1 = P.ContentPost1,
                          ContentPost2 = P.ContentPost2,
                          DislikePost = P.DislikePost,
                          Image1 = P.Image1,
                          Image2 = P.Image2,
                          Image3 = P.Image3,
                          Image4 = P.Image4,
                          LikePost = P.LikePost,
                          ModifyDate = P.ModifyDate,
                          ModifyUserID = P.ModifyUserID,
                          PublishCount = P.PublishCount,
                          Subject = P.Subject,
                          Subject1 = P.Subject1,
                          Subject2 = P.Subject2,
                          Url = P.Url,
                          UrlMP3 = P.UrlMP3,
                          UrlVideo = P.UrlVideo,
                          Views = P.Views,
                          UserID_fk = UP.UserID_fk,
                          FirstName = U.FirstName,
                          LastName = U.LastName,
                          Fullname = U.FirstName + " " + U.LastName,
                          ImageUser = U.Image,
                          AboutUser = U.AboutUser,
                          BackgroundColor = P.BackgroundColor,
                          QuotedFrom = P.QuotedFrom,
                          CommentCount = context.PostComments.Count(x => x.PostID_fk == P.PostID),
                          PostCategoryName = context.PubBases.FirstOrDefault(p => p.PubBaseID == postCategoryID) == null ? "" : context.PubBases.FirstOrDefault(p => p.PubBaseID == postCategoryID).NameFa,
                          PostFormatName = context.PubBases.FirstOrDefault(p => p.PubBaseID == postFormatID) == null ? "" : context.PubBases.FirstOrDefault(p => p.PubBaseID == postFormatID).NameFa,
                          PostColName = context.PubBases.FirstOrDefault(p => p.PubBaseID == PostColID) == null ? "" : context.PubBases.FirstOrDefault(p => p.PubBaseID == PostColID).NameFa

                      };
            return res;
        }

        public VM_PostManage Add(VM_PostManage vm)
        {
            var entity = new Post()
            {
                PostID = vm.PostID,
                ContentPost = vm.ContentPost,
                ContentPost1 = vm.ContentPost1,
                ContentPost2 = vm.ContentPost2,
                DislikePost = vm.DislikePost,
                Image1 = vm.Image1,
                Image2 = vm.Image2,
                Image3 = vm.Image3,
                Image4 = vm.Image4,
                LikePost = vm.LikePost,
                ModifyDate = vm.ModifyDate,
                ModifyUserID = vm.ModifyUserID,
                PublishCount = vm.PublishCount,
                Subject = vm.Subject,
                Subject1 = vm.Subject1,
                Subject2 = vm.Subject2,
                Url = vm.Url,
                UrlMP3 = vm.UrlMP3,
                UrlVideo = vm.UrlVideo,
                Views = vm.Views,
                BackgroundColor = vm.BackgroundColor,
                QuotedFrom = vm.QuotedFrom,
            };
            context.Posts.Add(entity);
            context.SaveChanges();


            //طبقه بندی پست
            var enntiyCat = new PostAttribute()
            {
                AttributeID_fk = vm.PostCategoryID,
                PostID_fk = entity.PostID,
            };
            context.PostAttributes.Add(enntiyCat);

            //فرمت پست
            var enntiyFormat = new PostAttribute()
            {
                AttributeID_fk = vm.PostFormatID,
                PostID_fk = entity.PostID,
            };
            context.PostAttributes.Add(enntiyFormat);

            //ستون پست
            var enntiyCol = new PostAttribute()
            {
                AttributeID_fk = vm.PostColID,
                PostID_fk = entity.PostID,
            };
            context.PostAttributes.Add(enntiyCol);

            //ایجا یوزر پست ها
            Random r = new Random();
            context.UserPosts.Add(new UserPost()
            {
                ModifyDate = DateTime.Now,
                ModifyUserID = 1,
                PostID_fk = entity.PostID,
                UserID_fk = r.Next(1, 3),
            });

            context.SaveChanges();

            var resultVM = new VM_PostManage()
            {
                PostID = entity.PostID,
                ContentPost = entity.ContentPost,
                ContentPost1 = entity.ContentPost1,
                ContentPost2 = entity.ContentPost2,
                DislikePost = entity.DislikePost,
                Image1 = entity.Image1,
                Image2 = entity.Image2,
                Image3 = entity.Image3,
                Image4 = entity.Image4,
                LikePost = entity.LikePost,
                ModifyDate = entity.ModifyDate,
                ModifyUserID = entity.ModifyUserID,
                PublishCount = entity.PublishCount,
                Subject = entity.Subject,
                Subject1 = entity.Subject1,
                Subject2 = entity.Subject2,
                Url = entity.Url,
                UrlMP3 = entity.UrlMP3,
                UrlVideo = entity.UrlVideo,
                Views = entity.Views,
                BackgroundColor = entity.BackgroundColor,
                QuotedFrom = entity.QuotedFrom,
                PostCategoryID = vm.PostCategoryID,
                PostFormatID = vm.PostFormatID,
                PostColID = vm.PostColID,
            };

            return resultVM;
        }

        public VM_PostManage Update(VM_PostManage entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public VM_PostManage Select(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<VM_PostManage> SelectAll(string condition)
        {
            throw new NotImplementedException();
        }

         
    }
}