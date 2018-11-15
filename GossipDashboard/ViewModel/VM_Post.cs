using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using GossipDashboard.Models;

namespace GossipDashboard.ViewModel
{
    public class VM_Post
    {
        public int PostID { get; set; }
        public string Subject1 { get; set; }
        public string SubSubject1_1 { get; set; }
        public string SubSubject1_2 { get; set; }
        public string ContentPost1_1 { get; set; }
        public string ContentPost1_2 { get; set; }
        public string ContentPost1_3 { get; set; }
        public string ContentPost1_4 { get; set; }
        public string ContentPost1_5 { get; set; }
        public string Image1_1 { get; set; }
        public string Image1_2 { get; set; }
        public string Image1_3 { get; set; }
        public string Subject2 { get; set; }
        public string SubSubject2_1 { get; set; }
        public string SubSubject2_2 { get; set; }
        public string ContentPost2_1 { get; set; }
        public string ContentPost2_2 { get; set; }
        public string ContentPost2_3 { get; set; }
        public string ContentPost2_4 { get; set; }
        public string ContentPost2_5 { get; set; }
        public string Image2_1 { get; set; }
        public string Image2_2 { get; set; }
        public string Image2_3 { get; set; }
        public string Subject3 { get; set; }
        public string SubSubject3_1 { get; set; }
        public string SubSubject3_2 { get; set; }
        public string ContentPost3_1 { get; set; }
        public string ContentPost3_2 { get; set; }
        public string ContentPost3_3 { get; set; }
        public string ContentPost3_4 { get; set; }
        public string ContentPost3_5 { get; set; }
        public string Image3_1 { get; set; }
        public string Image3_2 { get; set; }
        public string Image3_3 { get; set; }
        public string Subject4 { get; set; }
        public string SubSubject4_1 { get; set; }
        public string SubSubject4_2 { get; set; }
        public string ContentPost4_1 { get; set; }
        public string ContentPost4_2 { get; set; }
        public string ContentPost4_3 { get; set; }
        public string ContentPost4_4 { get; set; }
        public string ContentPost4_5 { get; set; }
        public string Image4_1 { get; set; }
        public string Image4_2 { get; set; }
        public string Image4_3 { get; set; }
        public string Subject5 { get; set; }
        public string SubSubject5_1 { get; set; }
        public string SubSubject5_2 { get; set; }
        public string ContentPost5_1 { get; set; }
        public string ContentPost5_2 { get; set; }
        public string ContentPost5_3 { get; set; }
        public string ContentPost5_4 { get; set; }
        public string ContentPost5_5 { get; set; }
        public string Image5_1 { get; set; }
        public string Image5_2 { get; set; }
        public string Image5_3 { get; set; }
        public string Subject6 { get; set; }
        public string SubSubject6_1 { get; set; }
        public string SubSubject6_2 { get; set; }
        public string ContentPost6_1 { get; set; }
        public string ContentPost6_2 { get; set; }
        public string ContentPost6_3 { get; set; }
        public string ContentPost6_4 { get; set; }
        public string ContentPost6_5 { get; set; }
        public string Image6_1 { get; set; }
        public string Image6_2 { get; set; }
        public string Image6_3 { get; set; }
        public string Subject7 { get; set; }
        public string SubSubject7_1 { get; set; }
        public string SubSubject7_2 { get; set; }
        public string ContentPost7_1 { get; set; }
        public string ContentPost7_2 { get; set; }
        public string ContentPost7_3 { get; set; }
        public string ContentPost7_4 { get; set; }
        public string ContentPost7_5 { get; set; }
        public string Image7_1 { get; set; }
        public string Image7_2 { get; set; }
        public string Image7_3 { get; set; }
        public string Subject8 { get; set; }
        public string SubSubject8_1 { get; set; }
        public string SubSubject8_2 { get; set; }
        public string ContentPost8_1 { get; set; }
        public string ContentPost8_2 { get; set; }
        public string ContentPost8_3 { get; set; }
        public string ContentPost8_4 { get; set; }
        public string ContentPost8_5 { get; set; }
        public string Image8_1 { get; set; }
        public string Image8_2 { get; set; }
        public string Image8_3 { get; set; }
        public string Subject9 { get; set; }
        public string SubSubject9_1 { get; set; }
        public string SubSubject9_2 { get; set; }
        public string ContentPost9_1 { get; set; }
        public string ContentPost9_2 { get; set; }
        public string ContentPost9_3 { get; set; }
        public string ContentPost9_4 { get; set; }
        public string ContentPost9_5 { get; set; }
        public string Image9_1 { get; set; }
        public string Image9_2 { get; set; }
        public string Image9_3 { get; set; }
        public string Subject10 { get; set; }
        public string SubSubject10_1 { get; set; }
        public string SubSubject10_2 { get; set; }
        public string ContentPost10_1 { get; set; }
        public string ContentPost10_2 { get; set; }
        public string ContentPost10_3 { get; set; }
        public string ContentPost10_4 { get; set; }
        public string ContentPost10_5 { get; set; }
        public string Image10_1 { get; set; }
        public string Image10_2 { get; set; }
        public string Image10_3 { get; set; }
        public string Subject11 { get; set; }
        public string SubSubject11_1 { get; set; }
        public string SubSubject11_2 { get; set; }
        public string ContentPost11_1 { get; set; }
        public string ContentPost11_2 { get; set; }
        public string ContentPost11_3 { get; set; }
        public string ContentPost11_4 { get; set; }
        public string ContentPost11_5 { get; set; }
        public string Image11_1 { get; set; }
        public string Image11_2 { get; set; }
        public string Image11_3 { get; set; }
        public string Subject12 { get; set; }
        public string SubSubject12_1 { get; set; }
        public string SubSubject12_2 { get; set; }
        public string ContentPost12_1 { get; set; }
        public string ContentPost12_2 { get; set; }
        public string ContentPost12_3 { get; set; }
        public string ContentPost12_4 { get; set; }
        public string ContentPost12_5 { get; set; }
        public string Image12_1 { get; set; }
        public string Image12_2 { get; set; }
        public string Image12_3 { get; set; }
        public string Subject13 { get; set; }
        public string SubSubject13_1 { get; set; }
        public string SubSubject13_2 { get; set; }
        public string ContentPost13_1 { get; set; }
        public string ContentPost13_2 { get; set; }
        public string ContentPost13_3 { get; set; }
        public string ContentPost13_4 { get; set; }
        public string ContentPost13_5 { get; set; }
        public string Image13_1 { get; set; }
        public string Image13_2 { get; set; }
        public string Image13_3 { get; set; }
        public string Subject14 { get; set; }
        public string SubSubject14_1 { get; set; }
        public string SubSubject14_2 { get; set; }
        public string ContentPost14_1 { get; set; }
        public string ContentPost14_2 { get; set; }
        public string ContentPost14_3 { get; set; }
        public string ContentPost14_4 { get; set; }
        public string ContentPost14_5 { get; set; }
        public string Image14_1 { get; set; }
        public string Image14_2 { get; set; }
        public string Image14_3 { get; set; }
        public string Subject15 { get; set; }
        public string SubSubject15_1 { get; set; }
        public string SubSubject15_2 { get; set; }
        public string ContentPost15_1 { get; set; }
        public string ContentPost15_2 { get; set; }
        public string ContentPost15_3 { get; set; }
        public string ContentPost15_4 { get; set; }
        public string ContentPost15_5 { get; set; }
        public string Image15_1 { get; set; }
        public string Image15_2 { get; set; }
        public string Image15_3 { get; set; }
        public string Subject16 { get; set; }
        public string SubSubject16_1 { get; set; }
        public string SubSubject16_2 { get; set; }
        public string ContentPost16_1 { get; set; }
        public string ContentPost16_2 { get; set; }
        public string ContentPost16_3 { get; set; }
        public string ContentPost16_4 { get; set; }
        public string ContentPost16_5 { get; set; }
        public string Image16_1 { get; set; }
        public string Image16_2 { get; set; }
        public string Image16_3 { get; set; }
        public string Subject17 { get; set; }
        public string SubSubject17_1 { get; set; }
        public string SubSubject17_2 { get; set; }
        public string ContentPost17_1 { get; set; }
        public string ContentPost17_2 { get; set; }
        public string ContentPost17_3 { get; set; }
        public string ContentPost17_4 { get; set; }
        public string ContentPost17_5 { get; set; }
        public string Image17_1 { get; set; }
        public string Image17_2 { get; set; }
        public string Image17_3 { get; set; }
        public string Subject18 { get; set; }
        public string SubSubject18_1 { get; set; }
        public string SubSubject18_2 { get; set; }
        public string ContentPost18_1 { get; set; }
        public string ContentPost18_2 { get; set; }
        public string ContentPost18_3 { get; set; }
        public string ContentPost18_4 { get; set; }
        public string ContentPost18_5 { get; set; }
        public string Image18_1 { get; set; }
        public string Image18_2 { get; set; }
        public string Image18_3 { get; set; }
        public string Subject19 { get; set; }
        public string SubSubject19_1 { get; set; }
        public string SubSubject19_2 { get; set; }
        public string ContentPost19_1 { get; set; }
        public string ContentPost19_2 { get; set; }
        public string ContentPost19_3 { get; set; }
        public string ContentPost19_4 { get; set; }
        public string ContentPost19_5 { get; set; }
        public string Image19_1 { get; set; }
        public string Image19_2 { get; set; }
        public string Image19_3 { get; set; }
        public string Subject20 { get; set; }
        public string SubSubject20_1 { get; set; }
        public string SubSubject20_2 { get; set; }
        public string ContentPost20_1 { get; set; }
        public string ContentPost20_2 { get; set; }
        public string ContentPost20_3 { get; set; }
        public string ContentPost20_4 { get; set; }
        public string ContentPost20_5 { get; set; }
        public string Image20_1 { get; set; }
        public string Image20_2 { get; set; }
        public string Image20_3 { get; set; }
        public string QuotedFrom { get; set; }
        public string Url { get; set; }
        public string UrlMP3 { get; set; }
        public string UrlVideo { get; set; }
        public Nullable<int> Views { get; set; }
        public Nullable<int> LikePost { get; set; }
        public Nullable<int> DislikePost { get; set; }
        public Nullable<int> PublishCount { get; set; }
        public string BackgroundColor { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<bool> IsCreatedPost { get; set; }
        public string Cat1 { get; set; }
        public string Cat2 { get; set; }
        public string Cat3 { get; set; }
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }
        public string Tag4 { get; set; }
        public string Tag5 { get; set; }
        public string Tag6 { get; set; }
        public string Tag7 { get; set; }
        public string Tag8 { get; set; }
        public string Tag9 { get; set; }
        public string Tag10 { get; set; }
        public string FootCategory { get; set; }
        public string DateTimePost { get; set; }
        public string ContentPost1_6 { get; set; }
        public string ContentPost1_7 { get; set; }
        public IQueryable<VM_PubBase> PostCategory { get;  set; }
        public IQueryable<VM_PubBase> PostFormat { get;  set; }
        public IQueryable<VM_PubBase> PostCol { get;  set; }
        public string AboutUser { get;  set; }
        public byte[] ImageUser { get;  set; }
        public string JalaliModifyDate { get;  set; }
        public string Fullname { get;  set; }
        public int CommentCount { get;  set; }
        public int UserID_fk { get; internal set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
    }


