USE [master]
GO
/****** Object:  Database [GossipSite]    Script Date: 12/04/2018 16:37:42 ******/
CREATE DATABASE [GossipSite] ON  PRIMARY 
( NAME = N'GossipSite', FILENAME = N'E:\mahmood\me\GossipWebApp\GossipDashboard\DataBase\GossipSite.mdf' , SIZE = 21504KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GossipSite_log', FILENAME = N'E:\mahmood\me\GossipWebApp\GossipDashboard\DataBase\GossipSite_log.ldf' , SIZE = 5184KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GossipSite] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GossipSite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GossipSite] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [GossipSite] SET ANSI_NULLS OFF
GO
ALTER DATABASE [GossipSite] SET ANSI_PADDING OFF
GO
ALTER DATABASE [GossipSite] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [GossipSite] SET ARITHABORT OFF
GO
ALTER DATABASE [GossipSite] SET AUTO_CLOSE ON
GO
ALTER DATABASE [GossipSite] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [GossipSite] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [GossipSite] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [GossipSite] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [GossipSite] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [GossipSite] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [GossipSite] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [GossipSite] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [GossipSite] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [GossipSite] SET  DISABLE_BROKER
GO
ALTER DATABASE [GossipSite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [GossipSite] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [GossipSite] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [GossipSite] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [GossipSite] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [GossipSite] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [GossipSite] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [GossipSite] SET  READ_WRITE
GO
ALTER DATABASE [GossipSite] SET RECOVERY SIMPLE
GO
ALTER DATABASE [GossipSite] SET  MULTI_USER
GO
ALTER DATABASE [GossipSite] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [GossipSite] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'GossipSite', N'ON'
GO
USE [GossipSite]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/04/2018 16:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](200) NULL,
	[LastName] [nvarchar](500) NULL,
	[Salt] [nvarchar](1000) NOT NULL,
	[Password] [nvarchar](1000) NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Image] [varbinary](max) NULL,
	[AboutUser] [nvarchar](3000) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Subscriber]    Script Date: 12/04/2018 16:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscriber](
	[SubscriberID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NOT NULL,
	[IPAddress] [nvarchar](50) NULL,
	[WebSite] [nvarchar](200) NULL,
	[Message] [nvarchar](max) NULL,
	[ModifyDateTime] [datetime] NULL,
 CONSTRAINT [PK_Subscriber] PRIMARY KEY CLUSTERED 
(
	[SubscriberID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PubBase]    Script Date: 12/04/2018 16:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PubBase](
	[PubBaseID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[NameFa] [nvarchar](500) NOT NULL,
	[NameEn] [nvarchar](500) NULL,
	[GroupBase] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[ClassName] [varchar](500) NULL,
	[AbobeClassName] [varchar](500) NULL,
	[Active] [bit] NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_PubBase] PRIMARY KEY CLUSTERED 
(
	[PubBaseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'لینک مربعی شکل بالای هر پست' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PubBase', @level2type=N'COLUMN',@level2name=N'AbobeClassName'
GO
/****** Object:  Table [dbo].[PostTemperory]    Script Date: 12/04/2018 16:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostTemperory](
	[PostID] [int] IDENTITY(1,1) NOT NULL,
	[Subject1] [nvarchar](max) NULL,
	[SubSubject1_1] [nvarchar](max) NULL,
	[SubSubject1_2] [nvarchar](max) NULL,
	[ContentPost1_1] [nvarchar](max) NULL,
	[ContentPost1_2] [nvarchar](max) NULL,
	[ContentPost1_3] [nvarchar](max) NULL,
	[ContentPost1_4] [nvarchar](max) NULL,
	[ContentPost1_5] [nvarchar](max) NULL,
	[Image1_1] [nvarchar](1000) NULL,
	[Image1_2] [nvarchar](1000) NULL,
	[Image1_3] [nvarchar](1000) NULL,
	[Subject2] [nvarchar](max) NULL,
	[SubSubject2_1] [nvarchar](max) NULL,
	[SubSubject2_2] [nvarchar](max) NULL,
	[ContentPost2_1] [nvarchar](max) NULL,
	[ContentPost2_2] [nvarchar](max) NULL,
	[ContentPost2_3] [nvarchar](max) NULL,
	[ContentPost2_4] [nvarchar](max) NULL,
	[ContentPost2_5] [nvarchar](max) NULL,
	[Image2_1] [nvarchar](1000) NULL,
	[Image2_2] [nvarchar](1000) NULL,
	[Image2_3] [nvarchar](1000) NULL,
	[Subject3] [nvarchar](max) NULL,
	[SubSubject3_1] [nvarchar](max) NULL,
	[SubSubject3_2] [nvarchar](max) NULL,
	[ContentPost3_1] [nvarchar](max) NULL,
	[ContentPost3_2] [nvarchar](max) NULL,
	[ContentPost3_3] [nvarchar](max) NULL,
	[ContentPost3_4] [nvarchar](max) NULL,
	[ContentPost3_5] [nvarchar](max) NULL,
	[Image3_1] [nvarchar](1000) NULL,
	[Image3_2] [nvarchar](1000) NULL,
	[Image3_3] [nvarchar](1000) NULL,
	[Subject4] [nvarchar](max) NULL,
	[SubSubject4_1] [nvarchar](max) NULL,
	[SubSubject4_2] [nvarchar](max) NULL,
	[ContentPost4_1] [nvarchar](max) NULL,
	[ContentPost4_2] [nvarchar](max) NULL,
	[ContentPost4_3] [nvarchar](max) NULL,
	[ContentPost4_4] [nvarchar](max) NULL,
	[ContentPost4_5] [nvarchar](max) NULL,
	[Image4_1] [nvarchar](1000) NULL,
	[Image4_2] [nvarchar](1000) NULL,
	[Image4_3] [nvarchar](1000) NULL,
	[Subject5] [nvarchar](max) NULL,
	[SubSubject5_1] [nvarchar](max) NULL,
	[SubSubject5_2] [nvarchar](max) NULL,
	[ContentPost5_1] [nvarchar](max) NULL,
	[ContentPost5_2] [nvarchar](max) NULL,
	[ContentPost5_3] [nvarchar](max) NULL,
	[ContentPost5_4] [nvarchar](max) NULL,
	[ContentPost5_5] [nvarchar](max) NULL,
	[Image5_1] [nvarchar](1000) NULL,
	[Image5_2] [nvarchar](1000) NULL,
	[Image5_3] [nvarchar](1000) NULL,
	[Subject6] [nvarchar](max) NULL,
	[SubSubject6_1] [nvarchar](max) NULL,
	[SubSubject6_2] [nvarchar](max) NULL,
	[ContentPost6_1] [nvarchar](max) NULL,
	[ContentPost6_2] [nvarchar](max) NULL,
	[ContentPost6_3] [nvarchar](max) NULL,
	[ContentPost6_4] [nvarchar](max) NULL,
	[ContentPost6_5] [nvarchar](max) NULL,
	[Image6_1] [nvarchar](1000) NULL,
	[Image6_2] [nvarchar](1000) NULL,
	[Image6_3] [nvarchar](1000) NULL,
	[Subject7] [nvarchar](max) NULL,
	[SubSubject7_1] [nvarchar](max) NULL,
	[SubSubject7_2] [nvarchar](max) NULL,
	[ContentPost7_1] [nvarchar](max) NULL,
	[ContentPost7_2] [nvarchar](max) NULL,
	[ContentPost7_3] [nvarchar](max) NULL,
	[ContentPost7_4] [nvarchar](max) NULL,
	[ContentPost7_5] [nvarchar](max) NULL,
	[Image7_1] [nvarchar](1000) NULL,
	[Image7_2] [nvarchar](1000) NULL,
	[Image7_3] [nvarchar](1000) NULL,
	[Subject8] [nvarchar](max) NULL,
	[SubSubject8_1] [nvarchar](max) NULL,
	[SubSubject8_2] [nvarchar](max) NULL,
	[ContentPost8_1] [nvarchar](max) NULL,
	[ContentPost8_2] [nvarchar](max) NULL,
	[ContentPost8_3] [nvarchar](max) NULL,
	[ContentPost8_4] [nvarchar](max) NULL,
	[ContentPost8_5] [nvarchar](max) NULL,
	[Image8_1] [nvarchar](1000) NULL,
	[Image8_2] [nvarchar](1000) NULL,
	[Image8_3] [nvarchar](1000) NULL,
	[Subject9] [nvarchar](max) NULL,
	[SubSubject9_1] [nvarchar](max) NULL,
	[SubSubject9_2] [nvarchar](max) NULL,
	[ContentPost9_1] [nvarchar](max) NULL,
	[ContentPost9_2] [nvarchar](max) NULL,
	[ContentPost9_3] [nvarchar](max) NULL,
	[ContentPost9_4] [nvarchar](max) NULL,
	[ContentPost9_5] [nvarchar](max) NULL,
	[Image9_1] [nvarchar](1000) NULL,
	[Image9_2] [nvarchar](1000) NULL,
	[Image9_3] [nvarchar](1000) NULL,
	[Subject10] [nvarchar](max) NULL,
	[SubSubject10_1] [nvarchar](max) NULL,
	[SubSubject10_2] [nvarchar](max) NULL,
	[ContentPost10_1] [nvarchar](max) NULL,
	[ContentPost10_2] [nvarchar](max) NULL,
	[ContentPost10_3] [nvarchar](max) NULL,
	[ContentPost10_4] [nvarchar](max) NULL,
	[ContentPost10_5] [nvarchar](max) NULL,
	[Image10_1] [nvarchar](1000) NULL,
	[Image10_2] [nvarchar](1000) NULL,
	[Image10_3] [nvarchar](1000) NULL,
	[Subject11] [nvarchar](max) NULL,
	[SubSubject11_1] [nvarchar](max) NULL,
	[SubSubject11_2] [nvarchar](max) NULL,
	[ContentPost11_1] [nvarchar](max) NULL,
	[ContentPost11_2] [nvarchar](max) NULL,
	[ContentPost11_3] [nvarchar](max) NULL,
	[ContentPost11_4] [nvarchar](max) NULL,
	[ContentPost11_5] [nvarchar](max) NULL,
	[Image11_1] [nvarchar](1000) NULL,
	[Image11_2] [nvarchar](1000) NULL,
	[Image11_3] [nvarchar](1000) NULL,
	[Subject12] [nvarchar](max) NULL,
	[SubSubject12_1] [nvarchar](max) NULL,
	[SubSubject12_2] [nvarchar](max) NULL,
	[ContentPost12_1] [nvarchar](max) NULL,
	[ContentPost12_2] [nvarchar](max) NULL,
	[ContentPost12_3] [nvarchar](max) NULL,
	[ContentPost12_4] [nvarchar](max) NULL,
	[ContentPost12_5] [nvarchar](max) NULL,
	[Image12_1] [nvarchar](1000) NULL,
	[Image12_2] [nvarchar](1000) NULL,
	[Image12_3] [nvarchar](1000) NULL,
	[Subject13] [nvarchar](max) NULL,
	[SubSubject13_1] [nvarchar](max) NULL,
	[SubSubject13_2] [nvarchar](max) NULL,
	[ContentPost13_1] [nvarchar](max) NULL,
	[ContentPost13_2] [nvarchar](max) NULL,
	[ContentPost13_3] [nvarchar](max) NULL,
	[ContentPost13_4] [nvarchar](max) NULL,
	[ContentPost13_5] [nvarchar](max) NULL,
	[Image13_1] [nvarchar](1000) NULL,
	[Image13_2] [nvarchar](1000) NULL,
	[Image13_3] [nvarchar](1000) NULL,
	[Subject14] [nvarchar](max) NULL,
	[SubSubject14_1] [nvarchar](max) NULL,
	[SubSubject14_2] [nvarchar](max) NULL,
	[ContentPost14_1] [nvarchar](max) NULL,
	[ContentPost14_2] [nvarchar](max) NULL,
	[ContentPost14_3] [nvarchar](max) NULL,
	[ContentPost14_4] [nvarchar](max) NULL,
	[ContentPost14_5] [nvarchar](max) NULL,
	[Image14_1] [nvarchar](1000) NULL,
	[Image14_2] [nvarchar](1000) NULL,
	[Image14_3] [nvarchar](1000) NULL,
	[Subject15] [nvarchar](max) NULL,
	[SubSubject15_1] [nvarchar](max) NULL,
	[SubSubject15_2] [nvarchar](max) NULL,
	[ContentPost15_1] [nvarchar](max) NULL,
	[ContentPost15_2] [nvarchar](max) NULL,
	[ContentPost15_3] [nvarchar](max) NULL,
	[ContentPost15_4] [nvarchar](max) NULL,
	[ContentPost15_5] [nvarchar](max) NULL,
	[Image15_1] [nvarchar](1000) NULL,
	[Image15_2] [nvarchar](1000) NULL,
	[Image15_3] [nvarchar](1000) NULL,
	[Subject16] [nvarchar](max) NULL,
	[SubSubject16_1] [nvarchar](max) NULL,
	[SubSubject16_2] [nvarchar](max) NULL,
	[ContentPost16_1] [nvarchar](max) NULL,
	[ContentPost16_2] [nvarchar](max) NULL,
	[ContentPost16_3] [nvarchar](max) NULL,
	[ContentPost16_4] [nvarchar](max) NULL,
	[ContentPost16_5] [nvarchar](max) NULL,
	[Image16_1] [nvarchar](1000) NULL,
	[Image16_2] [nvarchar](1000) NULL,
	[Image16_3] [nvarchar](1000) NULL,
	[Subject17] [nvarchar](max) NULL,
	[SubSubject17_1] [nvarchar](max) NULL,
	[SubSubject17_2] [nvarchar](max) NULL,
	[ContentPost17_1] [nvarchar](max) NULL,
	[ContentPost17_2] [nvarchar](max) NULL,
	[ContentPost17_3] [nvarchar](max) NULL,
	[ContentPost17_4] [nvarchar](max) NULL,
	[ContentPost17_5] [nvarchar](max) NULL,
	[Image17_1] [nvarchar](1000) NULL,
	[Image17_2] [nvarchar](1000) NULL,
	[Image17_3] [nvarchar](1000) NULL,
	[Subject18] [nvarchar](max) NULL,
	[SubSubject18_1] [nvarchar](max) NULL,
	[SubSubject18_2] [nvarchar](max) NULL,
	[ContentPost18_1] [nvarchar](max) NULL,
	[ContentPost18_2] [nvarchar](max) NULL,
	[ContentPost18_3] [nvarchar](max) NULL,
	[ContentPost18_4] [nvarchar](max) NULL,
	[ContentPost18_5] [nvarchar](max) NULL,
	[Image18_1] [nvarchar](1000) NULL,
	[Image18_2] [nvarchar](1000) NULL,
	[Image18_3] [nvarchar](1000) NULL,
	[Subject19] [nvarchar](max) NULL,
	[SubSubject19_1] [nvarchar](max) NULL,
	[SubSubject19_2] [nvarchar](max) NULL,
	[ContentPost19_1] [nvarchar](max) NULL,
	[ContentPost19_2] [nvarchar](max) NULL,
	[ContentPost19_3] [nvarchar](max) NULL,
	[ContentPost19_4] [nvarchar](max) NULL,
	[ContentPost19_5] [nvarchar](max) NULL,
	[Image19_1] [nvarchar](1000) NULL,
	[Image19_2] [nvarchar](1000) NULL,
	[Image19_3] [nvarchar](1000) NULL,
	[Subject20] [nvarchar](max) NULL,
	[SubSubject20_1] [nvarchar](max) NULL,
	[SubSubject20_2] [nvarchar](max) NULL,
	[ContentPost20_1] [nvarchar](max) NULL,
	[ContentPost20_2] [nvarchar](max) NULL,
	[ContentPost20_3] [nvarchar](max) NULL,
	[ContentPost20_4] [nvarchar](max) NULL,
	[ContentPost20_5] [nvarchar](max) NULL,
	[Image20_1] [nvarchar](1000) NULL,
	[Image20_2] [nvarchar](1000) NULL,
	[Image20_3] [nvarchar](1000) NULL,
	[QuotedFrom] [nvarchar](1000) NULL,
	[Url] [nvarchar](2000) NULL,
	[UrlMP3] [nvarchar](2000) NULL,
	[UrlVideo] [nvarchar](2000) NULL,
	[Views] [nvarchar](100) NULL,
	[LikePost] [int] NULL,
	[DislikePost] [int] NULL,
	[PublishCount] [int] NULL,
	[BackgroundColor] [nvarchar](50) NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[IsCreatedPost] [bit] NULL,
	[Cat1] [nvarchar](100) NULL,
	[Cat2] [nvarchar](100) NULL,
	[Cat3] [nvarchar](100) NULL,
	[Tag1] [nvarchar](1000) NULL,
	[Tag2] [nvarchar](1000) NULL,
	[Tag3] [nvarchar](1000) NULL,
	[Tag4] [nvarchar](1000) NULL,
	[Tag5] [nvarchar](1000) NULL,
	[Tag6] [nvarchar](1000) NULL,
	[Tag7] [nvarchar](1000) NULL,
	[Tag8] [nvarchar](1000) NULL,
	[Tag9] [nvarchar](1000) NULL,
	[Tag10] [nvarchar](1000) NULL,
	[ContentPost1_6] [nvarchar](max) NULL,
	[ContentPost1_7] [nvarchar](max) NULL,
	[HTML] [nvarchar](max) NULL,
	[SourceSiteUrl] [nvarchar](1000) NULL,
	[SourceFootCategory] [nvarchar](1000) NULL,
	[SourceDateTimePost] [nvarchar](200) NULL,
	[SourceSiteView] [nvarchar](200) NULL,
	[SourceSiteAuthor] [nvarchar](200) NULL,
	[SourceSiteName] [nvarchar](1000) NULL,
	[ContentHTML] [nvarchar](max) NULL,
	[ScriptAparat] [nvarchar](2000) NULL,
	[SourceSiteLike] [nvarchar](50) NULL,
	[SourceSiteQoute] [nvarchar](200) NULL,
 CONSTRAINT [PK_PostTemperory] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ردپای پست از سایت مرجع' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PostTemperory', @level2type=N'COLUMN',@level2name=N'SourceFootCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان پست از سایت مرجع' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PostTemperory', @level2type=N'COLUMN',@level2name=N'SourceDateTimePost'
GO
/****** Object:  Table [dbo].[Post]    Script Date: 12/04/2018 16:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostID] [int] IDENTITY(1,1) NOT NULL,
	[Subject1] [nvarchar](max) NULL,
	[SubSubject1_1] [nvarchar](max) NULL,
	[SubSubject1_2] [nvarchar](max) NULL,
	[ContentPost1_1] [nvarchar](max) NULL,
	[ContentPost1_2] [nvarchar](max) NULL,
	[ContentPost1_3] [nvarchar](max) NULL,
	[ContentPost1_4] [nvarchar](max) NULL,
	[ContentPost1_5] [nvarchar](max) NULL,
	[Image1_1] [nvarchar](1000) NULL,
	[Image1_2] [nvarchar](1000) NULL,
	[Image1_3] [nvarchar](1000) NULL,
	[Subject2] [nvarchar](max) NULL,
	[SubSubject2_1] [nvarchar](max) NULL,
	[SubSubject2_2] [nvarchar](max) NULL,
	[ContentPost2_1] [nvarchar](max) NULL,
	[ContentPost2_2] [nvarchar](max) NULL,
	[ContentPost2_3] [nvarchar](max) NULL,
	[ContentPost2_4] [nvarchar](max) NULL,
	[ContentPost2_5] [nvarchar](max) NULL,
	[Image2_1] [nvarchar](1000) NULL,
	[Image2_2] [nvarchar](1000) NULL,
	[Image2_3] [nvarchar](1000) NULL,
	[Subject3] [nvarchar](max) NULL,
	[SubSubject3_1] [nvarchar](max) NULL,
	[SubSubject3_2] [nvarchar](max) NULL,
	[ContentPost3_1] [nvarchar](max) NULL,
	[ContentPost3_2] [nvarchar](max) NULL,
	[ContentPost3_3] [nvarchar](max) NULL,
	[ContentPost3_4] [nvarchar](max) NULL,
	[ContentPost3_5] [nvarchar](max) NULL,
	[Image3_1] [nvarchar](1000) NULL,
	[Image3_2] [nvarchar](1000) NULL,
	[Image3_3] [nvarchar](1000) NULL,
	[Subject4] [nvarchar](max) NULL,
	[SubSubject4_1] [nvarchar](max) NULL,
	[SubSubject4_2] [nvarchar](max) NULL,
	[ContentPost4_1] [nvarchar](max) NULL,
	[ContentPost4_2] [nvarchar](max) NULL,
	[ContentPost4_3] [nvarchar](max) NULL,
	[ContentPost4_4] [nvarchar](max) NULL,
	[ContentPost4_5] [nvarchar](max) NULL,
	[Image4_1] [nvarchar](1000) NULL,
	[Image4_2] [nvarchar](1000) NULL,
	[Image4_3] [nvarchar](1000) NULL,
	[Subject5] [nvarchar](max) NULL,
	[SubSubject5_1] [nvarchar](max) NULL,
	[SubSubject5_2] [nvarchar](max) NULL,
	[ContentPost5_1] [nvarchar](max) NULL,
	[ContentPost5_2] [nvarchar](max) NULL,
	[ContentPost5_3] [nvarchar](max) NULL,
	[ContentPost5_4] [nvarchar](max) NULL,
	[ContentPost5_5] [nvarchar](max) NULL,
	[Image5_1] [nvarchar](1000) NULL,
	[Image5_2] [nvarchar](1000) NULL,
	[Image5_3] [nvarchar](1000) NULL,
	[Subject6] [nvarchar](max) NULL,
	[SubSubject6_1] [nvarchar](max) NULL,
	[SubSubject6_2] [nvarchar](max) NULL,
	[ContentPost6_1] [nvarchar](max) NULL,
	[ContentPost6_2] [nvarchar](max) NULL,
	[ContentPost6_3] [nvarchar](max) NULL,
	[ContentPost6_4] [nvarchar](max) NULL,
	[ContentPost6_5] [nvarchar](max) NULL,
	[Image6_1] [nvarchar](1000) NULL,
	[Image6_2] [nvarchar](1000) NULL,
	[Image6_3] [nvarchar](1000) NULL,
	[Subject7] [nvarchar](max) NULL,
	[SubSubject7_1] [nvarchar](max) NULL,
	[SubSubject7_2] [nvarchar](max) NULL,
	[ContentPost7_1] [nvarchar](max) NULL,
	[ContentPost7_2] [nvarchar](max) NULL,
	[ContentPost7_3] [nvarchar](max) NULL,
	[ContentPost7_4] [nvarchar](max) NULL,
	[ContentPost7_5] [nvarchar](max) NULL,
	[Image7_1] [nvarchar](1000) NULL,
	[Image7_2] [nvarchar](1000) NULL,
	[Image7_3] [nvarchar](1000) NULL,
	[Subject8] [nvarchar](max) NULL,
	[SubSubject8_1] [nvarchar](max) NULL,
	[SubSubject8_2] [nvarchar](max) NULL,
	[ContentPost8_1] [nvarchar](max) NULL,
	[ContentPost8_2] [nvarchar](max) NULL,
	[ContentPost8_3] [nvarchar](max) NULL,
	[ContentPost8_4] [nvarchar](max) NULL,
	[ContentPost8_5] [nvarchar](max) NULL,
	[Image8_1] [nvarchar](1000) NULL,
	[Image8_2] [nvarchar](1000) NULL,
	[Image8_3] [nvarchar](1000) NULL,
	[Subject9] [nvarchar](max) NULL,
	[SubSubject9_1] [nvarchar](max) NULL,
	[SubSubject9_2] [nvarchar](max) NULL,
	[ContentPost9_1] [nvarchar](max) NULL,
	[ContentPost9_2] [nvarchar](max) NULL,
	[ContentPost9_3] [nvarchar](max) NULL,
	[ContentPost9_4] [nvarchar](max) NULL,
	[ContentPost9_5] [nvarchar](max) NULL,
	[Image9_1] [nvarchar](1000) NULL,
	[Image9_2] [nvarchar](1000) NULL,
	[Image9_3] [nvarchar](1000) NULL,
	[Subject10] [nvarchar](max) NULL,
	[SubSubject10_1] [nvarchar](max) NULL,
	[SubSubject10_2] [nvarchar](max) NULL,
	[ContentPost10_1] [nvarchar](max) NULL,
	[ContentPost10_2] [nvarchar](max) NULL,
	[ContentPost10_3] [nvarchar](max) NULL,
	[ContentPost10_4] [nvarchar](max) NULL,
	[ContentPost10_5] [nvarchar](max) NULL,
	[Image10_1] [nvarchar](1000) NULL,
	[Image10_2] [nvarchar](1000) NULL,
	[Image10_3] [nvarchar](1000) NULL,
	[Subject11] [nvarchar](max) NULL,
	[SubSubject11_1] [nvarchar](max) NULL,
	[SubSubject11_2] [nvarchar](max) NULL,
	[ContentPost11_1] [nvarchar](max) NULL,
	[ContentPost11_2] [nvarchar](max) NULL,
	[ContentPost11_3] [nvarchar](max) NULL,
	[ContentPost11_4] [nvarchar](max) NULL,
	[ContentPost11_5] [nvarchar](max) NULL,
	[Image11_1] [nvarchar](1000) NULL,
	[Image11_2] [nvarchar](1000) NULL,
	[Image11_3] [nvarchar](1000) NULL,
	[Subject12] [nvarchar](max) NULL,
	[SubSubject12_1] [nvarchar](max) NULL,
	[SubSubject12_2] [nvarchar](max) NULL,
	[ContentPost12_1] [nvarchar](max) NULL,
	[ContentPost12_2] [nvarchar](max) NULL,
	[ContentPost12_3] [nvarchar](max) NULL,
	[ContentPost12_4] [nvarchar](max) NULL,
	[ContentPost12_5] [nvarchar](max) NULL,
	[Image12_1] [nvarchar](1000) NULL,
	[Image12_2] [nvarchar](1000) NULL,
	[Image12_3] [nvarchar](1000) NULL,
	[Subject13] [nvarchar](max) NULL,
	[SubSubject13_1] [nvarchar](max) NULL,
	[SubSubject13_2] [nvarchar](max) NULL,
	[ContentPost13_1] [nvarchar](max) NULL,
	[ContentPost13_2] [nvarchar](max) NULL,
	[ContentPost13_3] [nvarchar](max) NULL,
	[ContentPost13_4] [nvarchar](max) NULL,
	[ContentPost13_5] [nvarchar](max) NULL,
	[Image13_1] [nvarchar](1000) NULL,
	[Image13_2] [nvarchar](1000) NULL,
	[Image13_3] [nvarchar](1000) NULL,
	[Subject14] [nvarchar](max) NULL,
	[SubSubject14_1] [nvarchar](max) NULL,
	[SubSubject14_2] [nvarchar](max) NULL,
	[ContentPost14_1] [nvarchar](max) NULL,
	[ContentPost14_2] [nvarchar](max) NULL,
	[ContentPost14_3] [nvarchar](max) NULL,
	[ContentPost14_4] [nvarchar](max) NULL,
	[ContentPost14_5] [nvarchar](max) NULL,
	[Image14_1] [nvarchar](1000) NULL,
	[Image14_2] [nvarchar](1000) NULL,
	[Image14_3] [nvarchar](1000) NULL,
	[Subject15] [nvarchar](max) NULL,
	[SubSubject15_1] [nvarchar](max) NULL,
	[SubSubject15_2] [nvarchar](max) NULL,
	[ContentPost15_1] [nvarchar](max) NULL,
	[ContentPost15_2] [nvarchar](max) NULL,
	[ContentPost15_3] [nvarchar](max) NULL,
	[ContentPost15_4] [nvarchar](max) NULL,
	[ContentPost15_5] [nvarchar](max) NULL,
	[Image15_1] [nvarchar](1000) NULL,
	[Image15_2] [nvarchar](1000) NULL,
	[Image15_3] [nvarchar](1000) NULL,
	[Subject16] [nvarchar](max) NULL,
	[SubSubject16_1] [nvarchar](max) NULL,
	[SubSubject16_2] [nvarchar](max) NULL,
	[ContentPost16_1] [nvarchar](max) NULL,
	[ContentPost16_2] [nvarchar](max) NULL,
	[ContentPost16_3] [nvarchar](max) NULL,
	[ContentPost16_4] [nvarchar](max) NULL,
	[ContentPost16_5] [nvarchar](max) NULL,
	[Image16_1] [nvarchar](1000) NULL,
	[Image16_2] [nvarchar](1000) NULL,
	[Image16_3] [nvarchar](1000) NULL,
	[Subject17] [nvarchar](max) NULL,
	[SubSubject17_1] [nvarchar](max) NULL,
	[SubSubject17_2] [nvarchar](max) NULL,
	[ContentPost17_1] [nvarchar](max) NULL,
	[ContentPost17_2] [nvarchar](max) NULL,
	[ContentPost17_3] [nvarchar](max) NULL,
	[ContentPost17_4] [nvarchar](max) NULL,
	[ContentPost17_5] [nvarchar](max) NULL,
	[Image17_1] [nvarchar](1000) NULL,
	[Image17_2] [nvarchar](1000) NULL,
	[Image17_3] [nvarchar](1000) NULL,
	[Subject18] [nvarchar](max) NULL,
	[SubSubject18_1] [nvarchar](max) NULL,
	[SubSubject18_2] [nvarchar](max) NULL,
	[ContentPost18_1] [nvarchar](max) NULL,
	[ContentPost18_2] [nvarchar](max) NULL,
	[ContentPost18_3] [nvarchar](max) NULL,
	[ContentPost18_4] [nvarchar](max) NULL,
	[ContentPost18_5] [nvarchar](max) NULL,
	[Image18_1] [nvarchar](1000) NULL,
	[Image18_2] [nvarchar](1000) NULL,
	[Image18_3] [nvarchar](1000) NULL,
	[Subject19] [nvarchar](max) NULL,
	[SubSubject19_1] [nvarchar](max) NULL,
	[SubSubject19_2] [nvarchar](max) NULL,
	[ContentPost19_1] [nvarchar](max) NULL,
	[ContentPost19_2] [nvarchar](max) NULL,
	[ContentPost19_3] [nvarchar](max) NULL,
	[ContentPost19_4] [nvarchar](max) NULL,
	[ContentPost19_5] [nvarchar](max) NULL,
	[Image19_1] [nvarchar](1000) NULL,
	[Image19_2] [nvarchar](1000) NULL,
	[Image19_3] [nvarchar](1000) NULL,
	[Subject20] [nvarchar](max) NULL,
	[SubSubject20_1] [nvarchar](max) NULL,
	[SubSubject20_2] [nvarchar](max) NULL,
	[ContentPost20_1] [nvarchar](max) NULL,
	[ContentPost20_2] [nvarchar](max) NULL,
	[ContentPost20_3] [nvarchar](max) NULL,
	[ContentPost20_4] [nvarchar](max) NULL,
	[ContentPost20_5] [nvarchar](max) NULL,
	[Image20_1] [nvarchar](1000) NULL,
	[Image20_2] [nvarchar](1000) NULL,
	[Image20_3] [nvarchar](1000) NULL,
	[QuotedFrom] [nvarchar](1000) NULL,
	[Url] [nvarchar](2000) NULL,
	[UrlMP3] [nvarchar](2000) NULL,
	[UrlVideo] [nvarchar](2000) NULL,
	[ScriptAparat] [nvarchar](2000) NULL,
	[Views] [int] NULL,
	[LikePost] [int] NULL,
	[DislikePost] [int] NULL,
	[PublishCount] [int] NULL,
	[BackgroundColor] [nvarchar](50) NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[IsCreatedPost] [bit] NULL,
	[Cat1] [nvarchar](100) NULL,
	[Cat2] [nvarchar](100) NULL,
	[Cat3] [nvarchar](100) NULL,
	[Tag1] [nvarchar](1000) NULL,
	[Tag2] [nvarchar](1000) NULL,
	[Tag3] [nvarchar](1000) NULL,
	[Tag4] [nvarchar](1000) NULL,
	[Tag5] [nvarchar](1000) NULL,
	[Tag6] [nvarchar](1000) NULL,
	[Tag7] [nvarchar](1000) NULL,
	[Tag8] [nvarchar](1000) NULL,
	[Tag9] [nvarchar](1000) NULL,
	[Tag10] [nvarchar](1000) NULL,
	[SourceSiteUrl] [nvarchar](1000) NULL,
	[SourceSiteName] [nvarchar](1000) NULL,
	[SourceFootCategory] [nvarchar](1000) NULL,
	[SourceDateTimePost] [nvarchar](200) NULL,
	[ContentPost1_6] [nvarchar](max) NULL,
	[ContentPost1_7] [nvarchar](max) NULL,
	[SourceSiteNameFa] [nvarchar](1000) NULL,
	[ContentHTML] [nvarchar](max) NULL,
 CONSTRAINT [PK_Post1] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ردپای پست از سایت مرجع' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'SourceFootCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زمان پست از سایت مرجع' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'SourceDateTimePost'
GO
/****** Object:  Table [dbo].[LogError]    Script Date: 12/04/2018 16:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogError](
	[LogErorrID] [int] IDENTITY(1,1) NOT NULL,
	[IP] [nvarchar](50) NULL,
	[ErrorDescription] [nvarchar](max) NULL,
	[ErrorID] [int] NULL,
	[PostName] [nvarchar](200) NULL,
	[PostID] [int] NULL,
	[ModifyDateTime] [datetime] NULL,
 CONSTRAINT [PK_LogError] PRIMARY KEY CLUSTERED 
(
	[LogErorrID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 12/04/2018 16:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[LogTypeID_fk] [int] NULL,
	[IP] [nvarchar](50) NULL,
	[PostName] [nvarchar](200) NULL,
	[PostID] [int] NULL,
	[ModifyDateTime] [datetime] NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPost]    Script Date: 12/04/2018 16:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPost](
	[UserPostID] [int] IDENTITY(1,1) NOT NULL,
	[UserID_fk] [int] NOT NULL,
	[PostID_fk] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_UserPost] PRIMARY KEY CLUSTERED 
(
	[UserPostID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostQuestion]    Script Date: 12/04/2018 16:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostQuestion](
	[PostQuestionID] [int] IDENTITY(1,1) NOT NULL,
	[PostID_fk] [int] NOT NULL,
	[Question] [nvarchar](2000) NOT NULL,
 CONSTRAINT [PK_PostQuestion] PRIMARY KEY CLUSTERED 
(
	[PostQuestionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostComment]    Script Date: 12/04/2018 16:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostComment](
	[PostCommentID] [int] IDENTITY(1,1) NOT NULL,
	[PostID_fk] [int] NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[UserID] [int] NULL,
	[Comment] [nvarchar](4000) NULL,
	[LikeComment] [int] NULL,
	[DislikeComment] [int] NULL,
	[IPAddress] [nvarchar](50) NULL,
	[Datetime] [datetime] NULL,
 CONSTRAINT [PK_PostComment] PRIMARY KEY CLUSTERED 
(
	[PostCommentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostAttribute]    Script Date: 12/04/2018 16:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostAttribute](
	[PostAttributeID] [int] IDENTITY(1,1) NOT NULL,
	[PostID_fk] [int] NULL,
	[AttributeID_fk] [int] NOT NULL,
 CONSTRAINT [PK_PostCategory] PRIMARY KEY CLUSTERED 
(
	[PostAttributeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'طبقه بندي پست. ورزشي هنري و ...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PostAttribute', @level2type=N'COLUMN',@level2name=N'AttributeID_fk'
GO
/****** Object:  Table [dbo].[PostAnswer]    Script Date: 12/04/2018 16:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostAnswer](
	[PostAnswerID] [int] IDENTITY(1,1) NOT NULL,
	[PostQuestionID_fk] [int] NOT NULL,
	[Answer] [bit] NULL,
 CONSTRAINT [PK_PostAnswer] PRIMARY KEY CLUSTERED 
(
	[PostAnswerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_ArcService_Active]    Script Date: 12/04/2018 16:37:43 ******/
ALTER TABLE [dbo].[PubBase] ADD  CONSTRAINT [DF_ArcService_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  ForeignKey [FK_UserPost_Post]    Script Date: 12/04/2018 16:37:43 ******/
ALTER TABLE [dbo].[UserPost]  WITH CHECK ADD  CONSTRAINT [FK_UserPost_Post] FOREIGN KEY([PostID_fk])
REFERENCES [dbo].[Post] ([PostID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserPost] CHECK CONSTRAINT [FK_UserPost_Post]
GO
/****** Object:  ForeignKey [FK_UserPost_User]    Script Date: 12/04/2018 16:37:43 ******/
ALTER TABLE [dbo].[UserPost]  WITH CHECK ADD  CONSTRAINT [FK_UserPost_User] FOREIGN KEY([UserID_fk])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[UserPost] CHECK CONSTRAINT [FK_UserPost_User]
GO
/****** Object:  ForeignKey [FK_PostQuestion_Post]    Script Date: 12/04/2018 16:37:43 ******/
ALTER TABLE [dbo].[PostQuestion]  WITH CHECK ADD  CONSTRAINT [FK_PostQuestion_Post] FOREIGN KEY([PostID_fk])
REFERENCES [dbo].[Post] ([PostID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostQuestion] CHECK CONSTRAINT [FK_PostQuestion_Post]
GO
/****** Object:  ForeignKey [FK_PostComment_Post]    Script Date: 12/04/2018 16:37:43 ******/
ALTER TABLE [dbo].[PostComment]  WITH CHECK ADD  CONSTRAINT [FK_PostComment_Post] FOREIGN KEY([PostID_fk])
REFERENCES [dbo].[Post] ([PostID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostComment] CHECK CONSTRAINT [FK_PostComment_Post]
GO
/****** Object:  ForeignKey [FK_PostAttribute_Post]    Script Date: 12/04/2018 16:37:43 ******/
ALTER TABLE [dbo].[PostAttribute]  WITH CHECK ADD  CONSTRAINT [FK_PostAttribute_Post] FOREIGN KEY([PostID_fk])
REFERENCES [dbo].[Post] ([PostID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostAttribute] CHECK CONSTRAINT [FK_PostAttribute_Post]
GO
/****** Object:  ForeignKey [FK_PostCategory_PubBase]    Script Date: 12/04/2018 16:37:43 ******/
ALTER TABLE [dbo].[PostAttribute]  WITH CHECK ADD  CONSTRAINT [FK_PostCategory_PubBase] FOREIGN KEY([AttributeID_fk])
REFERENCES [dbo].[PubBase] ([PubBaseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostAttribute] CHECK CONSTRAINT [FK_PostCategory_PubBase]
GO
/****** Object:  ForeignKey [FK_PostAnswer_PostQuestion]    Script Date: 12/04/2018 16:37:43 ******/
ALTER TABLE [dbo].[PostAnswer]  WITH CHECK ADD  CONSTRAINT [FK_PostAnswer_PostQuestion] FOREIGN KEY([PostQuestionID_fk])
REFERENCES [dbo].[PostQuestion] ([PostQuestionID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostAnswer] CHECK CONSTRAINT [FK_PostAnswer_PostQuestion]
GO
