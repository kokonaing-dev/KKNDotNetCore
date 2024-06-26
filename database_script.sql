 USE [master]
GO
/****** Object:  Database [DotNetTesting]    Script Date: 4/27/2024 8:57:34 PM ******/
CREATE DATABASE [DotNetTesting]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DotNetTesting', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DotNetTesting.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DotNetTesting_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DotNetTesting_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DotNetTesting].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DotNetTesting] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DotNetTesting] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DotNetTesting] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DotNetTesting] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DotNetTesting] SET ARITHABORT OFF 
GO
ALTER DATABASE [DotNetTesting] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DotNetTesting] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DotNetTesting] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DotNetTesting] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DotNetTesting] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DotNetTesting] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DotNetTesting] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DotNetTesting] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DotNetTesting] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DotNetTesting] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DotNetTesting] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DotNetTesting] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DotNetTesting] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DotNetTesting] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DotNetTesting] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DotNetTesting] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DotNetTesting] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DotNetTesting] SET RECOVERY FULL 
GO
ALTER DATABASE [DotNetTesting] SET  MULTI_USER 
GO
ALTER DATABASE [DotNetTesting] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DotNetTesting] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DotNetTesting] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DotNetTesting] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DotNetTesting] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DotNetTesting', N'ON'
GO
ALTER DATABASE [DotNetTesting] SET QUERY_STORE = ON
GO
ALTER DATABASE [DotNetTesting] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200)
GO
USE [DotNetTesting]
GO
/****** Object:  Table [dbo].[Tbl_Blog]    Script Date: 4/27/2024 8:57:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Blog](
	[Blog_Id] [int] IDENTITY(1,1) NOT NULL,
	[Blog_Title] [varchar](50) NOT NULL,
	[Blog_Author] [varchar](50) NOT NULL,
	[Blog_Content] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Blog] PRIMARY KEY CLUSTERED 
(
	[Blog_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Blog] ON 

INSERT [dbo].[Tbl_Blog] ([Blog_Id], [Blog_Title], [Blog_Author], [Blog_Content]) VALUES (1, N'author 2', N'content 2', N'title 2')
INSERT [dbo].[Tbl_Blog] ([Blog_Id], [Blog_Title], [Blog_Author], [Blog_Content]) VALUES (4, N'string', N'string', N'string')
INSERT [dbo].[Tbl_Blog] ([Blog_Id], [Blog_Title], [Blog_Author], [Blog_Content]) VALUES (5, N'Lay Lwin Thu', N'Mya Than Tint', N'content is content')
INSERT [dbo].[Tbl_Blog] ([Blog_Id], [Blog_Title], [Blog_Author], [Blog_Content]) VALUES (6, N'Rest Client Testing', N'Mya Than Tint', N'content is content')
INSERT [dbo].[Tbl_Blog] ([Blog_Id], [Blog_Title], [Blog_Author], [Blog_Content]) VALUES (7, N'demo title', N'demo author', N'demo content')
INSERT [dbo].[Tbl_Blog] ([Blog_Id], [Blog_Title], [Blog_Author], [Blog_Content]) VALUES (9, N'demo update', N'demo update', N'updating in progress')
SET IDENTITY_INSERT [dbo].[Tbl_Blog] OFF
GO
USE [master]
GO
ALTER DATABASE [DotNetTesting] SET  READ_WRITE 
GO
