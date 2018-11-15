using GossipDashboard.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GossipDashboard.Models;
using System.IO;
using System.Data.Entity;
using AutoMapper;

namespace GossipDashboard.Repository
{
    public class PostRepository : IRepository<Post>
    {
        private GossipSiteEntities context = new GossipSiteEntities();

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
                          Subject1 = P.Subject1,
                          SubSubject1_1 = P.SubSubject1_1,
                          SubSubject1_2 = P.SubSubject1_2,
                          ContentPost1_1 = P.ContentPost1_1,
                          ContentPost1_2 = P.ContentPost1_2,
                          ContentPost1_3 = P.ContentPost1_3,
                          ContentPost1_4 = P.ContentPost1_4,
                          ContentPost1_5 = P.ContentPost1_5,
                          Image1_1 = P.Image1_1,
                          Image1_2 = P.Image1_2,
                          Image1_3 = P.Image1_3,
                          Subject2 = P.Subject2,
                          SubSubject2_1 = P.SubSubject2_1,
                          SubSubject2_2 = P.SubSubject2_2,
                          ContentPost2_1 = P.ContentPost2_1,
                          ContentPost2_2 = P.ContentPost2_2,
                          ContentPost2_3 = P.ContentPost2_3,
                          ContentPost2_4 = P.ContentPost2_4,
                          ContentPost2_5 = P.ContentPost2_5,
                          Image2_1 = P.Image2_1,
                          Image2_2 = P.Image2_2,
                          Image2_3 = P.Image2_3,
                          Subject3 = P.Subject3,
                          SubSubject3_1 = P.SubSubject3_1,
                          SubSubject3_2 = P.SubSubject3_2,
                          ContentPost3_1 = P.ContentPost3_1,
                          ContentPost3_2 = P.ContentPost3_2,
                          ContentPost3_3 = P.ContentPost3_3,
                          ContentPost3_4 = P.ContentPost3_4,
                          ContentPost3_5 = P.ContentPost3_5,
                          Image3_1 = P.Image3_1,
                          Image3_2 = P.Image3_2,
                          Image3_3 = P.Image3_3,
                          Subject4 = P.Subject4,
                          SubSubject4_1 = P.SubSubject4_1,
                          SubSubject4_2 = P.SubSubject4_2,
                          ContentPost4_1 = P.ContentPost4_1,
                          ContentPost4_2 = P.ContentPost4_2,
                          ContentPost4_3 = P.ContentPost4_3,
                          ContentPost4_4 = P.ContentPost4_4,
                          ContentPost4_5 = P.ContentPost4_5,
                          Image4_1 = P.Image4_1,
                          Image4_2 = P.Image4_2,
                          Image4_3 = P.Image4_3,
                          Subject5 = P.Subject5,
                          SubSubject5_1 = P.SubSubject5_1,
                          SubSubject5_2 = P.SubSubject5_2,
                          ContentPost5_1 = P.ContentPost5_1,
                          ContentPost5_2 = P.ContentPost5_2,
                          ContentPost5_3 = P.ContentPost5_3,
                          ContentPost5_4 = P.ContentPost5_4,
                          ContentPost5_5 = P.ContentPost5_5,
                          Image5_1 = P.Image5_1,
                          Image5_2 = P.Image5_2,
                          Image5_3 = P.Image5_3,
                          Subject6 = P.Subject6,
                          SubSubject6_1 = P.SubSubject6_1,
                          SubSubject6_2 = P.SubSubject6_2,
                          ContentPost6_1 = P.ContentPost6_1,
                          ContentPost6_2 = P.ContentPost6_2,
                          ContentPost6_3 = P.ContentPost6_3,
                          ContentPost6_4 = P.ContentPost6_4,
                          ContentPost6_5 = P.ContentPost6_5,
                          Image6_1 = P.Image6_1,
                          Image6_2 = P.Image6_2,
                          Image6_3 = P.Image6_3,
                          Subject7 = P.Subject7,
                          SubSubject7_1 = P.SubSubject7_1,
                          SubSubject7_2 = P.SubSubject7_2,
                          ContentPost7_1 = P.ContentPost7_1,
                          ContentPost7_2 = P.ContentPost7_2,
                          ContentPost7_3 = P.ContentPost7_3,
                          ContentPost7_4 = P.ContentPost7_3,
                          ContentPost7_5 = P.ContentPost7_5,
                          Image7_1 = P.Image7_1,
                          Image7_2 = P.Image7_2,
                          Image7_3 = P.Image7_3,
                          Subject8 = P.Subject8,
                          SubSubject8_1 = P.SubSubject8_1,
                          SubSubject8_2 = P.SubSubject8_2,
                          ContentPost8_1 = P.ContentPost8_1,
                          ContentPost8_2 = P.ContentPost8_2,
                          ContentPost8_3 = P.ContentPost8_3,
                          ContentPost8_4 = P.ContentPost8_4,
                          ContentPost8_5 = P.ContentPost8_5,
                          Image8_1 = P.Image8_1,
                          Image8_2 = P.Image8_2,
                          Image8_3 = P.Image8_3,
                          Subject9 = P.Subject9,
                          SubSubject9_1 = P.SubSubject9_1,
                          SubSubject9_2 = P.SubSubject9_2,
                          ContentPost9_1 = P.ContentPost9_1,
                          ContentPost9_2 = P.ContentPost9_2,
                          ContentPost9_3 = P.ContentPost9_3,
                          ContentPost9_4 = P.ContentPost9_4,
                          ContentPost9_5 = P.ContentPost9_5,
                          Image9_1 = P.Image9_1,
                          Image9_2 = P.Image9_2,
                          Image9_3 = P.Image9_3,
                          Subject10 = P.Subject10,
                          SubSubject10_1 = P.SubSubject10_1,
                          SubSubject10_2 = P.SubSubject10_2,
                          ContentPost10_1 = P.ContentPost10_1,
                          ContentPost10_2 = P.ContentPost10_2,
                          ContentPost10_3 = P.ContentPost10_3,
                          ContentPost10_4 = P.ContentPost10_4,
                          ContentPost10_5 = P.ContentPost10_5,
                          Image10_1 = P.Image10_1,
                          Image10_2 = P.Image10_2,
                          Image10_3 = P.Image10_3,
                          Subject11 = P.Subject11,
                          SubSubject11_1 = P.SubSubject11_1,
                          SubSubject11_2 = P.SubSubject11_2,
                          ContentPost11_1 = P.ContentPost11_1,
                          ContentPost11_2 = P.ContentPost11_2,
                          ContentPost11_3 = P.ContentPost11_3,
                          ContentPost11_4 = P.ContentPost11_4,
                          ContentPost11_5 = P.ContentPost11_5,
                          Image11_1 = P.Image11_1,
                          Image11_2 = P.Image11_2,
                          Image11_3 = P.Image11_3,
                          Subject12 = P.Subject12,
                          SubSubject12_1 = P.SubSubject12_1,
                          SubSubject12_2 = P.SubSubject12_2,
                          ContentPost12_1 = P.ContentPost12_1,
                          ContentPost12_2 = P.ContentPost12_2,
                          ContentPost12_3 = P.ContentPost12_3,
                          ContentPost12_4 = P.ContentPost12_4,
                          ContentPost12_5 = P.ContentPost12_5,
                          Image12_1 = P.Image12_1,
                          Image12_2 = P.Image12_2,
                          Image12_3 = P.Image12_3,
                          Subject13 = P.Subject13,
                          SubSubject13_1 = P.SubSubject13_1,
                          SubSubject13_2 = P.SubSubject13_2,
                          ContentPost13_1 = P.ContentPost13_1,
                          ContentPost13_2 = P.ContentPost13_2,
                          ContentPost13_3 = P.ContentPost13_3,
                          ContentPost13_4 = P.ContentPost13_4,
                          ContentPost13_5 = P.ContentPost13_5,
                          Image13_1 = P.Image13_1,
                          Image13_2 = P.Image13_2,
                          Image13_3 = P.Image13_3,
                          Subject14 = P.Subject14,
                          SubSubject14_1 = P.SubSubject14_1,
                          SubSubject14_2 = P.SubSubject14_2,
                          ContentPost14_1 = P.ContentPost14_1,
                          ContentPost14_2 = P.ContentPost14_2,
                          ContentPost14_3 = P.ContentPost14_3,
                          ContentPost14_4 = P.ContentPost14_4,
                          ContentPost14_5 = P.ContentPost14_5,
                          Image14_1 = P.Image14_1,
                          Image14_2 = P.Image14_2,
                          Image14_3 = P.Image14_3,
                          Subject15 = P.Subject15,
                          SubSubject15_1 = P.SubSubject15_1,
                          SubSubject15_2 = P.SubSubject15_2,
                          ContentPost15_1 = P.ContentPost15_1,
                          ContentPost15_2 = P.ContentPost15_2,
                          ContentPost15_3 = P.ContentPost15_3,
                          ContentPost15_4 = P.ContentPost15_4,
                          ContentPost15_5 = P.ContentPost15_5,
                          Image15_1 = P.Image15_1,
                          Image15_2 = P.Image15_2,
                          Image15_3 = P.Image15_3,
                          Subject16 = P.Subject16,
                          SubSubject16_1 = P.SubSubject16_1,
                          SubSubject16_2 = P.SubSubject16_2,
                          ContentPost16_1 = P.ContentPost16_1,
                          ContentPost16_2 = P.ContentPost16_2,
                          ContentPost16_3 = P.ContentPost16_3,
                          ContentPost16_4 = P.ContentPost16_4,
                          ContentPost16_5 = P.ContentPost16_5,
                          Image16_1 = P.Image16_1,
                          Image16_2 = P.Image16_2,
                          Image16_3 = P.Image16_3,
                          Subject17 = P.Subject17,
                          SubSubject17_1 = P.SubSubject17_1,
                          SubSubject17_2 = P.SubSubject17_2,
                          ContentPost17_1 = P.ContentPost17_1,
                          ContentPost17_2 = P.ContentPost17_2,
                          ContentPost17_3 = P.ContentPost17_3,
                          ContentPost17_4 = P.ContentPost17_4,
                          ContentPost17_5 = P.ContentPost17_5,
                          Image17_1 = P.Image17_1,
                          Image17_2 = P.Image17_2,
                          Image17_3 = P.Image17_3,
                          Subject18 = P.Subject18,
                          SubSubject18_1 = P.SubSubject18_1,
                          SubSubject18_2 = P.SubSubject18_2,
                          ContentPost18_1 = P.ContentPost18_1,
                          ContentPost18_2 = P.ContentPost18_2,
                          ContentPost18_3 = P.ContentPost18_3,
                          ContentPost18_4 = P.ContentPost18_4,
                          ContentPost18_5 = P.ContentPost18_5,
                          Image18_1 = P.Image18_1,
                          Image18_2 = P.Image18_2,
                          Image18_3 = P.Image18_3,
                          Subject19 = P.Subject19,
                          SubSubject19_1 = P.SubSubject19_1,
                          SubSubject19_2 = P.SubSubject19_2,
                          ContentPost19_1 = P.ContentPost19_1,
                          ContentPost19_2 = P.ContentPost19_2,
                          ContentPost19_3 = P.ContentPost19_3,
                          ContentPost19_4 = P.ContentPost19_4,
                          ContentPost19_5 = P.ContentPost19_5,
                          Image19_1 = P.Image19_1,
                          Image19_2 = P.Image19_2,
                          Image19_3 = P.Image19_3,
                          Subject20 = P.Subject20,
                          SubSubject20_1 = P.SubSubject20_1,
                          SubSubject20_2 = P.SubSubject20_2,
                          ContentPost20_1 = P.ContentPost20_1,
                          ContentPost20_2 = P.ContentPost20_2,
                          ContentPost20_3 = P.ContentPost20_3,
                          ContentPost20_4 = P.ContentPost20_4,
                          ContentPost20_5 = P.ContentPost20_5,
                          Image20_1 = P.Image20_1,
                          Image20_2 = P.Image20_2,
                          Image20_3 = P.Image20_3,
                          QuotedFrom = P.QuotedFrom,
                          Url = P.Url,
                          UrlMP3 = P.UrlMP3,
                          UrlVideo = P.UrlVideo,
                          Views = P.Views,
                          LikePost = P.LikePost,
                          DislikePost = P.DislikePost,
                          PublishCount = P.PublishCount,
                          BackgroundColor = P.BackgroundColor,
                          ModifyUserID = P.ModifyUserID,
                          ModifyDate = P.ModifyDate,
                          IsCreatedPost = P.IsCreatedPost,
                          Cat1 = P.Cat1,
                          Cat2 = P.Cat2,
                          Cat3 = P.Cat3,
                          Tag1 = P.Tag1,
                          Tag2 = P.Tag2,
                          Tag3 = P.Tag3,
                          Tag4 = P.Tag4,
                          Tag5 = P.Tag5,
                          Tag6 = P.Tag6,
                          Tag7 = P.Tag7,
                          Tag8 = P.Tag8,
                          Tag9 = P.Tag9,
                          Tag10 = P.Tag10,
                          FootCategory = P.FootCategory,
                          DateTimePost = P.DateTimePost,
                          ContentPost1_6 = P.ContentPost1_6,
                          ContentPost1_7 = P.ContentPost1_7,
                          UserID_fk = UP.UserID_fk,
                          FirstName = U.FirstName,
                          LastName = U.LastName,
                          Fullname = U.FirstName + " " + U.LastName,
                          ImageUser = U.Image,
                          AboutUser = U.AboutUser,
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

