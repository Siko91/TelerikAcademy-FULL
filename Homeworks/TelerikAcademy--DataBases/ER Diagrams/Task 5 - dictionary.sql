USE [master]
GO
/****** Object:  Database [DataModelingAndERDiagrams-Task5]    Script Date: 21.8.2014 г. 16:23:16 ч. ******/
CREATE DATABASE [DataModelingAndERDiagrams-Task5]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataModelingAndERDiagrams-Task5', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SIKOSQLSERVER\MSSQL\DATA\DataModelingAndERDiagrams-Task5.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DataModelingAndERDiagrams-Task5_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SIKOSQLSERVER\MSSQL\DATA\DataModelingAndERDiagrams-Task5_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataModelingAndERDiagrams-Task5].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET ARITHABORT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET RECOVERY FULL 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET  MULTI_USER 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DataModelingAndERDiagrams-Task5', N'ON'
GO
USE [DataModelingAndERDiagrams-Task5]
GO
/****** Object:  Table [dbo].[Antonims]    Script Date: 21.8.2014 г. 16:23:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antonims](
	[firstWord] [bigint] NOT NULL,
	[secondWord] [bigint] NOT NULL,
 CONSTRAINT [PK_Antonims] PRIMARY KEY CLUSTERED 
(
	[firstWord] ASC,
	[secondWord] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Explonation]    Script Date: 21.8.2014 г. 16:23:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explonation](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[explonation] [text] NULL,
 CONSTRAINT [PK_Explonation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Language]    Script Date: 21.8.2014 г. 16:23:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartOfSpeach]    Script Date: 21.8.2014 г. 16:23:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartOfSpeach](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PartOfSpeach] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonims]    Script Date: 21.8.2014 г. 16:23:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonims](
	[firstWord] [bigint] NOT NULL,
	[secondWord] [bigint] NOT NULL,
 CONSTRAINT [PK_Synonims] PRIMARY KEY CLUSTERED 
(
	[firstWord] ASC,
	[secondWord] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translations]    Script Date: 21.8.2014 г. 16:23:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[firstWord] [bigint] NOT NULL,
	[secondWord] [bigint] NOT NULL,
 CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED 
(
	[firstWord] ASC,
	[secondWord] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Word]    Script Date: 21.8.2014 г. 16:23:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Word](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[word] [nvarchar](50) NOT NULL,
	[language] [int] NOT NULL,
	[hyperonimId] [bigint] NULL,
 CONSTRAINT [PK_Word] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordCanBeUsedAs]    Script Date: 21.8.2014 г. 16:23:17 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordCanBeUsedAs](
	[word] [bigint] NOT NULL,
	[partOfSpeach] [int] NOT NULL,
 CONSTRAINT [PK_WordCanBeUsedAs] PRIMARY KEY CLUSTERED 
(
	[word] ASC,
	[partOfSpeach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Antonims]  WITH CHECK ADD  CONSTRAINT [FK_Antonims_Word] FOREIGN KEY([firstWord])
REFERENCES [dbo].[Word] ([id])
GO
ALTER TABLE [dbo].[Antonims] CHECK CONSTRAINT [FK_Antonims_Word]
GO
ALTER TABLE [dbo].[Antonims]  WITH CHECK ADD  CONSTRAINT [FK_Antonims_Word1] FOREIGN KEY([secondWord])
REFERENCES [dbo].[Word] ([id])
GO
ALTER TABLE [dbo].[Antonims] CHECK CONSTRAINT [FK_Antonims_Word1]
GO
ALTER TABLE [dbo].[Synonims]  WITH CHECK ADD  CONSTRAINT [FK_Synonims_Word] FOREIGN KEY([firstWord])
REFERENCES [dbo].[Word] ([id])
GO
ALTER TABLE [dbo].[Synonims] CHECK CONSTRAINT [FK_Synonims_Word]
GO
ALTER TABLE [dbo].[Synonims]  WITH CHECK ADD  CONSTRAINT [FK_Synonims_Word1] FOREIGN KEY([secondWord])
REFERENCES [dbo].[Word] ([id])
GO
ALTER TABLE [dbo].[Synonims] CHECK CONSTRAINT [FK_Synonims_Word1]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Word] FOREIGN KEY([firstWord])
REFERENCES [dbo].[Word] ([id])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Word]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Word1] FOREIGN KEY([secondWord])
REFERENCES [dbo].[Word] ([id])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Word1]
GO
ALTER TABLE [dbo].[Word]  WITH CHECK ADD  CONSTRAINT [FK_Word_Explonation] FOREIGN KEY([id])
REFERENCES [dbo].[Explonation] ([id])
GO
ALTER TABLE [dbo].[Word] CHECK CONSTRAINT [FK_Word_Explonation]
GO
ALTER TABLE [dbo].[Word]  WITH CHECK ADD  CONSTRAINT [FK_Word_Language] FOREIGN KEY([language])
REFERENCES [dbo].[Language] ([id])
GO
ALTER TABLE [dbo].[Word] CHECK CONSTRAINT [FK_Word_Language]
GO
ALTER TABLE [dbo].[Word]  WITH CHECK ADD  CONSTRAINT [FK_Word_Word] FOREIGN KEY([hyperonimId])
REFERENCES [dbo].[Word] ([id])
GO
ALTER TABLE [dbo].[Word] CHECK CONSTRAINT [FK_Word_Word]
GO
ALTER TABLE [dbo].[WordCanBeUsedAs]  WITH CHECK ADD  CONSTRAINT [FK_WordCanBeUsedAs_PartOfSpeach] FOREIGN KEY([partOfSpeach])
REFERENCES [dbo].[PartOfSpeach] ([id])
GO
ALTER TABLE [dbo].[WordCanBeUsedAs] CHECK CONSTRAINT [FK_WordCanBeUsedAs_PartOfSpeach]
GO
ALTER TABLE [dbo].[WordCanBeUsedAs]  WITH CHECK ADD  CONSTRAINT [FK_WordCanBeUsedAs_Word] FOREIGN KEY([word])
REFERENCES [dbo].[Word] ([id])
GO
ALTER TABLE [dbo].[WordCanBeUsedAs] CHECK CONSTRAINT [FK_WordCanBeUsedAs_Word]
GO
USE [master]
GO
ALTER DATABASE [DataModelingAndERDiagrams-Task5] SET  READ_WRITE 
GO
