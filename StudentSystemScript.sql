USE [master]
GO
/****** Object:  Database [StudentSystem]    Script Date: 2/12/2021 6:00:53 AM ******/
CREATE DATABASE [StudentSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StudentSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StudentSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentSystem] SET  MULTI_USER 
GO
ALTER DATABASE [StudentSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [StudentSystem]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 2/12/2021 6:00:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[noOfStudents] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 2/12/2021 6:00:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Course]    Script Date: 2/12/2021 6:00:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Student_Id] [int] NOT NULL,
	[Course_Id] [int] NOT NULL,
 CONSTRAINT [PK_Student_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 2/12/2021 6:00:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[genderId] [int] NOT NULL,
	[Mobile] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Name], [noOfStudents]) VALUES (1, N'css', 20)
INSERT [dbo].[Courses] ([Id], [Name], [noOfStudents]) VALUES (2, N'javascript', 15)
INSERT [dbo].[Courses] ([Id], [Name], [noOfStudents]) VALUES (3, N'Angular', 10)
INSERT [dbo].[Courses] ([Id], [Name], [noOfStudents]) VALUES (4, N'Asp.net', 30)
INSERT [dbo].[Courses] ([Id], [Name], [noOfStudents]) VALUES (5, N'database', 25)
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
INSERT [dbo].[Gender] ([Id], [name]) VALUES (1, N'male')
INSERT [dbo].[Gender] ([Id], [name]) VALUES (2, N'female')
GO
SET IDENTITY_INSERT [dbo].[Student_Course] ON 

INSERT [dbo].[Student_Course] ([Id], [Student_Id], [Course_Id]) VALUES (1, 6, 1)
INSERT [dbo].[Student_Course] ([Id], [Student_Id], [Course_Id]) VALUES (2, 7, 2)
INSERT [dbo].[Student_Course] ([Id], [Student_Id], [Course_Id]) VALUES (3, 8, 3)
INSERT [dbo].[Student_Course] ([Id], [Student_Id], [Course_Id]) VALUES (4, 10, 4)
INSERT [dbo].[Student_Course] ([Id], [Student_Id], [Course_Id]) VALUES (5, 6, 2)
INSERT [dbo].[Student_Course] ([Id], [Student_Id], [Course_Id]) VALUES (6, 7, 3)
INSERT [dbo].[Student_Course] ([Id], [Student_Id], [Course_Id]) VALUES (7, 8, 4)
INSERT [dbo].[Student_Course] ([Id], [Student_Id], [Course_Id]) VALUES (8, 10, 1)
SET IDENTITY_INSERT [dbo].[Student_Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [genderId], [Mobile]) VALUES (6, N'ahmed', N'omar', 1, N'0109044023')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [genderId], [Mobile]) VALUES (7, N'mohamed', N'magdy', 1, N'01090404615')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [genderId], [Mobile]) VALUES (8, N'rahma', N'nabil', 2, N'01008431584')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [genderId], [Mobile]) VALUES (10, N'mustafa', N'moneir', 1, N'01090404515')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [genderId], [Mobile]) VALUES (11, N'mona', N'zaki', 2, N'0109932888')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
ALTER TABLE [dbo].[Student_Course]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Courses] FOREIGN KEY([Course_Id])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Student_Course] CHECK CONSTRAINT [FK_Student_Course_Courses]
GO
ALTER TABLE [dbo].[Student_Course]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Students] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Student_Course] CHECK CONSTRAINT [FK_Student_Course_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Gender] FOREIGN KEY([genderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Gender]
GO
USE [master]
GO
ALTER DATABASE [StudentSystem] SET  READ_WRITE 
GO