        internal void UpdatePostViews(int postID)
        {
            var entity = context.Posts.First(p => p.PostID == postID);
            entity.Views = (entity.Views ?? 0) + 1;
            context.Posts.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Post Delete(int id)
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
                          Subject1 = P.Subject1,
                          SubSubject1_1 = P.SubSubject1_1,
                          SubSubject1_2 = P.SubSubject1_2,
                          ContentPost1_1 = P.ContentPost1_1,
                          ContentPost1_2 = P.ContentPost1_2,
                          ContentPost1_3 = P.ContentPost1_3,
                          ContentPost1_4 = P.ContentPost1_4,
                          ContentPost1_5 = P.ContentPost1_5,
                          Image1_1 = P.Image1_1,
                          Image1_2 = P.Image1_2,
                          Image1_3 = P.Image1_3,
                          Subject2 = P.Subject2,
                          SubSubject2_1 = P.SubSubject2_1,
                          SubSubject2_2 = P.SubSubject2_2,
                          ContentPost2_1 = P.ContentPost2_1,
                          ContentPost2_2 = P.ContentPost2_2,
                          ContentPost2_3 = P.ContentPost2_3,
                          ContentPost2_4 = P.ContentPost2_4,
                          ContentPost2_5 = P.ContentPost2_5,
                          Image2_1 = P.Image2_1,
                          Image2_2 = P.Image2_2,
                          Image2_3 = P.Image2_3,
                          Subject3 = P.Subject3,
                          SubSubject3_1 = P.SubSubject3_1,
                          SubSubject3_2 = P.SubSubject3_2,
                          ContentPost3_1 = P.ContentPost3_1,
                          ContentPost3_2 = P.ContentPost3_2,
                          ContentPost3_3 = P.ContentPost3_3,
                          ContentPost3_4 = P.ContentPost3_4,
                          ContentPost3_5 = P.ContentPost3_5,
                          Image3_1 = P.Image3_1,
                          Image3_2 = P.Image3_2,
                          Image3_3 = P.Image3_3,
                          Subject4 = P.Subject4,
                          SubSubject4_1 = P.SubSubject4_1,
                          SubSubject4_2 = P.SubSubject4_2,
                          ContentPost4_1 = P.ContentPost4_1,
                          ContentPost4_2 = P.ContentPost4_2,
                          ContentPost4_3 = P.ContentPost4_3,
                          ContentPost4_4 = P.ContentPost4_4,
                          ContentPost4_5 = P.ContentPost4_5,
                          Image4_1 = P.Image4_1,
                          Image4_2 = P.Image4_2,
                          Image4_3 = P.Image4_3,
                          Subject5 = P.Subject5,
                          SubSubject5_1 = P.SubSubject5_1,
                          SubSubject5_2 = P.SubSubject5_2,
                          ContentPost5_1 = P.ContentPost5_1,
                          ContentPost5_2 = P.ContentPost5_2,
                          ContentPost5_3 = P.ContentPost5_3,
                          ContentPost5_4 = P.ContentPost5_4,
                          ContentPost5_5 = P.ContentPost5_5,
                          Image5_1 = P.Image5_1,
                          Image5_2 = P.Image5_2,
                          Image5_3 = P.Image5_3,
                          Subject6 = P.Subject6,
                          SubSubject6_1 = P.SubSubject6_1,
                          SubSubject6_2 = P.SubSubject6_2,
                          ContentPost6_1 = P.ContentPost6_1,
                          ContentPost6_2 = P.ContentPost6_2,
                          ContentPost6_3 = P.ContentPost6_3,
                          ContentPost6_4 = P.ContentPost6_4,
                          ContentPost6_5 = P.ContentPost6_5,
                          Image6_1 = P.Image6_1,
                          Image6_2 = P.Image6_2,
                          Image6_3 = P.Image6_3,
                          Subject7 = P.Subject7,
                          SubSubject7_1 = P.SubSubject7_1,
                          SubSubject7_2 = P.SubSubject7_2,
                          ContentPost7_1 = P.ContentPost7_1,
                          ContentPost7_2 = P.ContentPost7_2,
                          ContentPost7_3 = P.ContentPost7_3,
                          ContentPost7_4 = P.ContentPost7_3,
                          ContentPost7_5 = P.ContentPost7_5,
                          Image7_1 = P.Image7_1,
                          Image7_2 = P.Image7_2,
                          Image7_3 = P.Image7_3,
                          Subject8 = P.Subject8,
                          SubSubject8_1 = P.SubSubject8_1,
                          SubSubject8_2 = P.SubSubject8_2,
                          ContentPost8_1 = P.ContentPost8_1,
                          ContentPost8_2 = P.ContentPost8_2,
                          ContentPost8_3 = P.ContentPost8_3,
                          ContentPost8_4 = P.ContentPost8_4,
                          ContentPost8_5 = P.ContentPost8_5,
                          Image8_1 = P.Image8_1,
                          Image8_2 = P.Image8_2,
                          Image8_3 = P.Image8_3,
                          Subject9 = P.Subject9,
                          SubSubject9_1 = P.SubSubject9_1,
                          SubSubject9_2 = P.SubSubject9_2,
                          ContentPost9_1 = P.ContentPost9_1,
                          ContentPost9_2 = P.ContentPost9_2,
                          ContentPost9_3 = P.ContentPost9_3,
                          ContentPost9_4 = P.ContentPost9_4,
                          ContentPost9_5 = P.ContentPost9_5,
                          Image9_1 = P.Image9_1,
                          Image9_2 = P.Image9_2,
                          Image9_3 = P.Image9_3,
                          Subject10 = P.Subject10,
                          SubSubject10_1 = P.SubSubject10_1,
                          SubSubject10_2 = P.SubSubject10_2,
                          ContentPost10_1 = P.ContentPost10_1,
                          ContentPost10_2 = P.ContentPost10_2,
                          ContentPost10_3 = P.ContentPost10_3,
                          ContentPost10_4 = P.ContentPost10_4,
                          ContentPost10_5 = P.ContentPost10_5,
                          Image10_1 = P.Image10_1,
                          Image10_2 = P.Image10_2,
                          Image10_3 = P.Image10_3,
                          Subject11 = P.Subject11,
                          SubSubject11_1 = P.SubSubject11_1,
                          SubSubject11_2 = P.SubSubject11_2,
                          ContentPost11_1 = P.ContentPost11_1,
                          ContentPost11_2 = P.ContentPost11_2,
                          ContentPost11_3 = P.ContentPost11_3,
                          ContentPost11_4 = P.ContentPost11_4,
                          ContentPost11_5 = P.ContentPost11_5,
                          Image11_1 = P.Image11_1,
                          Image11_2 = P.Image11_2,
                          Image11_3 = P.Image11_3,
                          Subject12 = P.Subject12,
                          SubSubject12_1 = P.SubSubject12_1,
                          SubSubject12_2 = P.SubSubject12_2,
                          ContentPost12_1 = P.ContentPost12_1,
                          ContentPost12_2 = P.ContentPost12_2,
                          ContentPost12_3 = P.ContentPost12_3,
                          ContentPost12_4 = P.ContentPost12_4,
                          ContentPost12_5 = P.ContentPost12_5,
                          Image12_1 = P.Image12_1,
                          Image12_2 = P.Image12_2,
                          Image12_3 = P.Image12_3,
                          Subject13 = P.Subject13,
                          SubSubject13_1 = P.SubSubject13_1,
                          SubSubject13_2 = P.SubSubject13_2,
                          ContentPost13_1 = P.ContentPost13_1,
                          ContentPost13_2 = P.ContentPost13_2,
                          ContentPost13_3 = P.ContentPost13_3,
                          ContentPost13_4 = P.ContentPost13_4,
                          ContentPost13_5 = P.ContentPost13_5,
                          Image13_1 = P.Image13_1,
                          Image13_2 = P.Image13_2,
                          Image13_3 = P.Image13_3,
                          Subject14 = P.Subject14,
                          SubSubject14_1 = P.SubSubject14_1,
                          SubSubject14_2 = P.SubSubject14_2,
                          ContentPost14_1 = P.ContentPost14_1,
                          ContentPost14_2 = P.ContentPost14_2,
                          ContentPost14_3 = P.ContentPost14_3,
                          ContentPost14_4 = P.ContentPost14_4,
                          ContentPost14_5 = P.ContentPost14_5,
                          Image14_1 = P.Image14_1,
                          Image14_2 = P.Image14_2,
                          Image14_3 = P.Image14_3,
                          Subject15 = P.Subject15,
                          SubSubject15_1 = P.SubSubject15_1,
                          SubSubject15_2 = P.SubSubject15_2,
                          ContentPost15_1 = P.ContentPost15_1,
                          ContentPost15_2 = P.ContentPost15_2,
                          ContentPost15_3 = P.ContentPost15_3,
                          ContentPost15_4 = P.ContentPost15_4,
                          ContentPost15_5 = P.ContentPost15_5,
                          Image15_1 = P.Image15_1,
                          Image15_2 = P.Image15_2,
                          Image15_3 = P.Image15_3,
                          Subject16 = P.Subject16,
                          SubSubject16_1 = P.SubSubject16_1,
                          SubSubject16_2 = P.SubSubject16_2,
                          ContentPost16_1 = P.ContentPost16_1,
                          ContentPost16_2 = P.ContentPost16_2,
                          ContentPost16_3 = P.ContentPost16_3,
                          ContentPost16_4 = P.ContentPost16_4,
                          ContentPost16_5 = P.ContentPost16_5,
                          Image16_1 = P.Image16_1,
                          Image16_2 = P.Image16_2,
                          Image16_3 = P.Image16_3,
                          Subject17 = P.Subject17,
                          SubSubject17_1 = P.SubSubject17_1,
                          SubSubject17_2 = P.SubSubject17_2,
                          ContentPost17_1 = P.ContentPost17_1,
                          ContentPost17_2 = P.ContentPost17_2,
                          ContentPost17_3 = P.ContentPost17_3,
                          ContentPost17_4 = P.ContentPost17_4,
                          ContentPost17_5 = P.ContentPost17_5,
                          Image17_1 = P.Image17_1,
                          Image17_2 = P.Image17_2,
                          Image17_3 = P.Image17_3,
                          Subject18 = P.Subject18,
                          SubSubject18_1 = P.SubSubject18_1,
                          SubSubject18_2 = P.SubSubject18_2,
                          ContentPost18_1 = P.ContentPost18_1,
                          ContentPost18_2 = P.ContentPost18_2,
                          ContentPost18_3 = P.ContentPost18_3,
                          ContentPost18_4 = P.ContentPost18_4,
                          ContentPost18_5 = P.ContentPost18_5,
                          Image18_1 = P.Image18_1,
                          Image18_2 = P.Image18_2,
                          Image18_3 = P.Image18_3,
                          Subject19 = P.Subject19,
                          SubSubject19_1 = P.SubSubject19_1,
                          SubSubject19_2 = P.SubSubject19_2,
                          ContentPost19_1 = P.ContentPost19_1,
                          ContentPost19_2 = P.ContentPost19_2,
                          ContentPost19_3 = P.ContentPost19_3,
                          ContentPost19_4 = P.ContentPost19_4,
                          ContentPost19_5 = P.ContentPost19_5,
                          Image19_1 = P.Image19_1,
                          Image19_2 = P.Image19_2,
                          Image19_3 = P.Image19_3,
                          Subject20 = P.Subject20,
                          SubSubject20_1 = P.SubSubject20_1,
                          SubSubject20_2 = P.SubSubject20_2,
                          ContentPost20_1 = P.ContentPost20_1,
                          ContentPost20_2 = P.ContentPost20_2,
                          ContentPost20_3 = P.ContentPost20_3,
                          ContentPost20_4 = P.ContentPost20_4,
                          ContentPost20_5 = P.ContentPost20_5,
                          Image20_1 = P.Image20_1,
                          Image20_2 = P.Image20_2,
                          Image20_3 = P.Image20_3,
                          QuotedFrom = P.QuotedFrom,
                          Url = P.Url,
                          UrlMP3 = P.UrlMP3,
                          UrlVideo = P.UrlVideo,
                          Views = P.Views,
                          LikePost = P.LikePost,
                          DislikePost = P.DislikePost,
                          PublishCount = P.PublishCount,
                          BackgroundColor = P.BackgroundColor,
                          ModifyUserID = P.ModifyUserID,
                          ModifyDate = P.ModifyDate,
                          IsCreatedPost = P.IsCreatedPost,
                          Cat1 = P.Cat1,
                          Cat2 = P.Cat2,
                          Cat3 = P.Cat3,
                          Tag1 = P.Tag1,
                          Tag2 = P.Tag2,
                          Tag3 = P.Tag3,
                          Tag4 = P.Tag4,
                          Tag5 = P.Tag5,
                          Tag6 = P.Tag6,
                          Tag7 = P.Tag7,
                          Tag8 = P.Tag8,
                          Tag9 = P.Tag9,
                          Tag10 = P.Tag10,
                          FootCategory = P.FootCategory,
                          DateTimePost = P.DateTimePost,
                          ContentPost1_6 = P.ContentPost1_6,
                          ContentPost1_7 = P.ContentPost1_7,
                          Fullname = U.FirstName + " " + U.LastName,
                          UserID_fk = UP.UserID_fk,
                          FirstName = U.FirstName,
                          LastName = U.LastName,
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
        //public IQueryable<VM_Post> SelectPostByCategory(string postCategory)
        //{
        //    var postCategoryID = context.PubBases.First(p => p.NameEn == "PostCategory").PubBaseID;
        //    var postFormatID = context.PubBases.First(p => p.NameEn == "PostFormat").PubBaseID;

        //    //var LinkToAllPostCategoryID = context.PubBases.First(p => p.NameEn == "LinkToAllPostCategory").PubBaseID;
        //    var PostColID = context.PubBases.First(p => p.NameEn == "PostCol").PubBaseID;

        //    var res = from P in context.Posts
        //              join UP in context.UserPosts on P.PostID equals UP.PostID_fk
        //              join U in context.Users on UP.UserID_fk equals U.UserID
        //              join postAttr in context.PostAttributes on P.PostID equals postAttr.PostID_fk
        //              join PBase in context.PubBases on postAttr.AttributeID_fk equals PBase.PubBaseID
        //              where PBase.NameEn == postCategory
        //              select new VM_Post
        //              {
        //                  PostID = P.PostID,
        //                  ContentPost = P.ContentPost,
        //                  DislikePost = P.DislikePost,
        //                  Image1 = P.Image1,
        //                  Image2 = P.Image2,
        //                  Image3 = P.Image3,
        //                  Image4 = P.Image4,
        //                  LikePost = P.LikePost,
        //                  ModifyDate = P.ModifyDate,
        //                  ModifyUserID = P.ModifyUserID,
        //                  PublishCount = P.PublishCount,
        //                  Subject = P.Subject,
        //                  Url = P.Url,
        //                  UrlMP3 = P.UrlMP3,
        //                  UrlVideo = P.UrlVideo,
        //                  Views = P.Views,
        //                  UserID_fk = UP.UserID_fk,
        //                  FirstName = U.FirstName,
        //                  LastName = U.LastName,
        //                  Fullname = U.FirstName + " " + U.LastName,
        //                  BackgroundColor = P.BackgroundColor,
        //                  QuotedFrom = P.QuotedFrom,
        //                  CommentCount = context.PostComments.Count(x => x.PostID_fk == P.PostID),
        //                  PostCategory = context.PostAttributes.Join(context.PubBases, postAttr => postAttr.AttributeID_fk, pBase => pBase.PubBaseID, (postAttr, pBase) =>
        //                  new VM_PubBase
        //                  {
        //                      PubBaseID = pBase.PubBaseID,
        //                      NameFa = pBase.NameFa,
        //                      ClassName = pBase.ClassName,
        //                      AbobeClassName = pBase.AbobeClassName,
        //                      NameEn = pBase.NameEn,
        //                      PostID = postAttr.PostID_fk,
        //                      ParentID = pBase.ParentID
        //                  }).Where(x => x.PostID == P.PostID && x.ParentID == postCategoryID),
        //                  PostFormat = context.PostAttributes.Join(context.PubBases, postAttr => postAttr.AttributeID_fk, pBase => pBase.PubBaseID, (postAttr, pBase) =>
        //                 new VM_PubBase
        //                 {
        //                     PubBaseID = pBase.PubBaseID,
        //                     NameFa = pBase.NameFa,
        //                     ClassName = pBase.ClassName,
        //                     AbobeClassName = pBase.AbobeClassName,
        //                     NameEn = pBase.NameEn,
        //                     PostID = postAttr.PostID_fk,
        //                     ParentID = pBase.ParentID
        //                 }).Where(x => x.PostID == P.PostID && x.ParentID == postFormatID),
        //                  PostCol = context.PostAttributes.Join(context.PubBases, postAttr => postAttr.AttributeID_fk, pBase => pBase.PubBaseID, (postAttr, pBase) =>
        //                 new VM_PubBase
        //                 {
        //                     PubBaseID = pBase.PubBaseID,
        //                     NameFa = pBase.NameFa,
        //                     ClassName = pBase.ClassName,
        //                     AbobeClassName = pBase.AbobeClassName,
        //                     NameEn = pBase.NameEn,
        //                     PostID = postAttr.PostID_fk,
        //                     ParentID = pBase.ParentID
        //                 }).Where(x => x.PostID == P.PostID && x.ParentID == PostColID),
        //              };
        //    return res;
        //}

        public IQueryable<Post> SelectAll(string condition)
        {
            throw new NotImplementedException();
        }

        //ایجاد پست ها از جدول پست تمپروری به جدول پست
        public bool CreatePost()
        {
            var tempPost = context.PostTemperories.Where(p => p.IsCreatedPost != true).ToList();
            foreach (var item in tempPost)
            {
                //قبلا این پست ایجاد نشده باشد
                var isExist = context.Posts.FirstOrDefault(p => p.Subject1 == item.Subject1);

                var values = typeof(PostTemperory)
                            .GetProperties()
                            .Select(p => new { p.Name, Value = p.GetValue(item, null) })
                            .ToArray();

                foreach (var item_1 in values)
                {
                    foreach (var item_2 in values)
                    {
                        if (item_1.Name != item_2.Name && item_1.Value != null && item_2.Value != null && (item_1.Value.ToString()) == (item_2.Value.ToString()))
                        {
                            item.GetType().GetProperty(item_2.Name).SetValue(item, null);
                            //context.SaveChanges();
                        }
                    }
                }


                if (isExist == null && item.Subject1.Trim().Length > 3 && (item.ContentPost1_1.Trim().Length > 3 || item.ContentPost1_2.Trim().Length > 3 || item.ContentPost1_3.Trim().Length > 3 || item.ContentPost1_4.Trim().Length > 3 || item.ContentPost1_2.Trim().Length > 5 || item.ContentPost1_6.Trim().Length > 3 || item.ContentPost1_7.Trim().Length > 3))
                {
                    //Mapper m = new Mapper()
                    //m.CreateMap<PostTemperory, PostTemperory>().ForMember(dest => dest.Length, expression => expression.MapFrom(src => string.IsNullOrWhiteSpace(src.Length) ? 0 : Convert.ToInt32(src.Length)));
                    var t = DomainMapper.Instance;
                    var entityPost = Mapper.Map<PostTemperory, Post>(item);
                    context.Posts.Add(entityPost);
                    context.SaveChanges();
                    //ایجاد پست
                    //var entityPost = context.Posts.Add(new Post()
                    //{
                    //    BackgroundColor =item.BackgroundColor, Subject1=item.Subject1, Cat1 =item.Cat1,Cat2=item.Cat2,Cat3=item.Cat3,ContentPost10_1=item.ContentPost10_1, ContentPost10_2=item.ContentPost10_2,ContentPost10_3=item.ContentPost10_3,ContentPost10_4=item.ContentPost10_4,ContentPost10_5=item.ContentPost10_5,
                    //    ContentPost11_1=item.ContentPost11_1,ContentPost11_2=item.ContentPost11_2, ContentPost11_3=item.ContentPost11_3, ContentPost11_4=item.ContentPost11_4,ContentPost11_5=item.ContentPost11_5, ContentPost12_1=item.ContentPost12_1, ContentPost12_2=item.ContentPost12_2,ContentPost12_3=item.ContentPost12_3,
                    //    ContentPost12_4=item.ContentPost12_4,ContentPost12_5=item.ContentPost12_5,ContentPost13_1=item.ContentPost13_1,ContentPost13_2=item.ContentPost13_2,ContentPost13_3=item.ContentPost13_3,ContentPost13_4=item.ContentPost13_4,ContentPost13_5=item.ContentPost13_5,ContentPost14_1=item.ContentPost14_1,
                    //    ContentPost14_2=item.ContentPost14_2,ContentPost14_3=item.ContentPost14_3,
                    //});
                    //context.SaveChanges();

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
                    //attrID = context.PubBases.FirstOrDefault(p => p.NameEn == "entertainment").PubBaseID;
                    attrID = new Random().Next(12, 20);
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
                        UserID_fk = r.Next(1, 3),
                    });

                    //مشخص کردن اينکه اين پست قبلا ايجاد شده است
                    item.IsCreatedPost = true;
                    context.PostTemperories.Attach(item);
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;

                    context.SaveChanges();
                }
                else
                {
                    //context.PostTemperories.Remove(item);
                    //context.SaveChanges();
                }
            }

            return true;
        }
    }
}
