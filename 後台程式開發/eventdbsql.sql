USE [master]
GO
/****** Object:  Database [Eventdb]    Script Date: 2020/11/12 下午 04:29:36 ******/
CREATE DATABASE [Eventdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Eventdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Eventdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Eventdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Eventdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Eventdb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Eventdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Eventdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Eventdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Eventdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Eventdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Eventdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [Eventdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Eventdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Eventdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Eventdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Eventdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Eventdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Eventdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Eventdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Eventdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Eventdb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Eventdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Eventdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Eventdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Eventdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Eventdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Eventdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Eventdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Eventdb] SET RECOVERY FULL 
GO
ALTER DATABASE [Eventdb] SET  MULTI_USER 
GO
ALTER DATABASE [Eventdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Eventdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Eventdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Eventdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Eventdb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Eventdb', N'ON'
GO
ALTER DATABASE [Eventdb] SET QUERY_STORE = OFF
GO
USE [Eventdb]
GO
/****** Object:  User [Yen]    Script Date: 2020/11/12 下午 04:29:36 ******/
CREATE USER [Yen] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Event2]    Script Date: 2020/11/12 下午 04:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event2](
	[Event_ID] [int] IDENTITY(1,1) NOT NULL,
	[EventStartDate] [datetime] NULL,
	[EventEndDate] [datetime] NULL,
	[EventLocation] [nvarchar](50) NULL,
	[EventName] [nvarchar](200) NULL,
	[EventContent] [nvarchar](500) NULL,
	[EventRemark] [nvarchar](500) NULL,
	[EventMaxPeople] [int] NULL,
	[EventMinPeople] [int] NULL,
	[EventLocationX] [varchar](50) NULL,
	[EventLocationY] [varchar](50) NULL,
	[EventNowJoin] [int] NULL,
	[EventCreateEmployeeID] [int] NULL,
	[EventImage] [nvarchar](255) NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Event_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventBooking2]    Script Date: 2020/11/12 下午 04:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventBooking2](
	[Event_ID] [int] NOT NULL,
	[mb_ID] [int] NOT NULL,
	[BookingDate] [datetime] NOT NULL,
	[EmployeeJoinStatus] [int] NOT NULL,
	[BookingCount] [int] NULL,
	[Event] [int] NULL,
 CONSTRAINT [PK_EventBooking] PRIMARY KEY CLUSTERED 
(
	[Event_ID] ASC,
	[mb_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventComment2]    Script Date: 2020/11/12 下午 04:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventComment2](
	[Event_ID] [int] NOT NULL,
	[mb_ID] [int] NOT NULL,
	[CommentStatus] [int] NULL,
 CONSTRAINT [PK_EventComment] PRIMARY KEY CLUSTERED 
(
	[Event_ID] ASC,
	[mb_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Event2] ON 

INSERT [dbo].[Event2] ([Event_ID], [EventStartDate], [EventEndDate], [EventLocation], [EventName], [EventContent], [EventRemark], [EventMaxPeople], [EventMinPeople], [EventLocationX], [EventLocationY], [EventNowJoin], [EventCreateEmployeeID], [EventImage]) VALUES (41, CAST(N'2020-12-26T00:00:00.000' AS DateTime), CAST(N'2020-12-27T00:00:00.000' AS DateTime), N'和平體育館', N'打球阿', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'anonymous.jpg')
INSERT [dbo].[Event2] ([Event_ID], [EventStartDate], [EventEndDate], [EventLocation], [EventName], [EventContent], [EventRemark], [EventMaxPeople], [EventMinPeople], [EventLocationX], [EventLocationY], [EventNowJoin], [EventCreateEmployeeID], [EventImage]) VALUES (42, CAST(N'2020-11-10T00:00:00.000' AS DateTime), CAST(N'2020-11-11T00:00:00.000' AS DateTime), N'八方雲集', N'走啊吃水餃拉', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'dp.jpg')
INSERT [dbo].[Event2] ([Event_ID], [EventStartDate], [EventEndDate], [EventLocation], [EventName], [EventContent], [EventRemark], [EventMaxPeople], [EventMinPeople], [EventLocationX], [EventLocationY], [EventNowJoin], [EventCreateEmployeeID], [EventImage]) VALUES (43, CAST(N'2020-08-09T00:00:00.000' AS DateTime), CAST(N'2020-08-10T00:00:00.000' AS DateTime), N'台中市', N'去淨灘', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'馬力歐.jpg')
SET IDENTITY_INSERT [dbo].[Event2] OFF
INSERT [dbo].[EventBooking2] ([Event_ID], [mb_ID], [BookingDate], [EmployeeJoinStatus], [BookingCount], [Event]) VALUES (42, 1, CAST(N'2020-11-09T17:24:47.710' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[EventBooking2] ([Event_ID], [mb_ID], [BookingDate], [EmployeeJoinStatus], [BookingCount], [Event]) VALUES (43, 1, CAST(N'2020-11-10T14:54:48.113' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[EventComment2] ([Event_ID], [mb_ID], [CommentStatus]) VALUES (41, 1, 1)
INSERT [dbo].[EventComment2] ([Event_ID], [mb_ID], [CommentStatus]) VALUES (42, 1, 1)
INSERT [dbo].[EventComment2] ([Event_ID], [mb_ID], [CommentStatus]) VALUES (43, 1, 1)
ALTER TABLE [dbo].[EventBooking2]  WITH CHECK ADD  CONSTRAINT [FK_EventBooking_Event] FOREIGN KEY([Event_ID])
REFERENCES [dbo].[Event2] ([Event_ID])
GO
ALTER TABLE [dbo].[EventBooking2] CHECK CONSTRAINT [FK_EventBooking_Event]
GO
ALTER TABLE [dbo].[EventComment2]  WITH CHECK ADD  CONSTRAINT [FK_EventComment_Event] FOREIGN KEY([Event_ID])
REFERENCES [dbo].[Event2] ([Event_ID])
GO
ALTER TABLE [dbo].[EventComment2] CHECK CONSTRAINT [FK_EventComment_Event]
GO
USE [master]
GO
ALTER DATABASE [Eventdb] SET  READ_WRITE 
GO