    public class M2VM_Post_Converter : ITypeConverter<Post, VM_Post>
    {
        public VM_Post Convert(Post source, VM_Post destination, ResolutionContext context)
        {
            var result = new VM_Post
            {
                PostID = source.PostID,
                Subject1 = source.Subject1,
                SubSubject1_1 = source.SubSubject1_1,
                SubSubject1_2 = source.SubSubject1_2,
                ContentPost1_1 = source.ContentPost1_1,
                ContentPost1_2 = source.ContentPost1_2,
                ContentPost1_3 = source.ContentPost1_3,
                ContentPost1_4 = source.ContentPost1_4,
                ContentPost1_5 = source.ContentPost1_5,
                Image1_1 = source.Image1_1,
                Image1_2 = source.Image1_2,
                Image1_3 = source.Image1_3,
                Subject2 = source.Subject2,
                SubSubject2_1 = source.SubSubject2_1,
                SubSubject2_2 = source.SubSubject2_2,
                ContentPost2_1 = source.ContentPost2_1,
                ContentPost2_2 = source.ContentPost2_2,
                ContentPost2_3 = source.ContentPost2_3,
                ContentPost2_4 = source.ContentPost2_4,
                ContentPost2_5 = source.ContentPost2_5,
                Image2_1 = source.Image2_1,
                Image2_2 = source.Image2_2,
                Image2_3 = source.Image2_3,
                Subject3 = source.Subject3,
                SubSubject3_1 = source.SubSubject3_1,
                SubSubject3_2 = source.SubSubject3_2,
                ContentPost3_1 = source.ContentPost3_1,
                ContentPost3_2 = source.ContentPost3_2,
                ContentPost3_3 = source.ContentPost3_3,
                ContentPost3_4 = source.ContentPost3_4,
                ContentPost3_5 = source.ContentPost3_5,
                Image3_1 = source.Image3_1,
                Image3_2 = source.Image3_2,
                Image3_3 = source.Image3_3,
                Subject4 = source.Subject4,
                SubSubject4_1 = source.SubSubject4_1,
                SubSubject4_2 = source.SubSubject4_2,
                ContentPost4_1 = source.ContentPost4_1,
                ContentPost4_2 = source.ContentPost4_2,
                ContentPost4_3 = source.ContentPost4_3,
                ContentPost4_4 = source.ContentPost4_4,
                ContentPost4_5 = source.ContentPost4_5,
                Image4_1 = source.Image4_1,
                Image4_2 = source.Image4_2,
                Image4_3 = source.Image4_3,
                Subject5 = source.Subject5,
                SubSubject5_1 = source.SubSubject5_1,
                SubSubject5_2 = source.SubSubject5_2,
                ContentPost5_1 = source.ContentPost5_1,
                ContentPost5_2 = source.ContentPost5_2,
                ContentPost5_3 = source.ContentPost5_3,
                ContentPost5_4 = source.ContentPost5_4,
                ContentPost5_5 = source.ContentPost5_5,
                Image5_1 = source.Image5_1,
                Image5_2 = source.Image5_2,
                Image5_3 = source.Image5_3,
                Subject6 = source.Subject6,
                SubSubject6_1 = source.SubSubject6_1,
                SubSubject6_2 = source.SubSubject6_2,
                ContentPost6_1 = source.ContentPost6_1,
                ContentPost6_2 = source.ContentPost6_2,
                ContentPost6_3 = source.ContentPost6_3,
                ContentPost6_4 = source.ContentPost6_4,
                ContentPost6_5 = source.ContentPost6_5,
                Image6_1 = source.Image6_1,
                Image6_2 = source.Image6_2,
                Image6_3 = source.Image6_3,
                Subject7 = source.Subject7,
                SubSubject7_1 = source.SubSubject7_1,
                SubSubject7_2 = source.SubSubject7_2,
                ContentPost7_1 = source.ContentPost7_1,
                ContentPost7_2 = source.ContentPost7_2,
                ContentPost7_3 = source.ContentPost7_3,
                ContentPost7_4 = source.ContentPost7_3,
                ContentPost7_5 = source.ContentPost7_5,
                Image7_1 = source.Image7_1,
                Image7_2 = source.Image7_2,
                Image7_3 = source.Image7_3,
                Subject8 = source.Subject8,
                SubSubject8_1 = source.SubSubject8_1,
                SubSubject8_2 = source.SubSubject8_2,
                ContentPost8_1 = source.ContentPost8_1,
                ContentPost8_2 = source.ContentPost8_2,
                ContentPost8_3 = source.ContentPost8_3,
                ContentPost8_4 = source.ContentPost8_4,
                ContentPost8_5 = source.ContentPost8_5,
                Image8_1 = source.Image8_1,
                Image8_2 = source.Image8_2,
                Image8_3 = source.Image8_3,
                Subject9 = source.Subject9,
                SubSubject9_1 = source.SubSubject9_1,
                SubSubject9_2 = source.SubSubject9_2,
                ContentPost9_1 = source.ContentPost9_1,
                ContentPost9_2 = source.ContentPost9_2,
                ContentPost9_3 = source.ContentPost9_3,
                ContentPost9_4 = source.ContentPost9_4,
                ContentPost9_5 = source.ContentPost9_5,
                Image9_1 = source.Image9_1,
                Image9_2 = source.Image9_2,
                Image9_3 = source.Image9_3,
                Subject10 = source.Subject10,
                SubSubject10_1 = source.SubSubject10_1,
                SubSubject10_2 = source.SubSubject10_2,
                ContentPost10_1 = source.ContentPost10_1,
                ContentPost10_2 = source.ContentPost10_2,
                ContentPost10_3 = source.ContentPost10_3,
                ContentPost10_4 = source.ContentPost10_4,
                ContentPost10_5 = source.ContentPost10_5,
                Image10_1 = source.Image10_1,
                Image10_2 = source.Image10_2,
                Image10_3 = source.Image10_3,
                Subject11 = source.Subject11,
                SubSubject11_1 = source.SubSubject11_1,
                SubSubject11_2 = source.SubSubject11_2,
                ContentPost11_1 = source.ContentPost11_1,
                ContentPost11_2 = source.ContentPost11_2,
                ContentPost11_3 = source.ContentPost11_3,
                ContentPost11_4 = source.ContentPost11_4,
                ContentPost11_5 = source.ContentPost11_5,
                Image11_1 = source.Image11_1,
                Image11_2 = source.Image11_2,
                Image11_3 = source.Image11_3,
                Subject12 = source.Subject12,
                SubSubject12_1 = source.SubSubject12_1,
                SubSubject12_2 = source.SubSubject12_2,
                ContentPost12_1 = source.ContentPost12_1,
                ContentPost12_2 = source.ContentPost12_2,
                ContentPost12_3 = source.ContentPost12_3,
                ContentPost12_4 = source.ContentPost12_4,
                ContentPost12_5 = source.ContentPost12_5,
                Image12_1 = source.Image12_1,
                Image12_2 = source.Image12_2,
                Image12_3 = source.Image12_3,
                Subject13 = source.Subject13,
                SubSubject13_1 = source.SubSubject13_1,
                SubSubject13_2 = source.SubSubject13_2,
                ContentPost13_1 = source.ContentPost13_1,
                ContentPost13_2 = source.ContentPost13_2,
                ContentPost13_3 = source.ContentPost13_3,
                ContentPost13_4 = source.ContentPost13_4,
                ContentPost13_5 = source.ContentPost13_5,
                Image13_1 = source.Image13_1,
                Image13_2 = source.Image13_2,
                Image13_3 = source.Image13_3,
                Subject14 = source.Subject14,
                SubSubject14_1 = source.SubSubject14_1,
                SubSubject14_2 = source.SubSubject14_2,
                ContentPost14_1 = source.ContentPost14_1,
                ContentPost14_2 = source.ContentPost14_2,
                ContentPost14_3 = source.ContentPost14_3,
                ContentPost14_4 = source.ContentPost14_4,
                ContentPost14_5 = source.ContentPost14_5,
                Image14_1 = source.Image14_1,
                Image14_2 = source.Image14_2,
                Image14_3 = source.Image14_3,
                Subject15 = source.Subject15,
                SubSubject15_1 = source.SubSubject15_1,
                SubSubject15_2 = source.SubSubject15_2,
                ContentPost15_1 = source.ContentPost15_1,
                ContentPost15_2 = source.ContentPost15_2,
                ContentPost15_3 = source.ContentPost15_3,
                ContentPost15_4 = source.ContentPost15_4,
                ContentPost15_5 = source.ContentPost15_5,
                Image15_1 = source.Image15_1,
                Image15_2 = source.Image15_2,
                Image15_3 = source.Image15_3,
                Subject16 = source.Subject16,
                SubSubject16_1 = source.SubSubject16_1,
                SubSubject16_2 = source.SubSubject16_2,
                ContentPost16_1 = source.ContentPost16_1,
                ContentPost16_2 = source.ContentPost16_2,
                ContentPost16_3 = source.ContentPost16_3,
                ContentPost16_4 = source.ContentPost16_4,
                ContentPost16_5 = source.ContentPost16_5,
                Image16_1 = source.Image16_1,
                Image16_2 = source.Image16_2,
                Image16_3 = source.Image16_3,
                Subject17 = source.Subject17,
                SubSubject17_1 = source.SubSubject17_1,
                SubSubject17_2 = source.SubSubject17_2,
                ContentPost17_1 = source.ContentPost17_1,
                ContentPost17_2 = source.ContentPost17_2,
                ContentPost17_3 = source.ContentPost17_3,
                ContentPost17_4 = source.ContentPost17_4,
                ContentPost17_5 = source.ContentPost17_5,
                Image17_1 = source.Image17_1,
                Image17_2 = source.Image17_2,
                Image17_3 = source.Image17_3,
                Subject18 = source.Subject18,
                SubSubject18_1 = source.SubSubject18_1,
                SubSubject18_2 = source.SubSubject18_2,
                ContentPost18_1 = source.ContentPost18_1,
                ContentPost18_2 = source.ContentPost18_2,
                ContentPost18_3 = source.ContentPost18_3,
                ContentPost18_4 = source.ContentPost18_4,
                ContentPost18_5 = source.ContentPost18_5,
                Image18_1 = source.Image18_1,
                Image18_2 = source.Image18_2,
                Image18_3 = source.Image18_3,
                Subject19 = source.Subject19,
                SubSubject19_1 = source.SubSubject19_1,
                SubSubject19_2 = source.SubSubject19_2,
                ContentPost19_1 = source.ContentPost19_1,
                ContentPost19_2 = source.ContentPost19_2,
                ContentPost19_3 = source.ContentPost19_3,
                ContentPost19_4 = source.ContentPost19_4,
                ContentPost19_5 = source.ContentPost19_5,
                Image19_1 = source.Image19_1,
                Image19_2 = source.Image19_2,
                Image19_3 = source.Image19_3,
                Subject20 = source.Subject20,
                SubSubject20_1 = source.SubSubject20_1,
                SubSubject20_2 = source.SubSubject20_2,
                ContentPost20_1 = source.ContentPost20_1,
                ContentPost20_2 = source.ContentPost20_2,
                ContentPost20_3 = source.ContentPost20_3,
                ContentPost20_4 = source.ContentPost20_4,
                ContentPost20_5 = source.ContentPost20_5,
                Image20_1 = source.Image20_1,
                Image20_2 = source.Image20_2,
                Image20_3 = source.Image20_3,
                QuotedFrom = source.QuotedFrom,
                Url = source.Url,
                UrlMP3 = source.UrlMP3,
                UrlVideo = source.UrlVideo,
                Views = source.Views,
                LikePost = source.LikePost,
                DislikePost = source.DislikePost,
                PublishCount = source.PublishCount,
                BackgroundColor = source.BackgroundColor,
                ModifyUserID = source.ModifyUserID,
                ModifyDate = source.ModifyDate,
                IsCreatedPost = source.IsCreatedPost,
                Cat1 = source.Cat1,
                Cat2 = source.Cat2,
                Cat3 = source.Cat3,
                Tag1 = source.Tag1,
                Tag2 = source.Tag2,
                Tag3 = source.Tag3,
                Tag4 = source.Tag4,
                Tag5 = source.Tag5,
                Tag6 = source.Tag6,
                Tag7 = source.Tag7,
                Tag8 = source.Tag8,
                Tag9 = source.Tag9,
                Tag10 = source.Tag10,
                FootCategory = source.FootCategory,
                DateTimePost = source.DateTimePost,
                ContentPost1_6 = source.ContentPost1_6,
                ContentPost1_7 = source.ContentPost1_7,
            };

            return result;
        }
    }

