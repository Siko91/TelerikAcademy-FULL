USE [master]
GO
/****** Object:  Database [DataModelingAndERDiagrams-Task3]    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
CREATE DATABASE [DataModelingAndERDiagrams-Task3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataModelingAndERDiagrams-Task3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SIKOSQLSERVER\MSSQL\DATA\DataModelingAndERDiagrams-Task3.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DataModelingAndERDiagrams-Task3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SIKOSQLSERVER\MSSQL\DATA\DataModelingAndERDiagrams-Task3_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataModelingAndERDiagrams-Task3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET ARITHABORT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET RECOVERY FULL 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET  MULTI_USER 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DataModelingAndERDiagrams-Task3', N'ON'
GO
USE [DataModelingAndERDiagrams-Task3]
GO
/****** Object:  Table [dbo].[AcademicTitles]    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcademicTitles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AcademicTitles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course]    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[department] [int] NOT NULL,
	[professor] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[faculty] [int] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[school] [int] NOT NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfesorTitles]    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfesorTitles](
	[professor] [int] NOT NULL,
	[title] [int] NOT NULL,
 CONSTRAINT [PK_ProfesorTitles] PRIMARY KEY CLUSTERED 
(
	[professor] ASC,
	[title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[professor]    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[professor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[department] [int] NOT NULL,
 CONSTRAINT [PK_professor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[School]    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[address] [nvarchar](50) NULL,
 CONSTRAINT [PK_School] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentCourses]    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourses](
	[student] [int] NOT NULL,
	[course] [int] NOT NULL,
	[passed] [bit] NULL,
	[score] [tinyint] NULL,
 CONSTRAINT [PK_StudentCourses] PRIMARY KEY CLUSTERED 
(
	[student] ASC,
	[course] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[faculty] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department] FOREIGN KEY([department])
REFERENCES [dbo].[Department] ([id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_professor] FOREIGN KEY([professor])
REFERENCES [dbo].[professor] ([id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_professor]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Faculty] FOREIGN KEY([faculty])
REFERENCES [dbo].[Faculty] ([id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Faculty]
GO
ALTER TABLE [dbo].[Faculty]  WITH CHECK ADD  CONSTRAINT [FK_Faculty_School] FOREIGN KEY([school])
REFERENCES [dbo].[School] ([id])
GO
ALTER TABLE [dbo].[Faculty] CHECK CONSTRAINT [FK_Faculty_School]
GO
ALTER TABLE [dbo].[ProfesorTitles]  WITH CHECK ADD  CONSTRAINT [FK_ProfesorTitles_AcademicTitles] FOREIGN KEY([title])
REFERENCES [dbo].[AcademicTitles] ([id])
GO
ALTER TABLE [dbo].[ProfesorTitles] CHECK CONSTRAINT [FK_ProfesorTitles_AcademicTitles]
GO
ALTER TABLE [dbo].[ProfesorTitles]  WITH CHECK ADD  CONSTRAINT [FK_ProfesorTitles_professor] FOREIGN KEY([professor])
REFERENCES [dbo].[professor] ([id])
GO
ALTER TABLE [dbo].[ProfesorTitles] CHECK CONSTRAINT [FK_ProfesorTitles_professor]
GO
ALTER TABLE [dbo].[professor]  WITH CHECK ADD  CONSTRAINT [FK_professor_Department] FOREIGN KEY([department])
REFERENCES [dbo].[Department] ([id])
GO
ALTER TABLE [dbo].[professor] CHECK CONSTRAINT [FK_professor_Department]
GO
ALTER TABLE [dbo].[StudentCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourses_Course] FOREIGN KEY([course])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[StudentCourses] CHECK CONSTRAINT [FK_StudentCourses_Course]
GO
ALTER TABLE [dbo].[StudentCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourses_Students] FOREIGN KEY([student])
REFERENCES [dbo].[Students] ([id])
GO
ALTER TABLE [dbo].[StudentCourses] CHECK CONSTRAINT [FK_StudentCourses_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculty] FOREIGN KEY([faculty])
REFERENCES [dbo].[Faculty] ([id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculty]
GO
USE [master]
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task3] SET  READ_WRITE 
GO
