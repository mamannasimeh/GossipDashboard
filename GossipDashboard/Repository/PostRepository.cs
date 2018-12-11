﻿using GossipDashboard.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using GossipDashboard.Models;
using System.Data.Entity;
using AutoMapper;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

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
                          FootCategory = P.SourceFootCategory,
                          DateTimePost = P.SourceDateTimePost,
                          ContentPost1_6 = P.ContentPost1_6,
                          ContentPost1_7 = P.ContentPost1_7,
                          SourceDateTimePost = P.SourceDateTimePost,
                          SourceFootCategory = P.SourceFootCategory,
                          SourceSiteName = P.SourceSiteName,
                          SourceSiteNameFa = P.SourceSiteNameFa,
                          SourceSiteUrl = P.SourceSiteUrl,
                          ContentHTML = P.ContentHTML,
                          ScriptAparat = P.ScriptAparat,
                          Status = P.Status,
                          StatusAuthor = P.StatusAuthor,
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
                          }).Where(x => x.PostID == P.PostID && x.ParentID == postCategoryID).ToList(),
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
                         }).Where(x => x.PostID == P.PostID && x.ParentID == postFormatID).ToList(),
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
                          }).Where(x => x.PostID == P.PostID && x.ParentID == PostColID).ToList(),
                      };
            return res;
        }

        internal void UpdatePostViews(int postID)
        {
            var entity = context.Posts.FirstOrDefault(p => p.PostID == postID);
            if (entity != null)
            {
                entity.Views = (entity.Views ?? 0) + 1;
                context.Posts.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Post Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool? DeletePost(int id)
        {
            var entity = context.Posts.FirstOrDefault(p => p.PostID == id);
            if (entity == null)
                return null;

            context.Posts.Remove(entity);
            context.SaveChanges();

            return true;
        }

        public bool? DeletePostTemperory(int id)
        {
            var entity = context.PostTemperories.FirstOrDefault(p => p.PostID == id);
            if (entity == null)
                return null;

            context.PostTemperories.Remove(entity);
            context.SaveChanges();

            return true;
        }

        public bool? DeletePostTemperoryBySiteURL(string siteURL)
        {
            var entity = context.PostTemperories.FirstOrDefault(p => p.SourceSiteUrl == siteURL);
            if (entity == null)
                return null;

            context.PostTemperories.Remove(entity);
            context.SaveChanges();

            return true;
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
                          ContentPost1_6 = P.ContentPost1_6,
                          ContentPost1_7 = P.ContentPost1_7,
                          FootCategory = P.SourceFootCategory,
                          DateTimePost = P.SourceDateTimePost,
                          ContentHTML = P.ContentHTML,
                          ScriptAparat = P.ScriptAparat,
                          SourceDateTimePost = P.SourceDateTimePost,
                          SourceFootCategory = P.SourceFootCategory,
                          SourceSiteName = P.SourceSiteName,
                          SourceSiteNameFa = P.SourceSiteNameFa,
                          SourceSiteUrl = P.SourceSiteUrl,
                          Status = P.Status,
                          StatusAuthor = P.StatusAuthor,
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
                          }).Where(x => x.PostID == P.PostID && x.ParentID == postCategoryID).ToList(),
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
                         }).Where(x => x.PostID == P.PostID && x.ParentID == postFormatID).ToList(),
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
                         }).Where(x => x.PostID == P.PostID && x.ParentID == PostColID).ToList(),
                      };
            return res;
        }

        public IQueryable<Post> SelectAll(string condition)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ایجاد پست ها از جدول پست تمپروری به جدول پست
        /// </summary>
        public void CreatePost()
        {
            var doc = new HtmlDocument();
            List<string> matchList = new List<string>();
            bool? isPostDeleted = false;
            string tempContentHTML = "", tempHTML = "";

            //پست هایی که قبلا ایجاد نشده اند
            //پست استاتوس می تواند بیش از یکبار نیز انتشار پیدا کند
            var tempPost = context.PostTemperories.Where(p => ((p.IsCreatedPost == null || p.IsCreatedPost == false) ? false : true) != true).OrderByDescending(p => p.PostID).ToList();
            foreach (var item in tempPost)
            {

                isPostDeleted = false;

                //انتیتی از روی  مقادیر فیلد اچ تی ام ال ساخته می شود
                //اگر این فیلد مقدار نداشت به روش زیر عمل می کنیم
                if (item.HTML == null || item.HTML.Trim() == "")
                    item.HTML = item.ContentHTML;

                //قبلا این پست ایجاد نشده باشد
                //پست استاتوس می تواند بیش از یکبار نیز انتشار پیدا کند
                var isExist = context.Posts.FirstOrDefault(p => p.Subject1 == item.Subject1);

                if (isExist == null && item.Subject1 != null && item.Subject1.Trim().Length > 3
                    && item.HTML != null && item.HTML.Trim() != ""
                    && item.ContentHTML != null && item.ContentHTML.Trim() != "")
                {
                    //حذف کارکترهايي که نیاز نیست
                    item.HTML = item.HTML.Replace("&nbsp;", "");


                    tempContentHTML = item.ContentHTML;
                    tempHTML = item.HTML;


                    //اصلاح لینک یو آر ال عکس ها
                    if (item.SourceSiteUrl != null && item.SourceSiteUrl.Contains("rangehonar"))
                    {
                        //اصلاح لینک یو آر ال عکس ها
                        var url = "src=\"https://www.rangehonar.com";
                        tempContentHTML = item.ContentHTML.Replace("src=\"", url);
                        tempHTML = tempContentHTML;
                    }

                    //اینسرت از پست تمپروری به پست با کمک رفلکشن
                    doc.LoadHtml(tempHTML);
                    var entityPost = CreatepostValues(doc);
                    entityPost.Subject1 = item.Subject1;
                    entityPost.SubSubject1_1 = item.SubSubject1_1;
                    entityPost.SubSubject1_2 = item.SubSubject1_2;
                    entityPost.ModifyDate = DateTime.Now;
                    entityPost.ContentHTML = tempContentHTML;
                    entityPost.Status = item.Status;
                    entityPost.StatusAuthor = item.StatusAuthor;

                    //برای عملکرد صحیح سایت
                    if (entityPost.Status != null && entityPost.SourceSiteUrl == null)
                        entityPost.SourceSiteUrl = "http://www.Status.com";

                    //به دست آوردن سایت مرجع جهت نمایش در سایت 
                    //var regMatch = Regex.Matches(item.HTML, @"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9]\.[^\s]{2,})");
                    if (item.SourceSiteUrl != null)
                    {
                        entityPost.SourceSiteUrl = item.SourceSiteUrl;
                        var regMatch = Regex.Matches(item.SourceSiteUrl, @"(?:[-a-zA-Z0-9@:%_\+~.#=]{2,256}\.)?([-a-zA-Z0-9@:%_\+~#=]*)\.[a-z]{2,6}\b(?:[-a-zA-Z0-9@:%_\+.~#?&\/\/=]*)");
                        if (regMatch != null && regMatch.Count != 0 && regMatch[0].Groups != null && regMatch[0].Groups[1] != null)
                        {
                            entityPost.SourceSiteName = regMatch[0].Groups[1].Value;

                            switch (entityPost.SourceSiteName.ToUpper())
                            {
                                case "BARTARINHA":
                                    entityPost.SourceSiteNameFa = "برترین ها";
                                    break;
                                case "EURONEWS":
                                    entityPost.SourceSiteNameFa = "یورونیوز فارسی";
                                    entityPost.ContentHTML = item.ContentHTML.Replace("اندازه متن Aa Aa", "");

                                    //عکس اول یورونیوز فارسی با وب هاروی ست شدده است
                                    if (item.Image1_1 != null && item.Image1_1 != "")
                                        entityPost.Image1_1 = item.Image1_1;
                                    break;
                                case "IRANNAZ":
                                    entityPost.SourceSiteNameFa = "ایران ناز";

                                    //پست های تبلیغاتی یا نامرتبط حذف گردد
                                    isPostDeleted = IsDeletePostOnProcess("IRANNAZ", entityPost);
                                    break;

                                case "RANGEHONAR":
                                    entityPost.SourceSiteNameFa = "سامانه آموزش نقاشی رنگ هنر";

                                    //اصلاح مقدار کانتنت پست 1 با شرایط زیر
                                    if (entityPost.ContentPost1_1.Contains("نویسنده") && entityPost.ContentPost1_1.Contains("بخش")
                                        && entityPost.ContentPost1_1.Contains("تاریخ") && entityPost.ContentPost1_1.Contains("نظرات"))
                                    {
                                        var temp = entityPost.ContentPost1_1;
                                        entityPost.ContentPost1_1 = entityPost.ContentPost1_2;
                                        entityPost.ContentPost20_1 = temp;
                                    }
                                    break;

                                default:
                                    entityPost.SourceSiteNameFa = entityPost.SourceSiteName;
                                    break;
                            }
                        }
                    }

                    //در صورتی که پست حذف شد اتریبیوت های آن ایجاد نشود
                    if (isPostDeleted == true)
                        continue;


                    //ایجاد اتربیوت ها فرمت پست ها
                    var attrID = context.PubBases.FirstOrDefault(p => p.NameEn == "standard").PubBaseID;
                    var attrName = context.PubBases.FirstOrDefault(p => p.NameEn == "standard").NameEn;
                    if (entityPost.UrlMP3 != null)
                        attrID = context.PubBases.FirstOrDefault(p => p.NameEn == "audio").PubBaseID;
                    else if (entityPost.UrlVideo != null)
                        attrID = context.PubBases.FirstOrDefault(p => p.NameEn == "video").PubBaseID;
                    else if (entityPost.ScriptAparat != null)
                        attrID = context.PubBases.FirstOrDefault(p => p.NameEn == "aparat").PubBaseID;
                    else if (entityPost.Status != null)
                        attrID = context.PubBases.FirstOrDefault(p => p.NameEn == "status").PubBaseID;

     

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
                    context.Entry(item).State = EntityState.Modified;

                    context.SaveChanges();
                }
                else
                {
                    //context.PostTemperories.Remove(item);
                    //context.SaveChanges();
                }


            }


        }

        /// <summary>
        /// ایجاد انتیتی پست و تنظیم مقادیر آن با کمک رفلکشن
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private Post CreatepostValues(HtmlAgilityPack.HtmlDocument doc)
        {
            Post entity = new Post();

            //به دست آوردن تمامی پراپرتی های جدول پست
            var values = typeof(Post)
               .GetProperties()
               .Where(p => !p.PropertyType.IsClass || p.PropertyType == typeof(String))
               .Select(p => new { p.Name, Value = p.GetValue(entity, null) })
               .ToList();


            //---------------------------------------------------------------------------
            //به دست آوردن مقادیر تمامی ندهای اسپن
            var nodes = doc.DocumentNode.SelectNodes("//span");

            //Subject فیلتر پراپرتی ها بر اساس 
            var subjects = values.Where(p => p.Name.Contains("Subject") && !p.Name.Contains("Subject1") && !p.Name.Contains("SubSubject"));

            if (nodes != null)
            {
                foreach (var item in nodes)
                {
                    if (item.InnerText.Trim() == "")
                        continue;

                    foreach (var item_1 in subjects)
                    {
                        var valueEntity = entity.GetType().GetProperty(item_1.Name).GetValue(entity);
                        if (valueEntity == null)
                        {
                            //تنظیم پراپرتی  جدول پست
                            //entity.Subject1 = ....
                            entity.GetType().GetProperty(item_1.Name).SetValue(entity, item.InnerText);

                            //با تنظیم مقدار هر پراپرتی  جدول پست از حلقه اول خارج می شویم
                            //و به دنبال پراپرتی بعدی برای تنظیم مقدار آن می رویم
                            break;
                        }
                    }
                }
            }

            //---------------------------------------------------------------------------
            //به دست آوردن مقادیر تمامی ندهای پی
            nodes = doc.DocumentNode.SelectNodes("//p");

            //ContentPost فیلتر پراپرتی ها بر اساس 
            var contentPosts = values.Where(p => p.Name.Contains("ContentPost"));

            if (nodes != null)
            {
                foreach (var item in nodes)
                {
                    if (item.InnerText.Trim() == "")
                        continue;

                    foreach (var item_1 in contentPosts)
                    {
                        var valueEntity = entity.GetType().GetProperty(item_1.Name).GetValue(entity);
                        if (valueEntity == null)
                        {
                            //تنظیم پراپرتی  جدول پست
                            //entity.Subject1 = ....
                            entity.GetType().GetProperty(item_1.Name).SetValue(entity, item.InnerText);

                            //با تنظیم مقدار هر پراپرتی  جدول پست از حلقه اول خارج می شویم
                            //و به دنبال پراپرتی بعدی برای تنظیم مقدار آن می رویم
                            break;
                        }
                    }
                }
            }

            //---------------------------------------------------------------------------
            //به دست آوردن مقادیر تمامی ندهای اسپن
            nodes = doc.DocumentNode.SelectNodes("//img");

            //Image فیلتر پراپرتی ها بر اساس 
            var images = values.Where(p => p.Name.Contains("Image"));
            string urlImg = "";
            if (nodes != null)
            {
                foreach (var item in nodes)
                {
                    if (item.OuterHtml.Trim() == "")
                        continue;

                    //چک کردن موجود بودن یو آر ال تصویر 
                    var regMatch = Regex.Matches(item.OuterHtml, "(http|https)://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?.(?:jpg|bmp|gif|png)");
                    if (regMatch != null && regMatch.Count > 0)
                        urlImg = regMatch[0].Value;
                    else
                        continue;

                    foreach (var item_1 in images)
                    {
                        var valueEntity = entity.GetType().GetProperty(item_1.Name).GetValue(entity);
                        if (valueEntity == null)
                        {
                            //تنظیم پراپرتی  جدول پست
                            //entity.Subject1 = ....
                            entity.GetType().GetProperty(item_1.Name).SetValue(entity, urlImg);

                            //با تنظیم مقدار هر پراپرتی  جدول پست از حلقه اول خارج می شویم
                            //و به دنبال پراپرتی بعدی برای تنظیم مقدار آن می رویم
                            break;
                        }
                    }
                }
            }


            context.Posts.Add(entity);
            context.SaveChanges();

            return entity;
        }


        //حذف مقادیر تکراری
        //تمامی ستون های یک سطر را چک می کند و تمامی مقادیر تکراری را حذف می کند
        private static void DeleteDuplicateValue(PostTemperory item)
        {
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
        }

        //حذف پست هایی با توجهه به سایت مرجع
        private bool? IsDeletePostOnProcess(string sourceSite, Post entityPost)
        {
            //سایت ایران ناز
            if (sourceSite.ToUpper() == "IRANNAZ".ToUpper())
            {
                // یو آر ال هایی که عبارت نیوز کتس دارند حذف گردد. 
                // اين پست ها مثل فال و اس ام اس و غيره هستند
                //برای اطمینان که پستی به اشتباه حذف نشود نباید علامت درصد هم داشته باشد
                if (entityPost.SourceSiteUrl.Contains("news_cats") && !entityPost.SourceSiteUrl.Contains("%"))
                {
                    var isPostDel = DeletePost(entityPost.PostID);
                    var isPostTempDel = DeletePostTemperoryBySiteURL(entityPost.SourceSiteUrl);

                    return isPostDel;
                }
            }

            return false;
        }

    }
}
