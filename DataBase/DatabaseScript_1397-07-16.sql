USE [master]
GO
/****** Object:  Database [GossipSite]    Script Date: 10/10/2018 15:45:31 ******/
CREATE DATABASE [GossipSite] ON  PRIMARY 
( NAME = N'GossipSite', FILENAME = N'E:\mahmood\me\GossipWebApp\GossipDashboard\DataBase\GossipSite.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GossipSite_log', FILENAME = N'E:\mahmood\me\GossipWebApp\GossipDashboard\DataBase\GossipSite_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [GossipSite] SET AUTO_CLOSE OFF
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
ALTER DATABASE [GossipSite] SET RECOVERY FULL
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
/****** Object:  Table [dbo].[User]    Script Date: 10/10/2018 15:45:32 ******/
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
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([UserID], [UserName], [FirstName], [LastName], [Salt], [Password], [ModifyUserID], [ModifyDate], [Image], [AboutUser]) VALUES (1, N'Arsalan', N'ارسلان', N'دانشور', N'1', N'1', 1, CAST(0x0000A6EE00000000 AS DateTime), NULL, NULL)
INSERT [dbo].[User] ([UserID], [UserName], [FirstName], [LastName], [Salt], [Password], [ModifyUserID], [ModifyDate], [Image], [AboutUser]) VALUES (2, N'Arman', N'آرمان', N'دانشور', N'1', N'1', 1, CAST(0x0000A6EE00000000 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[PubBase]    Script Date: 10/10/2018 15:45:32 ******/
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
SET IDENTITY_INSERT [dbo].[PubBase] ON
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (1, NULL, N'سرشاخه', NULL, NULL, NULL, NULL, NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (11, 1, N'طبقه بندي پست ها', N'PostCategory', NULL, NULL, NULL, NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (12, 11, N'سوال', N'quiz', NULL, NULL, N'category-quiz', N'cat-quiz', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (13, 11, N'ناز', N'cute', NULL, NULL, N'category-cute', N'cat-cute', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (14, 11, N'عجیب و غریب', N'bizarre', NULL, NULL, N'category-bizarre', N'cat-bizarre', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (15, 11, N'سرگرمی', N'entertainment', NULL, NULL, N'category-entertainment', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (16, 11, N'حیرت آور', N'amazing', NULL, NULL, N'category-amazing', N'cat-amazing', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (17, 11, N'فیلم', N'films', NULL, NULL, N'category-films', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (18, 11, N'مکان ها', N'places', NULL, NULL, N'category-places', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (19, 11, N'هیجان انگیز', N'sexy', NULL, NULL, N'category-sexy', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (20, 11, N'مکان ها', N'places', NULL, NULL, N'category-places', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (21, 1, N'فرمت پست ها', N'PostFormat', NULL, NULL, NULL, NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (22, 21, N'استاندارد', N'standard', NULL, NULL, N'format-standard', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (23, 21, N'صوتی', N'audio', NULL, NULL, N'format-audio', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (24, 21, N'تصویری', N'video', NULL, NULL, N'format-video', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (25, 21, N'گالری', N'gallery', NULL, NULL, N'format-gallery', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (26, 21, N'پیوند', N'link', NULL, NULL, N'format-link', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (27, 21, N'نقل قول', N'quote', NULL, NULL, N'format-quote', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (28, 21, N'عکس', N'image ', NULL, NULL, N'format-image ', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (36, 21, N'وضعیت', N'status', NULL, NULL, N'format-status', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (40, 1, N'تعداد ستوت هر پست', N'PostCol', NULL, N'', NULL, NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (41, 40, N'یک ستون', N'col-md-1', NULL, NULL, N'col-md-1 col-lg-1', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (42, 40, N'دو ستون', N'col-md-2', NULL, NULL, N'col-md-2 col-lg-2', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (43, 40, N'سه ستون', N'col-md-3', NULL, NULL, N'col-md-3 col-lg-3', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (44, 40, N'چهار ستون', N'col-md-4', NULL, NULL, N'col-md-4 col-lg-4', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (45, 40, N'پنج ستون', N'col-md-5', NULL, NULL, N'col-md-5 col-lg-5', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (46, 40, N'شش ستون', N'col-md-6', NULL, NULL, N'col-md-6 col-lg-6', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (47, 40, N'هفت ستون', N'col-md-7', NULL, NULL, N'col-md-7 col-lg-7', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (48, 40, N'هشت ستون', N'col-md-8', NULL, NULL, N'col-md-8 col-lg-8', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (49, 40, N'نه ستون', N'col-md-9', NULL, NULL, N'col-md-9 col-lg-9', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (50, 40, N'ده ستون', N'col-md-10', NULL, NULL, N'col-md-10 col-lg-10', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (51, 40, N'یازده ستون', N'col-md-11', NULL, NULL, N'col-md-11 col-lg-11', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (52, 40, N'دوازده ستون', N'col-md-12', NULL, NULL, N'col-md-12 col-lg-12', NULL, 1, 1, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[PubBase] ([PubBaseID], [ParentID], [NameFa], [NameEn], [GroupBase], [Description], [ClassName], [AbobeClassName], [Active], [ModifyUserID], [ModifyDate]) VALUES (53, 11, N'حیوانات', N'animals', NULL, NULL, N'category-animals', N'cat-animals', 1, 1, CAST(0x00008EAC00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[PubBase] OFF
/****** Object:  Table [dbo].[Post]    Script Date: 10/10/2018 15:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostID] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](2000) NOT NULL,
	[Subject1] [nvarchar](2000) NULL,
	[Subject2] [nvarchar](2000) NULL,
	[ContentPost] [nvarchar](max) NOT NULL,
	[ContentPost1] [nvarchar](max) NULL,
	[ContentPost2] [nvarchar](max) NULL,
	[QuotedFrom] [nvarchar](1000) NULL,
	[Url] [nvarchar](2000) NULL,
	[UrlMP3] [nvarchar](2000) NULL,
	[UrlVideo] [nvarchar](2000) NULL,
	[Views] [int] NULL,
	[Image1] [nvarchar](1000) NULL,
	[Image2] [nvarchar](1000) NULL,
	[Image3] [nvarchar](1000) NULL,
	[Image4] [nvarchar](1000) NULL,
	[LikePost] [int] NULL,
	[DislikePost] [int] NULL,
	[PublishCount] [int] NULL,
	[BackgroundColor] [nvarchar](50) NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'به نقل از فرد یا سایت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'QuotedFrom'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تعداد دفعاتي كه پست پابليش شده است' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Post', @level2type=N'COLUMN',@level2name=N'PublishCount'
GO
SET IDENTITY_INSERT [dbo].[Post] ON
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (4, N'آناهیتا همتی ساعاتی پیش در تازه‌ترین پست اینستاگرامی‌اش نوشت:مثل شما با اقدامات', N'هوشنگ جاوید: امروز روی ملودی ترانه، نوحه می‌خوانند', NULL, N'خبرآنلاین: آناهیتا همتی، بازیگر سینما و تلویزیون، در تازه‌ترین پست اینستاگرامی خود، بابت متنی جنجالی که آغاز این هفته منتشر کرده بود، عذرخواهی و بر مخالفت‌اش با کارهای تروریستی تاکید کرد.

آناهیتا همتی که شنبه (17 شهریور) در پستی اینستاگرامی به صورتی تلویحی از اعدام یک نفر از اعضای حزب کومله ابراز ناراحتی کرده بود، با واکنش منفی کاربران این شبکه اجتماعی، وادار به عذرخواهی شد.

آناهیتا همتی ساعاتی پیش در تازه‌ترین پست اینستاگرامی‌اش نوشت: «... هموطنان عزیزم، از اینکه با ندانم کاری، احساسات شما را جریحه دار کردم ، متاسفم و ازتون معذرت میخوام. من هم مثل شما با اقدامات غیرانسانی و کارهای تروریستی مخالفم. جنایت و کشتار را هیچ عقل سلیمی نمیپذیرد و حق حیات، حق همه انسان هاست. در پایان از همه کسانیکه در مرزهای کشور عزیزمون برای امنیت همه ایران خالصانه میکوشند، سپاسگزارم.»', N'جزییات بازداشت خواننده سرشناس در اوایل انقلاب', NULL, NULL, N'/Quiz/Post?PostID=4', NULL, NULL, 125, N'https://images.khabaronline.ir/images/2018/9/position50/image634742181276715512.jpg', N'https://images.khabaronline.ir/images/2018/9/position38/18-9-7-10282180906-burt-reynolds.jpg', NULL, NULL, 50, NULL, NULL, N'#a94442', 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (5, N'فیلم | آوازخوانی محمدرضا شجریان در محفل سینماگران', N'فیلم | اثر حماسی آهنگساز مشهور ارمنی در سوگ عاشورا', N'رمزگشایی از پست فارسی خواننده مشهور آمریکایی/ عکس', N'این گجت در واقع می تواند گوشی را نگه دارد و از میزان وزنی که به دست وارد می شود بکاهد. روبات MobiLimb یک پروژه تحقیقاتی است که توسط مارک تیسیر؛ دانشجوی دکترا دانشگاه فرانسه به انجام رسیده است و عکس های بیشتر از آن را در وب سایت خود به اشتراک گذاشته و توضیح مفصلی در خصوص این پروژه داده است. او می نویسد: « ماهیت این دستگاه، غلبه بر محدودیت های بدن انسان با استفاده از این اندام های روباتیک است. رویکرد ما پیگیری این هدف در استفاده از محدودیت های تلفن همراه با استفاده از اندام روباتیک است.', N'به گزارش پارس نیوز، بشار رسن، هافبک تیم ملی عراق و عضو باشگاه پرسپولیس به مقایسه سطح لیگ عراق با ایران پرداخت و لیگ فوتبال کشورمان را بسیار فشرده‌تر عنوان کرد.', N'خبرآنلاین: آناهیتا همتی، بازیگر سینما و تلویزیون، در تازه‌ترین پست اینستاگرامی خود، بابت متنی جنجالی که آغاز این هفته منتشر کرده بود، عذرخواهی و بر مخالفت‌اش با کارهای تروریستی تاکید کرد.', NULL, N'/Quiz/Post?PostID=5', N'~/Content/Audio/sample.mp3', NULL, 1020, N'https://images.khabaronline.ir/images/2018/9/position38/09-11-13-15523110-1.jpg', N'https://images.khabaronline.ir/images/2018/9/position38/18-9-23-14414557750592.jpg', N'https://images.khabaronline.ir/images/2018/9/position38/2018_9_20_12_6_4.jpg', N'https://images.khabaronline.ir/images/2018/9/position38/18-5-2-17151_101130595_hi046470518.jpg', 125, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (7, N'جزییات بازداشت خواننده سرشناس در اوایل انقلاب', NULL, NULL, N'ه گزارش اقتصادنیوز به نقل از ایبِنا، در ۶ ماه اول امسال، حجم پرداخت تسهیلات خرید مسکن توسط این بانک به لحاظ تعداد (فقره تسهیلات) با رشد ۶۳ درصدی مواجه شد که این میزان رشد در دامنه پوشش متقاضیان تسهیلات خرید مسکن در سال های گذشته بی سابقه بوده است.', NULL, NULL, NULL, N'/Quiz/Post?PostID=7', NULL, NULL, 215, N'https://images.khabaronline.ir/images/2018/9/position38/18-9-24-9184457358287.jpg', NULL, NULL, NULL, 70, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (8, N'خاطره غم‌انگیز محسن چاوشی از پدرش/ عکس', NULL, NULL, N'در نیمه اول امسال، شتاب پرداخت تسهیلات مسکن افزایش پیدا کرد و حتی شیب آن از شیب رشد منابع هم سبقت گرفت. در شهریور امسال، کل منابع در اختیار بانک مسکن، ۲۲.۵ درصد نسبت به شهریور سال گذشته افزایش پیدا کرد اما کل تسهیلاتی که بانک مسکن در شهریور امسال پرداخت کرد از رشد ۲۳ درصدی نسبت به شهریور ۹۶ برخوردار شد. به این ترتیب، تامین مالی بخش مسکن توسط بانک مسکن به گونه ای است که در شرایط محدودیت نسبی منابع، دامنه پوشش متقاضیان تسهیلات رو به افزایش است.', NULL, NULL, NULL, N'/Quiz/Post?PostID=8', NULL, NULL, 9852, N'https://images.khabaronline.ir/images/2018/9/position38/18-8-15-21442688-1.jpg', NULL, NULL, NULL, 4521, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (9, N'فیلم | قطعه‌ای که سالار عقیلی برای تولد محمدرضا شجریان خواند', NULL, NULL, N'این گجت در واقع می تواند گوشی را نگه دارد و از میزان وزنی که به دست وارد می شود بکاهد. روبات MobiLimb یک پروژه تحقیقاتی است که توسط مارک تیسیر؛ دانشجوی دکترا دانشگاه فرانسه به انجام رسیده است و عکس های بیشتر از آن را در وب سایت خود به اشتراک گذاشته و توضیح مفصلی در خصوص این پروژه داده است. او می نویسد: « ماهیت این دستگاه، غلبه بر محدودیت های بدن انسان با استفاده از این اندام های روباتیک است. رویکرد ما پیگیری این هدف در استفاده از محدودیت های تلفن همراه با استفاده از اندام روباتیک است.', N'', NULL, NULL, N'/Quiz/Post?PostID=9', NULL, NULL, 2154, N'https://images.khabaronline.ir/images/2018/9/position38/18-9-23-14414557750592.jpg', NULL, NULL, NULL, 1287, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (10, N'فیلم | قطعه‌ای که سالار عقیلی برای تولد محمدرضا شجریان خواند', NULL, NULL, N'فیلم | قطعه‌ای که سالار عقیلی برای تولد محمدرضا شجریان خواند', NULL, NULL, NULL, N'/Quiz/Post?PostID=10', NULL, NULL, 2589, N'https://images.khabaronline.ir/images/2018/9/position38/18-8-12-65013139511251719004519999874.jpg', NULL, NULL, NULL, 325, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (11, N'محمود دولت‌آبادی برای تولد شجریان چه نوشت؟', NULL, NULL, N'محمود دولت‌آبادی برای تولد شجریان چه نوشت؟', NULL, NULL, NULL, N'/Quiz/Post?PostID=11', NULL, NULL, 78521, N'https://images.khabaronline.ir/images/2018/9/position38/17-5-30-132213maxresdefault_2.gif.jpg', NULL, NULL, NULL, 50425, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (12, N'علیرضا افتخاری از دلیل خانه‌نشین شدنش پرده برداشت', NULL, NULL, N'علیرضا افتخاری از دلیل خانه‌نشین شدنش پرده برداشت', NULL, NULL, NULL, N'/Quiz/Post?PostID=12', NULL, NULL, 9852, N'http://shohadayeiran.com/files/fa/news/1396/5/30/172368_704.jpg', NULL, NULL, NULL, 5247, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (13, N'خاطره جالب خواننده سرشناس از محمدرضا شجریان', NULL, NULL, N'خاطره جالب خواننده سرشناس از محمدرضا شجریان', NULL, NULL, NULL, N'/Quiz/Post?PostID=13', NULL, NULL, 1052, N'https://images.khabaronline.ir/images/2018/9/position38/17-1-21-131254unnamed_3_.jpg', NULL, NULL, NULL, 325, NULL, NULL, N'#3904a2', 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (14, N'آناهیتا همتی ساعاتی پیش در تازه‌ترین پست اینستاگرامی‌اش نوشت:مثل شما با اقدامات', NULL, NULL, N'خبرآنلاین: آناهیتا همتی، بازیگر سینما و تلویزیون، در تازه‌ترین پست اینستاگرامی خود، بابت متنی جنجالی که آغاز این هفته منتشر کرده بود، عذرخواهی و بر مخالفت‌اش با کارهای تروریستی تاکید کرد.', NULL, NULL, NULL, N'/Quiz/Post?PostID=14', NULL, NULL, 214, N'https://images.khabaronline.ir/images/2018/9/position38/2018_9_20_12_6_4.jpg', NULL, NULL, NULL, 214, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (15, N'فیلم | کلیپ محسن چاوشی برای حادثه تروریستی امروز اهواز', NULL, NULL, N'فیلم | کلیپ محسن چاوشی برای حادثه تروریستی امروز اهواز', NULL, NULL, NULL, N'/Quiz/Post?PostID=15', NULL, NULL, 14, N'https://images.khabaronline.ir/images/2018/9/position38/2018_9_20_12_6_4.jpg', NULL, NULL, NULL, 12, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (16, N'آوازی ایرانی با قدمت ۷۰۰۰ سال!', NULL, NULL, N'آوازی ایرانی با قدمت ۷۰۰۰ سال!', NULL, NULL, N'مولوی', N'/Quiz/Post?PostID=16', NULL, NULL, 5, N'', NULL, NULL, NULL, 1, NULL, NULL, N'#a94442', 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (17, N'باید راهی جست در تاریکی شبهای عصیان زده سرزمینم همیشه به دنبال نوری بودم نوری برای رهایی سرزمینم از چنگال اجنبیان ، چه بلای دهشتناکی است که ببینی همه جان و مال و ناموست در اختیار اجنبی قرار گرفته و دستانت بسته است نمی توانی کاری کنی اما همه وجودت برای رهایی در تکاپوست تو می توانی این تنها نیروی است که از اعماق و جودت فریاد می زند تو می توانی جراحت ها را التیام بخشی و اینگونه بود که پا بر رکاب اسب نهادم به امید سرفرازی ملتی بزرگ . نادر شاه افشار', NULL, NULL, N'باید راهی جست در تاریکی شبهای عصیان زده سرزمینم همیشه به دنبال نوری بودم نوری برای رهایی سرزمینم از چنگال اجنبیان ، چه بلای دهشتناکی است که ببینی همه جان و مال و ناموست در اختیار اجنبی قرار گرفته و دستانت بسته است نمی توانی کاری کنی اما همه وجودت برای رهایی در تکاپوست تو می توانی این تنها نیروی است که از اعماق و جودت فریاد می زند تو می توانی جراحت ها را التیام بخشی و اینگونه بود که پا بر رکاب اسب نهادم به امید سرفرازی ملتی بزرگ . نادر شاه افشار', NULL, NULL, NULL, N'/Quiz/Post?PostID=17', NULL, NULL, 6521, N'https://images.khabaronline.ir/images/2018/9/position38/2018_9_19_8_2_44.jpg', NULL, NULL, NULL, 3254, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (18, N'فیلم | مداحی بهنام بانی در دسته عزاداری', NULL, NULL, N'فیلم | مداحی بهنام بانی در دسته عزاداری', NULL, NULL, NULL, N'/Quiz/Post?PostID=18', NULL, N'~/Content/Video/grasshopper.mp4', 21, N'https://images.khabaronline.ir/images/2018/9/position38/17-2-16-54543hamed-homayoun.jpg', NULL, NULL, NULL, 7, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (19, N'فیلم | روضه‌خوانی بنیامین و مداح سرشناس تهران سال‌ها قبل', NULL, NULL, N'فیلم | روضه‌خوانی بنیامین و مداح سرشناس تهران سال‌ها قبل', NULL, NULL, NULL, N'/Quiz/Post?PostID=19', NULL, NULL, 149, N'https://images.khabaronline.ir/images/2018/9/position38/2018_9_14_10_27_12.jpg', N'http://parsnava.ir/wp-content/uploads/2016/10/Benyamin-parsnava-9.jpg', N'https://static2.ilna.ir/thumbnail/CtUvfumO2YV2/XWHCw76VBsxV-gjMD_1vCetw5eCq7S04hX6xsI6ISfTD_yl-j66fW7VVozzx0Z7LmaLGZQo-BwM,/es7dnnjw0eq6yqmspjh.jpg', NULL, 25, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (20, N'عکس | خواننده مطرح پاپ در حال توزیع غذای نذری', NULL, NULL, N'عکس | خواننده مطرح پاپ در حال توزیع غذای نذری', NULL, NULL, NULL, N'/Quiz/Post?PostID=20', NULL, NULL, 964, N'https://images.khabaronline.ir/images/2018/9/position38/18-4-24-1344251_2_.jpg', NULL, NULL, NULL, 810, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (21, N'رمزگشایی از پست فارسی خواننده مشهور آمریکایی/ عکس', NULL, NULL, N'رمزگشایی از پست فارسی خواننده مشهور آمریکایی/ عکس', NULL, NULL, NULL, N'/Quiz/Post?PostID=21', NULL, NULL, 215, N'https://images.khabaronline.ir/images/2018/9/position38/18-9-9-23533457742463.jpg', NULL, NULL, NULL, 238, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (22, N'آناهیتا همتی ساعاتی پیش در تازه‌ترین پست اینستاگرامی‌اش نوشت:مثل شما با اقدامات', NULL, NULL, N'خبرآنلاین: آناهیتا همتی، بازیگر سینما و تلویزیون، در تازه‌ترین پست اینستاگرامی خود، بابت متنی جنجالی که آغاز این هفته منتشر کرده بود، عذرخواهی و بر مخالفت‌اش با کارهای تروریستی تاکید کرد.', NULL, NULL, NULL, N'/Quiz/Post?PostID=22', NULL, NULL, 452, N'https://images.khabaronline.ir/images/2018/9/position38/18-9-9-19305213970618001153_test_photon.jpg', NULL, NULL, NULL, 75, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (23, N'فیلم | اثر حماسی آهنگساز مشهور ارمنی در سوگ عاشورا', NULL, NULL, N'فیلم | اثر حماسی آهنگساز مشهور ارمنی در سوگ عاشورا', NULL, NULL, NULL, N'/Quiz/Post?PostID=23', NULL, NULL, 152, N'https://images.khabaronline.ir/images/2018/9/position38/18-9-9-14318photo_2018-09-09_08-28-00.jpg', NULL, NULL, NULL, 36, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
INSERT [dbo].[Post] ([PostID], [Subject], [Subject1], [Subject2], [ContentPost], [ContentPost1], [ContentPost2], [QuotedFrom], [Url], [UrlMP3], [UrlVideo], [Views], [Image1], [Image2], [Image3], [Image4], [LikePost], [DislikePost], [PublishCount], [BackgroundColor], [ModifyUserID], [ModifyDate]) VALUES (24, N'هوشنگ جاوید: امروز روی ملودی ترانه، نوحه می‌خوانند', NULL, NULL, N'هوشنگ جاوید: امروز روی ملودی ترانه، نوحه می‌خوانند', NULL, NULL, NULL, N'/Quiz/Post?PostID=24', NULL, NULL, 832, N'https://images.khabaronline.ir/images/2018/9/position38/18-9-7-10282180906-burt-reynolds.jpg', NULL, NULL, NULL, 750, NULL, NULL, NULL, 0, CAST(0x00008EAC00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Post] OFF
/****** Object:  Table [dbo].[UserPost]    Script Date: 10/10/2018 15:45:32 ******/
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
/****** Object:  Table [dbo].[PostQuestion]    Script Date: 10/10/2018 15:45:32 ******/
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
/****** Object:  Table [dbo].[PostComment]    Script Date: 10/10/2018 15:45:32 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
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
/****** Object:  Table [dbo].[PostAttribute]    Script Date: 10/10/2018 15:45:32 ******/
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
SET IDENTITY_INSERT [dbo].[PostAttribute] ON
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (1, 4, 22)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (2, 4, 12)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (3, 5, 23)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (4, 5, 12)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (5, 7, 22)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (6, 7, 12)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (7, 8, 22)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (8, 8, 12)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (9, 9, 23)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (10, 9, 12)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (11, 9, 15)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (17, 10, 16)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (18, 10, 23)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (20, 11, 18)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (21, 11, 22)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (23, 12, 15)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (24, 12, 28)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (27, 13, 13)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (28, 13, 26)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (30, 16, 14)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (31, 16, 27)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (35, 17, 36)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (36, 18, 14)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (38, 18, 24)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (40, 19, 16)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (41, 19, 25)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (43, 18, 48)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (44, 19, 52)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (45, 8, 44)
INSERT [dbo].[PostAttribute] ([PostAttributeID], [PostID_fk], [AttributeID_fk]) VALUES (47, 13, 52)
SET IDENTITY_INSERT [dbo].[PostAttribute] OFF
/****** Object:  Table [dbo].[PostAnswer]    Script Date: 10/10/2018 15:45:32 ******/
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
/****** Object:  Default [DF_ArcService_Active]    Script Date: 10/10/2018 15:45:32 ******/
ALTER TABLE [dbo].[PubBase] ADD  CONSTRAINT [DF_ArcService_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  ForeignKey [FK_UserPost_Post]    Script Date: 10/10/2018 15:45:32 ******/
ALTER TABLE [dbo].[UserPost]  WITH CHECK ADD  CONSTRAINT [FK_UserPost_Post] FOREIGN KEY([PostID_fk])
REFERENCES [dbo].[Post] ([PostID])
GO
ALTER TABLE [dbo].[UserPost] CHECK CONSTRAINT [FK_UserPost_Post]
GO
/****** Object:  ForeignKey [FK_UserPost_User]    Script Date: 10/10/2018 15:45:32 ******/
ALTER TABLE [dbo].[UserPost]  WITH CHECK ADD  CONSTRAINT [FK_UserPost_User] FOREIGN KEY([UserID_fk])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[UserPost] CHECK CONSTRAINT [FK_UserPost_User]
GO
/****** Object:  ForeignKey [FK_PostQuestion_Post]    Script Date: 10/10/2018 15:45:32 ******/
ALTER TABLE [dbo].[PostQuestion]  WITH CHECK ADD  CONSTRAINT [FK_PostQuestion_Post] FOREIGN KEY([PostID_fk])
REFERENCES [dbo].[Post] ([PostID])
GO
ALTER TABLE [dbo].[PostQuestion] CHECK CONSTRAINT [FK_PostQuestion_Post]
GO
/****** Object:  ForeignKey [FK_PostComment_Post]    Script Date: 10/10/2018 15:45:32 ******/
ALTER TABLE [dbo].[PostComment]  WITH CHECK ADD  CONSTRAINT [FK_PostComment_Post] FOREIGN KEY([PostID_fk])
REFERENCES [dbo].[Post] ([PostID])
GO
ALTER TABLE [dbo].[PostComment] CHECK CONSTRAINT [FK_PostComment_Post]
GO
/****** Object:  ForeignKey [FK_PostCategory_Post]    Script Date: 10/10/2018 15:45:32 ******/
ALTER TABLE [dbo].[PostAttribute]  WITH CHECK ADD  CONSTRAINT [FK_PostCategory_Post] FOREIGN KEY([PostID_fk])
REFERENCES [dbo].[Post] ([PostID])
GO
ALTER TABLE [dbo].[PostAttribute] CHECK CONSTRAINT [FK_PostCategory_Post]
GO
/****** Object:  ForeignKey [FK_PostCategory_PubBase]    Script Date: 10/10/2018 15:45:32 ******/
ALTER TABLE [dbo].[PostAttribute]  WITH CHECK ADD  CONSTRAINT [FK_PostCategory_PubBase] FOREIGN KEY([AttributeID_fk])
REFERENCES [dbo].[PubBase] ([PubBaseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostAttribute] CHECK CONSTRAINT [FK_PostCategory_PubBase]
GO
/****** Object:  ForeignKey [FK_PostAnswer_PostQuestion]    Script Date: 10/10/2018 15:45:32 ******/
ALTER TABLE [dbo].[PostAnswer]  WITH CHECK ADD  CONSTRAINT [FK_PostAnswer_PostQuestion] FOREIGN KEY([PostQuestionID_fk])
REFERENCES [dbo].[PostQuestion] ([PostQuestionID])
GO
ALTER TABLE [dbo].[PostAnswer] CHECK CONSTRAINT [FK_PostAnswer_PostQuestion]
GO
