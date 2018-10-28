using GossipDashboard.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GossipDashboard.Models;
using System.IO;

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
            var postCategoryID = context.PubBases.First(p => p.NameEn == "PostCategory").PubBaseID;
            var postFormatID = context.PubBases.First(p => p.NameEn == "PostFormat").PubBaseID;
            var PostColID = context.PubBases.First(p => p.NameEn == "PostCol").PubBaseID;

            var res = from P in context.Posts
                      join UP in context.UserPosts on P.PostID equals UP.PostID_fk
                      join U in context.Users on UP.UserID_fk equals U.UserID
                      select new VM_Post
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
                          PostCategory = context.PostAttributes.Join(context.PubBases, postAttr => postAttr.AttributeID_fk, pBase => pBase.PubBaseID, (postAttr, pBase) =>
                          new VM_PubBase
                          {
                              PubBaseID = pBase.PubBaseID,
                              NameFa = pBase.NameFa,
                              ClassName = pBase.ClassName,
                              AbobeClassName = pBase.AbobeClassName,
                              NameEn = pBase.NameEn,
                              PostID = postAttr.PostID_fk,
                              ParentID = pBase.ParentID
                          }).Where(x => x.PostID == P.PostID && x.ParentID == postCategoryID),
                          PostFormat = context.PostAttributes.Join(context.PubBases, postAttr => postAttr.AttributeID_fk, pBase => pBase.PubBaseID, (postAttr, pBase) =>
                         new VM_PubBase
                         {
                             PubBaseID = pBase.PubBaseID,
                             NameFa = pBase.NameFa,
                             ClassName = pBase.ClassName,
                             AbobeClassName = pBase.AbobeClassName,
                             NameEn = pBase.NameEn,
                             PostID = postAttr.PostID_fk,
                             ParentID = pBase.ParentID
                         }).Where(x => x.PostID == P.PostID && x.ParentID == postFormatID),
                          PostCol = context.PostAttributes.Join(context.PubBases, postAttr => postAttr.AttributeID_fk, pBase => pBase.PubBaseID, (postAttr, pBase) =>
                          new VM_PubBase
                          {
                              PubBaseID = pBase.PubBaseID,
                              NameFa = pBase.NameFa,
                              ClassName = pBase.ClassName,
                              AbobeClassName = pBase.AbobeClassName,
                              NameEn = pBase.NameEn,
                              PostID = postAttr.PostID_fk,
                              ParentID = pBase.ParentID
                          }).Where(x => x.PostID == P.PostID && x.ParentID == PostColID),
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

        public IQueryable<VM_Post> SelectPostByCategory(string postCategory)
        {
            var postCategoryID = context.PubBases.First(p => p.NameEn == "PostCategory").PubBaseID;
            var postFormatID = context.PubBases.First(p => p.NameEn == "PostFormat").PubBaseID;
            //var LinkToAllPostCategoryID = context.PubBases.First(p => p.NameEn == "LinkToAllPostCategory").PubBaseID;
            var PostColID = context.PubBases.First(p => p.NameEn == "PostCol").PubBaseID;

            var res = from P in context.Posts
                      join UP in context.UserPosts on P.PostID equals UP.PostID_fk
                      join U in context.Users on UP.UserID_fk equals U.UserID
                      join postAttr in context.PostAttributes on P.PostID equals postAttr.PostID_fk
                      join PBase in context.PubBases on postAttr.AttributeID_fk equals PBase.PubBaseID
                      where PBase.NameEn == postCategory
                      select new VM_Post
                      {
                          PostID = P.PostID,
                          ContentPost = P.ContentPost,
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
                          Url = P.Url,
                          UrlMP3 = P.UrlMP3,
                          UrlVideo = P.UrlVideo,
                          Views = P.Views,
                          UserID_fk = UP.UserID_fk,
                          FirstName = U.FirstName,
                          LastName = U.LastName,
                          Fullname = U.FirstName + " " + U.LastName,
                          BackgroundColor = P.BackgroundColor,
                          QuotedFrom = P.QuotedFrom,
                          CommentCount = context.PostComments.Count(x => x.PostID_fk == P.PostID),
                          PostCategory = context.PostAttributes.Join(context.PubBases, postAttr => postAttr.AttributeID_fk, pBase => pBase.PubBaseID, (postAttr, pBase) =>
                          new VM_PubBase
                          {
                              PubBaseID = pBase.PubBaseID,
                              NameFa = pBase.NameFa,
                              ClassName = pBase.ClassName,
                              AbobeClassName = pBase.AbobeClassName,
                              NameEn = pBase.NameEn,
                              PostID = postAttr.PostID_fk,
                              ParentID = pBase.ParentID
                          }).Where(x => x.PostID == P.PostID && x.ParentID == postCategoryID),
                          PostFormat = context.PostAttributes.Join(context.PubBases, postAttr => postAttr.AttributeID_fk, pBase => pBase.PubBaseID, (postAttr, pBase) =>
                         new VM_PubBase
                         {
                             PubBaseID = pBase.PubBaseID,
                             NameFa = pBase.NameFa,
                             ClassName = pBase.ClassName,
                             AbobeClassName = pBase.AbobeClassName,
                             NameEn = pBase.NameEn,
                             PostID = postAttr.PostID_fk,
                             ParentID = pBase.ParentID
                         }).Where(x => x.PostID == P.PostID && x.ParentID == postFormatID),
                          PostCol = context.PostAttributes.Join(context.PubBases, postAttr => postAttr.AttributeID_fk, pBase => pBase.PubBaseID, (postAttr, pBase) =>
                         new VM_PubBase
                         {
                             PubBaseID = pBase.PubBaseID,
                             NameFa = pBase.NameFa,
                             ClassName = pBase.ClassName,
                             AbobeClassName = pBase.AbobeClassName,
                             NameEn = pBase.NameEn,
                             PostID = postAttr.PostID_fk,
                             ParentID = pBase.ParentID
                         }).Where(x => x.PostID == P.PostID && x.ParentID == PostColID),
                      };
            return res;
        }

        public IQueryable<Post> SelectAll(string condition)
        {
            throw new NotImplementedException();
        }

        //ایجاد پست ها از جدول پست تمپروری به جدول پست
        public bool CreatePost()
        {
            string Index1, Index2, Index3;
            int count = 0;
            var tempPost = context.PostTemperories.Where(p => p.IsCreatedPost != true).ToList();
            foreach (var item in tempPost)
            {
                //قبلا این پست ایجاد نشده باشد
                var isExist = context.Posts.FirstOrDefault(p => p.Subject == item.Subject);

               // count = item.ContentPost.Split('.').Count();
                if (isExist == null && item.Subject.Trim().Length > 3)
                {
                    //Index1 = item.ContentPost.Split('.').Skip((int)(count / 4)).LastOrDefault();
                    //Index2 = item.ContentPost.Split('.').Skip((int)(count / 3) * 2 + 1).LastOrDefault();
                    //Index3 = item.ContentPost.Split('.').Skip(count - 1).LastOrDefault();

                    //ایجاد پست
                    var entityPost = context.Posts.Add(new Post()
                    {
                        BackgroundColor = item.BackgroundColor,
                        ContentPost = item.ContentPost,
                        //ContentPost1 = item.ContentPost.Substring(item.ContentPost.IndexOf(Index1) + 1, item.ContentPost.IndexOf(Index2)),
                        //ContentPost2 = item.ContentPost2.Substring(item.ContentPost.IndexOf(Index2) + 1, item.ContentPost.IndexOf(Index3)),
                        DislikePost = item.DislikePost,
                        Image1 = item.Image1,
                        Image2 = item.Image2,
                        Image3 = item.Image3,
                        Image4 = item.Image4,
                        LikePost = item.LikePost,
                        ModifyDate = DateTime.Now,
                        ModifyUserID = 1,
                        PublishCount = 1,
                        QuotedFrom = item.QuotedFrom,
                        Url = item.Url,
                        UrlMP3 = item.UrlMP3,
                        UrlVideo = item.UrlVideo,
                        Subject = item.Subject,
                        Subject1 = item.Subject1,
                        Subject2 = item.Subject2,
                        Views = 0,
                    });
                    context.SaveChanges();

                    //ایجاد اتربیوت ها فرمت پست ها
                    var attrID = context.PubBases.FirstOrDefault(p => p.NameEn == "standard").PubBaseID;
                    if (entityPost.UrlMP3 != null)
                        attrID = context.PubBases.FirstOrDefault(p => p.NameEn == "audio").PubBaseID;
                    else if (entityPost.UrlVideo != null)
                        attrID = context.PubBases.FirstOrDefault(p => p.NameEn == "video").PubBaseID;

                    context.PostAttributes.Add(new PostAttribute()
                    {
                        PostID_fk = entityPost.PostID,
                        AttributeID_fk = attrID
                    });

                    //ایجاد اتربیوت ها طبقه بندي پست ها
                    attrID = context.PubBases.FirstOrDefault(p => p.NameEn == "entertainment").PubBaseID;
                    context.PostAttributes.Add(new PostAttribute()
                    {
                        PostID_fk = entityPost.PostID,
                        AttributeID_fk = attrID
                    });

                    //ایجا یوزر پست ها
                    Random r = new Random();
                    context.UserPosts.Add(new UserPost()
                    {
                        ModifyDate = DateTime.Now,
                        ModifyUserID = 1,
                        PostID_fk = entityPost.PostID,
                        UserID_fk = r.Next(1, 2),
                    });

                    context.SaveChanges();
                }
            }



            return true;
        }
    }
}