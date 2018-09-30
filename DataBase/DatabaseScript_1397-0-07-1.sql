USE [master]
GO
/****** Object:  Database [GossipSite]    Script Date: 9/29/2018 11:17:07 PM ******/
CREATE DATABASE [GossipSite]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GossipSite', FILENAME = N'E:\mahmood\Project\GossipDashboard\DataBase\GossipSite.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GossipSite_log', FILENAME = N'E:\mahmood\Project\GossipDashboard\DataBase\GossipSite_log.ldf' , SIZE = 3136KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [GossipSite] SET RECOVERY FULL 
GO
ALTER DATABASE [GossipSite] SET  MULTI_USER 
GO
ALTER DATABASE [GossipSite] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GossipSite] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GossipSite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GossipSite] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [GossipSite]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 9/29/2018 11:17:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostID] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](2000) NOT NULL,
	[ContentPost] [nvarchar](max) NOT NULL,
	[Url] [nvarchar](2000) NULL,
	[Views] [int] NULL,
	[Image1] [nvarchar](1000) NULL,
	[Image2] [nvarchar](1000) NULL,
	[LikePost] [int] NULL,
	[DislikePost] [int] NULL,
	[PublishCount] [int] NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PostAttribute]    Script Date: 9/29/2018 11:17:07 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PostComment]    Script Date: 9/29/2018 11:17:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostComment](
	[PostCommentID] [int] IDENTITY(1,1) NOT NULL,
	[PostID_fk] [int] NOT NULL,
	[Comment] [nvarchar](4000) NULL,
	[LikeComment] [int] NULL,
	[DislikeComment] [int] NULL,
 CONSTRAINT [PK_PostComment] PRIMARY KEY CLUSTERED 
(
	[PostCommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PubBase]    Script Date: 9/29/2018 11:17:07 PM ******/
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
	[Active] [bit] NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_PubBase] PRIMARY KEY CLUSTERED 
(
	[PubBaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/29/2018 11:17:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserPost]    Script Date: 9/29/2018 11:17:07 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (4, N'آناهیتا همتی ساعاتی پیش در تازه‌ترین پست اینستاگرامی‌اش نوشت:مثل شما با اقدامات', N'خبرآنلاین: آناهیتا همتی، بازیگر سینما و تلویزیون، در تازه‌ترین پست اینستاگرامی خود، بابت متنی جنجالی که آغاز این هفته منتشر کرده بود، عذرخواهی و بر مخالفت‌اش با کارهای تروریستی تاکید کرد.

آناهیتا همتی که شنبه (17 شهریور) در پستی اینستاگرامی به صورتی تلویحی از اعدام یک نفر از اعضای حزب کومله ابراز ناراحتی کرده بود، با واکنش منفی کاربران این شبکه اجتماعی، وادار به عذرخواهی شد.

آناهیتا همتی ساعاتی پیش در تازه‌ترین پست اینستاگرامی‌اش نوشت: «... هموطنان عزیزم، از اینکه با ندانم کاری، احساسات شما را جریحه دار کردم ، متاسفم و ازتون معذرت میخوام. من هم مثل شما با اقدامات غیرانسانی و کارهای تروریستی مخالفم. جنایت و کشتار را هیچ عقل سلیمی نمیپذیرد و حق حیات، حق همه انسان هاست. در پایان از همه کسانیکه در مرزهای کشور عزیزمون برای امنیت همه ایران خالصانه میکوشند، سپاسگزارم.»', N'http://localhost:27999/Quiz/Index1', 125, N'https://images.khabaronline.ir/images/2018/9/position50/image634742181276715512.jpg', NULL, 50, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (5, N'فیلم | آوازخوانی محمدرضا شجریان در محفل سینماگران', N'فیلم | آوازخوانی محمدرضا شجریان در محفل سینماگران', N'~/Content/Audio/sample.mp3', 1020, N'https://images.khabaronline.ir/images/2018/9/position38/09-11-13-15523110-1.jpg', NULL, 125, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (7, N'جزییات بازداشت خواننده سرشناس در اوایل انقلاب', N'جزییات بازداشت خواننده سرشناس در اوایل انقلاب', N'http://localhost:27999/Quiz/Index3', 215, N'https://images.khabaronline.ir/images/2018/9/position38/18-9-24-9184457358287.jpg', NULL, 70, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (8, N'خاطره غم‌انگیز محسن چاوشی از پدرش/ عکس', N'خاطره غم‌انگیز محسن چاوشی از پدرش/ عکس', N'http://localhost:27999/Quiz/Index4', 9852, N'https://images.khabaronline.ir/images/2018/9/position38/18-8-15-21442688-1.jpg', NULL, 4521, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (9, N'فیلم | قطعه‌ای که سالار عقیلی برای تولد محمدرضا شجریان خواند', N'فیلم | قطعه‌ای که سالار عقیلی برای تولد محمدرضا شجریان خواند', N'http://localhost:27999/Quiz/Index5', 2154, N'https://images.khabaronline.ir/images/2018/9/position38/18-9-23-14414557750592.jpg', NULL, 1287, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (10, N'فیلم | قطعه‌ای که سالار عقیلی برای تولد محمدرضا شجریان خواند', N'فیلم | قطعه‌ای که سالار عقیلی برای تولد محمدرضا شجریان خواند', N'http://localhost:27999/Quiz/Index6', 2589, N'https://images.khabaronline.ir/images/2018/9/position38/18-8-12-65013139511251719004519999874.jpg', NULL, 325, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (11, N'محمود دولت‌آبادی برای تولد شجریان چه نوشت؟', N'محمود دولت‌آبادی برای تولد شجریان چه نوشت؟', N'http://localhost:27999/Quiz/Index7', 78521, N'https://images.khabaronline.ir/images/2018/9/position38/17-5-30-132213maxresdefault_2.gif.jpg', NULL, 50425, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (12, N'علیرضا افتخاری از دلیل خانه‌نشین شدنش پرده برداشت', N'علیرضا افتخاری از دلیل خانه‌نشین شدنش پرده برداشت', N'http://localhost:27999/Quiz/Index8', 9852, N'https://images.khabaronline.ir/images/2018/9/position38/18-9-20-12233895640892_113308228fecbb.jpg', NULL, 5247, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (13, N'خاطره جالب خواننده سرشناس از محمدرضا شجریان', N'خاطره جالب خواننده سرشناس از محمدرضا شجریان', N'http://localhost:27999/Quiz/Index9', 1052, N'https://images.khabaronline.ir/images/2018/9/position38/17-1-21-131254unnamed_3_.jpg', NULL, 325, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (14, N'آناهیتا همتی ساعاتی پیش در تازه‌ترین پست اینستاگرامی‌اش نوشت:مثل شما با اقدامات', N'خبرآنلاین: آناهیتا همتی، بازیگر سینما و تلویزیون، در تازه‌ترین پست اینستاگرامی خود، بابت متنی جنجالی که آغاز این هفته منتشر کرده بود، عذرخواهی و بر مخالفت‌اش با کارهای تروریستی تاکید کرد.', N'http://localhost:27999/Quiz/Index10', 214, N'https://images.khabaronline.ir/images/2018/9/position38/2018_9_20_12_6_4.jpg', NULL, 214, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (15, N'فیلم | کلیپ محسن چاوشی برای حادثه تروریستی امروز اهواز', N'فیلم | کلیپ محسن چاوشی برای حادثه تروریستی امروز اهواز', N'http://localhost:27999/Quiz/Index11', 14, N'https://images.khabaronline.ir/images/2018/9/position38/2018_9_20_12_6_4.jpg', NULL, 12, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (16, N'آوازی ایرانی با قدمت ۷۰۰۰ سال!', N'آوازی ایرانی با قدمت ۷۰۰۰ سال!', N'http://localhost:27999/Quiz/Index12', 5, N'https://images.khabaronline.ir/images/2018/9/position38/18-5-2-17151_101130595_hi046470518.jpg', NULL, 1, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (17, N'فیلم | دعا برای سلامتی محمدرضا شجریان در هیئت یزدی‌ها', N'فیلم | دعا برای سلامتی محمدرضا شجریان در هیئت یزدی‌ها', N'http://localhost:27999/Quiz/Index', 6521, N'https://images.khabaronline.ir/images/2018/9/position38/2018_9_19_8_2_44.jpg', NULL, 3254, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (18, N'فیلم | مداحی بهنام بانی در دسته عزاداری', N'فیلم | مداحی بهنام بانی در دسته عزاداری', N'http://localhost:27999/Quiz/Index', 21, N'https://images.khabaronline.ir/images/2018/9/position38/17-2-16-54543hamed-homayoun.jpg', NULL, 7, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (19, N'فیلم | روضه‌خوانی بنیامین و مداح سرشناس تهران سال‌ها قبل', N'فیلم | روضه‌خوانی بنیامین و مداح سرشناس تهران سال‌ها قبل', N'http://localhost:27999/Quiz/Index', 149, N'https://images.khabaronline.ir/images/2018/9/position38/2018_9_14_10_27_12.jpg', NULL, 25, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (20, N'عکس | خواننده مطرح پاپ در حال توزیع غذای نذری', N'عکس | خواننده مطرح پاپ در حال توزیع غذای نذری', N'http://localhost:27999/Quiz/Index', 964, N'https://images.khabaronline.ir/images/2018/9/position38/18-4-24-1344251_2_.jpg', NULL, 810, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (21, N'رمزگشایی از پست فارسی خواننده مشهور آمریکایی/ عکس', N'رمزگشایی از پست فارسی خواننده مشهور آمریکایی/ عکس', N'http://localhost:27999/Quiz/Index', 215, N'https://images.khabaronline.ir/images/2018/9/position38/18-9-9-23533457742463.jpg', NULL, 238, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (22, N'آناهیتا همتی ساعاتی پیش در تازه‌ترین پست اینستاگرامی‌اش نوشت:مثل شما با اقدامات', N'خبرآنلاین: آناهیتا همتی، بازیگر سینما و تلویزیون، در تازه‌ترین پست اینستاگرامی خود، بابت متنی جنجالی که آغاز این هفته منتشر کرده بود، عذرخواهی و بر مخالفت‌اش با کارهای تروریستی تاکید کرد.', N'http://localhost:27999/Quiz/Index', 452, N'https://images.khabaronline.ir/images/2018/9/position38/18-9-9-19305213970618001153_test_photon.jpg', NULL, 75, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (23, N'فیلم | اثر حماسی آهنگساز مشهور ارمنی در سوگ عاشورا', N'فیلم | اثر حماسی آهنگساز مشهور ارمنی در سوگ عاشورا', N'http://localhost:27999/Quiz/Index', 152, N'https://images.khabaronline.ir/images/2018/9/position38/18-9-9-14318photo_2018-09-09_08-28-00.jpg', NULL, 36, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [ContentPost], [Url], [Views], [Image1], [Image2], [LikePost], [DislikePost], [PublishCount], [ModifyUserID], [ModifyDate]) VALUES (24, N'هوشنگ جاوید: امروز روی ملودی ترانه، نوحه می‌خوانند', N'هوشنگ جاوید: امروز روی ملودی ترانه، نوحه می‌خوانند', N'http://localhost:27999/Quiz/Index', 832, N'https://images.khabaronline.ir/images/2018/9/position38/18-9-7-10282180906-burt-reynolds.jpg', NULL, 750, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Post] OFF
SET IDENTITY_INSERT [dbo].[PostAttribute] ON 

INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (1, 4, 22)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (2, 4, 12)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (3, 5, 23)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (4, 5, 13)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (5, 7, 22)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (6, 7, 14)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (7, 8, 22)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (8, 8, 13)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (9, 9, 23)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (10, 9, 14)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (11, 9, 15)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (12, 4, 30)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (13, 5, 32)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (14, 7, 34)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (15, 8, 32)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (16, 9, 32)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (17, 10, 16)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (18, 10, 23)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (19, 10, 33)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (20, 11, 18)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (21, 11, 22)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (22, 11, 34)
SET IDENTITY_INSERT [dbo].[PostAttribute] OFF
SET IDENTITY_INSERT [dbo].[PostComment] ON 

INSERT [dbo].[PostComment] ([PostCommentID], [PostID_fk], [Comment], [LikeComment], [DislikeComment]) VALUES (1, 4, N'عالی است', 5, 1)
INSERT [dbo].[PostComment] ([PostCommentID], [PostID_fk], [Comment], [LikeComment], [DislikeComment]) VALUES (2, 4, N'خیلی خوب بود', 10, 0)
INSERT [dbo].[PostComment] ([PostCommentID], [PostID_fk], [Comment], [LikeComment], [DislikeComment]) VALUES (3, 4, N'اگه میشه از این مطالب بیشتر بذارید', 7, 0)
INSERT [dbo].[PostComment] ([PostCommentID], [PostID_fk], [Comment], [LikeComment], [DislikeComment]) VALUES (4, 5, N'عالی است', 5, 1)
INSERT [dbo].[PostComment] ([PostCommentID], [PostID_fk], [Comment], [LikeComment], [DislikeComment]) VALUES (5, 7, N'خیلی خوب بود', 10, 0)
INSERT [dbo].[PostComment] ([PostCommentID], [PostID_fk], [Comment], [LikeComment], [DislikeComment]) VALUES (6, 7, N'اگه میشه از این مطالب بیشتر بذارید', 7, 0)
INSERT [dbo].[PostComment] ([PostCommentID], [PostID_fk], [Comment], [LikeComment], [DislikeComment]) VALUES (7, 8, N'عالی است', 5, 1)
INSERT [dbo].[PostComment] ([PostCommentID], [PostID_fk], [Comment], [LikeComment], [DislikeComment]) VALUES (8, 9, N'خیلی خوب بود', 10, 0)
INSERT [dbo].[PostComment] ([PostCommentID], [PostID_fk], [Comment], [LikeComment], [DislikeComment]) VALUES (9, 9, N'اگه میشه از این مطالب بیشتر بذارید', 7, 0)
INSERT [dbo].[PostComment] ([PostCommentID], [PostID_fk], [Comment], [LikeComment], [DislikeComment]) VALUES (10, 9, N'عالی است', 5, 1)
INSERT [dbo].[PostComment] ([PostCommentID], [PostID_fk], [Comment], [LikeComment], [DislikeComment]) VALUES (11, 9, N'خیلی خوب بود', 10, 0)
INSERT [dbo].[PostComment] ([PostCommentID], [PostID_fk], [Comment], [LikeComment], [DislikeComment]) VALUES (12, 10, N'اگه میشه از این مطالب بیشتر بذارید', 7, 0)
SET IDENTITY_INSERT [dbo].[PostComment] OFF
SET IDENTITY_INSERT [dbo].[PubBase] ON 

INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (1, NULL, N'سرشاخه', NULL, NULL, NULL, NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (11, 1, N'طبقه بندي پست ها', N'PostCategory', NULL, NULL, NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (12, 11, N'شوخی', N'quiz', NULL, NULL, N'category-quiz', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (13, 11, N'ناز', N'cute', NULL, NULL, N'category-cute', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (14, 11, N'عجیب و غریب', N'bizarre', NULL, NULL, N'category-bizarre', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (15, 11, N'سرگرمی', N'entertainment', NULL, NULL, N'category-entertainment', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (16, 11, N'حیرت آور', N'amazing', NULL, NULL, N'category-amazing', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (17, 11, N'فیلم', N'films', NULL, NULL, N'category-films', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (18, 11, N'مکان ها', N'places', NULL, NULL, N'category-places', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (19, 11, N'هیجان انگیز', N'sexy', NULL, NULL, N'category-sexy', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (20, 11, N'مکان ها', N'places', NULL, NULL, N'category-places', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (21, 1, N'فرمت پست ها', N'PostFormat', NULL, NULL, NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (22, 21, N'استاندارد', N'standard', NULL, NULL, N'format-standard', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (23, 21, N'صوتی', N'audio', NULL, NULL, N'format-audio', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (24, 21, N'تصویری', N'video', NULL, NULL, N'format-video', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (25, 21, N'گالری', N'gallery', NULL, NULL, N'format-gallery', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (26, 21, N'پیوند', N'link', NULL, NULL, N'format-link', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (27, 21, N'نقل قول', N'quote', NULL, NULL, N'format-quote', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (28, 21, N'عکس', N'image ', NULL, NULL, N'format-image ', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (29, 1, N'لینک مربعی شکل بالای هر پست', N'LinkToAllPostCategory', NULL, N'لینک مربعی شکل بالای هر پست', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (30, 29, N'شوخی', N'cat-quiz', NULL, NULL, N'cat-quiz', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (31, 29, N'حیوانات', N'cat-animals', NULL, NULL, N'cat-animals', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (32, 29, N'ناز', N'cat-cute', NULL, NULL, N'cat-cute', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (33, 29, N'حیرت آور', N'cat-amazing', NULL, NULL, N'cat-amazing', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (34, 29, N'عجیب و غریب', N'cat-bizarre', NULL, NULL, N'cat-bizarre', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (36, 21, N'وضعیت', N'status', NULL, NULL, N'format-status', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[PubBase] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserName], [FirstName], [LastName], [Salt], [Password], [ModifyUserID], [ModifyDate]) VALUES (1, N'Arsalan', N'ارسلان', N'دانشور', N'1', N'1', 1, CAST(0x0000A6EE00000000 AS DateTime))
INSERT [dbo].[User] ([UserID], [UserName], [FirstName], [LastName], [Salt], [Password], [ModifyUserID], [ModifyDate]) VALUES (2, N'Arman', N'آرمان', N'دانشور', N'1', N'1', 1, CAST(0x0000A6EE00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserPost] ON 

INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (1, 1, 4, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (2, 1, 5, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (4, 1, 7, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (5, 1, 8, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (6, 1, 9, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (7, 1, 10, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (8, 1, 11, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (9, 1, 12, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (10, 2, 13, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (11, 2, 14, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (12, 2, 15, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (13, 2, 16, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (14, 2, 17, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (15, 2, 18, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (16, 2, 19, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (17, 2, 20, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (18, 2, 21, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (19, 2, 22, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (20, 2, 23, NULL, NULL)
INSERT [dbo].[UserPost] ([UserPostID], [UserID_fk], [PostID_fk], [ModifyUserID], [ModifyDate]) VALUES (21, 2, 24, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserPost] OFF
ALTER TABLE [dbo].[PubBase] ADD  CONSTRAINT [DF_ArcService_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[PostAttribute]  WITH CHECK ADD  CONSTRAINT [FK_PostCategory_Post] FOREIGN KEY([PostID_fk])
REFERENCES [dbo].[Post] ([PostID])
GO
ALTER TABLE [dbo].[PostAttribute] CHECK CONSTRAINT [FK_PostCategory_Post]
GO
ALTER TABLE [dbo].[PostAttribute]  WITH CHECK ADD  CONSTRAINT [FK_PostCategory_PubBase] FOREIGN KEY([AttributeID_fk])
REFERENCES [dbo].[PubBase] ([PubBaseID])
GO
ALTER TABLE [dbo].[PostAttribute] CHECK CONSTRAINT [FK_PostCategory_PubBase]
GO
ALTER TABLE [dbo].[PostComment]  WITH CHECK ADD  CONSTRAINT [FK_PostComment_Post] FOREIGN KEY([PostID_fk])
REFERENCES [dbo].[Post] ([PostID])
GO
ALTER TABLE [dbo].[PostComment] CHECK CONSTRAINT [FK_PostComment_Post]
GO
ALTER TABLE [dbo].[UserPost]  WITH CHECK ADD  CONSTRAINT [FK_UserPost_Post] FOREIGN KEY([PostID_fk])
REFERENCES [dbo].[Post] ([PostID])
GO
ALTER TABLE [dbo].[UserPost] CHECK CONSTRAINT [FK_UserPost_Post]
GO
ALTER TABLE [dbo].[UserPost]  WITH CHECK ADD  CONSTRAINT [FK_UserPost_User] FOREIGN KEY([UserID_fk])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[UserPost] CHECK CONSTRAINT [FK_UserPost_User]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تعداد دفعاتي كه پست پابليش شده است' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'PublishCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'طبقه بندي پست. ورزشي هنري و ...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PostAttribute', @level2type=N'COLUMN',@level2name=N'AttributeID_fk'
GO
USE [master]
GO
ALTER DATABASE [GossipSite] SET  READ_WRITE 
GO
