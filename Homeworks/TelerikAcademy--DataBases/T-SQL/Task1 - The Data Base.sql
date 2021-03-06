USE [master]
GO
/****** Object:  Database [T-SQL-Task1-SimpleAccountSystem]    Script Date: 23.8.2014 г. 10:39:39 ч. ******/
CREATE DATABASE [T-SQL-Task1-SimpleAccountSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'T-SQL-Task1-SimpleAccountSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SIKOSQLSERVER\MSSQL\DATA\T-SQL-Task1-SimpleAccountSystem.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'T-SQL-Task1-SimpleAccountSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SIKOSQLSERVER\MSSQL\DATA\T-SQL-Task1-SimpleAccountSystem_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [T-SQL-Task1-SimpleAccountSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET  MULTI_USER 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'T-SQL-Task1-SimpleAccountSystem', N'ON'
GO
USE [T-SQL-Task1-SimpleAccountSystem]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 23.8.2014 г. 10:39:39 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[Balance] [money] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 23.8.2014 г. 10:39:39 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[SSN] [nvarchar](9) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Persons] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([Id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Persons]
GO
USE [master]
GO
ALTER DATABASE [T-SQL-Task1-SimpleAccountSystem] SET  READ_WRITE 
GO
