USE [master]
GO
/****** Object:  Database [DataModelingAndERDiagramsTask1]    Script Date: 21.8.2014 г. 11:11:54 ч. ******/
CREATE DATABASE [DataModelingAndERDiagramsTask1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataModelingAndERDiagramsTask1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SIKOSQLSERVER\MSSQL\DATA\DataModelingAndERDiagramsTask1.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DataModelingAndERDiagramsTask1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SIKOSQLSERVER\MSSQL\DATA\DataModelingAndERDiagramsTask1_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataModelingAndERDiagramsTask1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET ARITHABORT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET RECOVERY FULL 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET  MULTI_USER 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DataModelingAndERDiagramsTask1', N'ON'
GO
USE [DataModelingAndERDiagramsTask1]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 21.8.2014 г. 11:11:54 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[neighbourhood] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 21.8.2014 г. 11:11:54 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 21.8.2014 г. 11:11:54 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[continent] [int] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Neighbourhood]    Script Date: 21.8.2014 г. 11:11:54 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Neighbourhood](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[town] [int] NOT NULL,
 CONSTRAINT [PK_Neighbourhood] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 21.8.2014 г. 11:11:54 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[address] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 21.8.2014 г. 11:11:54 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[country] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Neighbourhood] FOREIGN KEY([neighbourhood])
REFERENCES [dbo].[Neighbourhood] ([id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Neighbourhood]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([continent])
REFERENCES [dbo].[Continent] ([id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Neighbourhood]  WITH CHECK ADD  CONSTRAINT [FK_Neighbourhood_Town] FOREIGN KEY([town])
REFERENCES [dbo].[Town] ([id])
GO
ALTER TABLE [dbo].[Neighbourhood] CHECK CONSTRAINT [FK_Neighbourhood_Town]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([address])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([country])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [DataModelingAndERDiagramsTask1] SET  READ_WRITE 
GO