    public class VM2M_Post_Converter : ITypeConverter<VM_Post, Post>
    {
        public Post Convert(VM_Post source, Post destination, ResolutionContext context)
        {
            var result = new Post
            {
                PostID = source.PostID,
                Subject1 = source.Subject1,
                SubSubject1_1 = source.SubSubject1_1,
                SubSubject1_2 = source.SubSubject1_2,
                ContentPost1_1 = source.ContentPost1_1,
                ContentPost1_2 = source.ContentPost1_2,
                ContentPost1_3 = source.ContentPost1_3,
                ContentPost1_4 = source.ContentPost1_4,
                ContentPost1_5 = source.ContentPost1_5,
                Image1_1 = source.Image1_1,
                Image1_2 = source.Image1_2,
                Image1_3 = source.Image1_3,
                Subject2 = source.Subject2,
                SubSubject2_1 = source.SubSubject2_1,
                SubSubject2_2 = source.SubSubject2_2,
                ContentPost2_1 = source.ContentPost2_1,
                ContentPost2_2 = source.ContentPost2_2,
                ContentPost2_3 = source.ContentPost2_3,
                ContentPost2_4 = source.ContentPost2_4,
                ContentPost2_5 = source.ContentPost2_5,
                Image2_1 = source.Image2_1,
                Image2_2 = source.Image2_2,
                Image2_3 = source.Image2_3,
                Subject3 = source.Subject3,
                SubSubject3_1 = source.SubSubject3_1,
                SubSubject3_2 = source.SubSubject3_2,
                ContentPost3_1 = source.ContentPost3_1,
                ContentPost3_2 = source.ContentPost3_2,
                ContentPost3_3 = source.ContentPost3_3,
                ContentPost3_4 = source.ContentPost3_4,
                ContentPost3_5 = source.ContentPost3_5,
                Image3_1 = source.Image3_1,
                Image3_2 = source.Image3_2,
                Image3_3 = source.Image3_3,
                Subject4 = source.Subject4,
                SubSubject4_1 = source.SubSubject4_1,
                SubSubject4_2 = source.SubSubject4_2,
                ContentPost4_1 = source.ContentPost4_1,
                ContentPost4_2 = source.ContentPost4_2,
                ContentPost4_3 = source.ContentPost4_3,
                ContentPost4_4 = source.ContentPost4_4,
                ContentPost4_5 = source.ContentPost4_5,
                Image4_1 = source.Image4_1,
                Image4_2 = source.Image4_2,
                Image4_3 = source.Image4_3,
                Subject5 = source.Subject5,
                SubSubject5_1 = source.SubSubject5_1,
                SubSubject5_2 = source.SubSubject5_2,
                ContentPost5_1 = source.ContentPost5_1,
                ContentPost5_2 = source.ContentPost5_2,
                ContentPost5_3 = source.ContentPost5_3,
                ContentPost5_4 = source.ContentPost5_4,
                ContentPost5_5 = source.ContentPost5_5,
                Image5_1 = source.Image5_1,
                Image5_2 = source.Image5_2,
                Image5_3 = source.Image5_3,
                Subject6 = source.Subject6,
                SubSubject6_1 = source.SubSubject6_1,
                SubSubject6_2 = source.SubSubject6_2,
                ContentPost6_1 = source.ContentPost6_1,
                ContentPost6_2 = source.ContentPost6_2,
                ContentPost6_3 = source.ContentPost6_3,
                ContentPost6_4 = source.ContentPost6_4,
                ContentPost6_5 = source.ContentPost6_5,
                Image6_1 = source.Image6_1,
                Image6_2 = source.Image6_2,
                Image6_3 = source.Image6_3,
                Subject7 = source.Subject7,
                SubSubject7_1 = source.SubSubject7_1,
                SubSubject7_2 = source.SubSubject7_2,
                ContentPost7_1 = source.ContentPost7_1,
                ContentPost7_2 = source.ContentPost7_2,
                ContentPost7_3 = source.ContentPost7_3,
                ContentPost7_4 = source.ContentPost7_3,
                ContentPost7_5 = source.ContentPost7_5,
                Image7_1 = source.Image7_1,
                Image7_2 = source.Image7_2,
                Image7_3 = source.Image7_3,
                Subject8 = source.Subject8,
                SubSubject8_1 = source.SubSubject8_1,
                SubSubject8_2 = source.SubSubject8_2,
                ContentPost8_1 = source.ContentPost8_1,
                ContentPost8_2 = source.ContentPost8_2,
                ContentPost8_3 = source.ContentPost8_3,
                ContentPost8_4 = source.ContentPost8_4,
                ContentPost8_5 = source.ContentPost8_5,
                Image8_1 = source.Image8_1,
                Image8_2 = source.Image8_2,
                Image8_3 = source.Image8_3,
                Subject9 = source.Subject9,
                SubSubject9_1 = source.SubSubject9_1,
                SubSubject9_2 = source.SubSubject9_2,
                ContentPost9_1 = source.ContentPost9_1,
                ContentPost9_2 = source.ContentPost9_2,
                ContentPost9_3 = source.ContentPost9_3,
                ContentPost9_4 = source.ContentPost9_4,
                ContentPost9_5 = source.ContentPost9_5,
                Image9_1 = source.Image9_1,
                Image9_2 = source.Image9_2,
                Image9_3 = source.Image9_3,
                Subject10 = source.Subject10,
                SubSubject10_1 = source.SubSubject10_1,
                SubSubject10_2 = source.SubSubject10_2,
                ContentPost10_1 = source.ContentPost10_1,
                ContentPost10_2 = source.ContentPost10_2,
                ContentPost10_3 = source.ContentPost10_3,
                ContentPost10_4 = source.ContentPost10_4,
                ContentPost10_5 = source.ContentPost10_5,
                Image10_1 = source.Image10_1,
                Image10_2 = source.Image10_2,
                Image10_3 = source.Image10_3,
                Subject11 = source.Subject11,
                SubSubject11_1 = source.SubSubject11_1,
                SubSubject11_2 = source.SubSubject11_2,
                ContentPost11_1 = source.ContentPost11_1,
                ContentPost11_2 = source.ContentPost11_2,
                ContentPost11_3 = source.ContentPost11_3,
                ContentPost11_4 = source.ContentPost11_4,
                ContentPost11_5 = source.ContentPost11_5,
                Image11_1 = source.Image11_1,
                Image11_2 = source.Image11_2,
                Image11_3 = source.Image11_3,
                Subject12 = source.Subject12,
                SubSubject12_1 = source.SubSubject12_1,
                SubSubject12_2 = source.SubSubject12_2,
                ContentPost12_1 = source.ContentPost12_1,
                ContentPost12_2 = source.ContentPost12_2,
                ContentPost12_3 = source.ContentPost12_3,
                ContentPost12_4 = source.ContentPost12_4,
                ContentPost12_5 = source.ContentPost12_5,
                Image12_1 = source.Image12_1,
                Image12_2 = source.Image12_2,
                Image12_3 = source.Image12_3,
                Subject13 = source.Subject13,
                SubSubject13_1 = source.SubSubject13_1,
                SubSubject13_2 = source.SubSubject13_2,
                ContentPost13_1 = source.ContentPost13_1,
                ContentPost13_2 = source.ContentPost13_2,
                ContentPost13_3 = source.ContentPost13_3,
                ContentPost13_4 = source.ContentPost13_4,
                ContentPost13_5 = source.ContentPost13_5,
                Image13_1 = source.Image13_1,
                Image13_2 = source.Image13_2,
                Image13_3 = source.Image13_3,
                Subject14 = source.Subject14,
                SubSubject14_1 = source.SubSubject14_1,
                SubSubject14_2 = source.SubSubject14_2,
                ContentPost14_1 = source.ContentPost14_1,
                ContentPost14_2 = source.ContentPost14_2,
                ContentPost14_3 = source.ContentPost14_3,
                ContentPost14_4 = source.ContentPost14_4,
                ContentPost14_5 = source.ContentPost14_5,
                Image14_1 = source.Image14_1,
                Image14_2 = source.Image14_2,
                Image14_3 = source.Image14_3,
                Subject15 = source.Subject15,
                SubSubject15_1 = source.SubSubject15_1,
                SubSubject15_2 = source.SubSubject15_2,
                ContentPost15_1 = source.ContentPost15_1,
                ContentPost15_2 = source.ContentPost15_2,
                ContentPost15_3 = source.ContentPost15_3,
                ContentPost15_4 = source.ContentPost15_4,
                ContentPost15_5 = source.ContentPost15_5,
                Image15_1 = source.Image15_1,
                Image15_2 = source.Image15_2,
                Image15_3 = source.Image15_3,
                Subject16 = source.Subject16,
                SubSubject16_1 = source.SubSubject16_1,
                SubSubject16_2 = source.SubSubject16_2,
                ContentPost16_1 = source.ContentPost16_1,
                ContentPost16_2 = source.ContentPost16_2,
                ContentPost16_3 = source.ContentPost16_3,
                ContentPost16_4 = source.ContentPost16_4,
                ContentPost16_5 = source.ContentPost16_5,
                Image16_1 = source.Image16_1,
                Image16_2 = source.Image16_2,
                Image16_3 = source.Image16_3,
                Subject17 = source.Subject17,
                SubSubject17_1 = source.SubSubject17_1,
                SubSubject17_2 = source.SubSubject17_2,
                ContentPost17_1 = source.ContentPost17_1,
                ContentPost17_2 = source.ContentPost17_2,
                ContentPost17_3 = source.ContentPost17_3,
                ContentPost17_4 = source.ContentPost17_4,
                ContentPost17_5 = source.ContentPost17_5,
                Image17_1 = source.Image17_1,
                Image17_2 = source.Image17_2,
                Image17_3 = source.Image17_3,
                Subject18 = source.Subject18,
                SubSubject18_1 = source.SubSubject18_1,
                SubSubject18_2 = source.SubSubject18_2,
                ContentPost18_1 = source.ContentPost18_1,
                ContentPost18_2 = source.ContentPost18_2,
                ContentPost18_3 = source.ContentPost18_3,
                ContentPost18_4 = source.ContentPost18_4,
                ContentPost18_5 = source.ContentPost18_5,
                Image18_1 = source.Image18_1,
                Image18_2 = source.Image18_2,
                Image18_3 = source.Image18_3,
                Subject19 = source.Subject19,
                SubSubject19_1 = source.SubSubject19_1,
                SubSubject19_2 = source.SubSubject19_2,
                ContentPost19_1 = source.ContentPost19_1,
                ContentPost19_2 = source.ContentPost19_2,
                ContentPost19_3 = source.ContentPost19_3,
                ContentPost19_4 = source.ContentPost19_4,
                ContentPost19_5 = source.ContentPost19_5,
                Image19_1 = source.Image19_1,
                Image19_2 = source.Image19_2,
                Image19_3 = source.Image19_3,
                Subject20 = source.Subject20,
                SubSubject20_1 = source.SubSubject20_1,
                SubSubject20_2 = source.SubSubject20_2,
                ContentPost20_1 = source.ContentPost20_1,
                ContentPost20_2 = source.ContentPost20_2,
                ContentPost20_3 = source.ContentPost20_3,
                ContentPost20_4 = source.ContentPost20_4,
                ContentPost20_5 = source.ContentPost20_5,
                Image20_1 = source.Image20_1,
                Image20_2 = source.Image20_2,
                Image20_3 = source.Image20_3,
                QuotedFrom = source.QuotedFrom,
                Url = source.Url,
                UrlMP3 = source.UrlMP3,
                UrlVideo = source.UrlVideo,
                Views = source.Views,
                LikePost = source.LikePost,
                DislikePost = source.DislikePost,
                PublishCount = source.PublishCount,
                BackgroundColor = source.BackgroundColor,
                ModifyUserID = source.ModifyUserID,
                ModifyDate = source.ModifyDate,
                IsCreatedPost = source.IsCreatedPost,
                Cat1 = source.Cat1,
                Cat2 = source.Cat2,
                Cat3 = source.Cat3,
                Tag1 = source.Tag1,
                Tag2 = source.Tag2,
                Tag3 = source.Tag3,
                Tag4 = source.Tag4,
                Tag5 = source.Tag5,
                Tag6 = source.Tag6,
                Tag7 = source.Tag7,
                Tag8 = source.Tag8,
                Tag9 = source.Tag9,
                Tag10 = source.Tag10,
                FootCategory = source.FootCategory,
                DateTimePost = source.DateTimePost,
                ContentPost1_6 = source.ContentPost1_6,
                ContentPost1_7 = source.ContentPost1_7,
            };

            return result;
        }
    }
}