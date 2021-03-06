USE `master`
;
/****** Object:  Database `DataModelingAndERDiagrams-Task3`    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
CREATE DATABASE `DataModelingAndERDiagrams-Task3`
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataModelingAndERDiagrams-Task3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SIKOSQLSERVER\MSSQL\DATA\DataModelingAndERDiagrams-Task3.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DataModelingAndERDiagrams-Task3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SIKOSQLSERVER\MSSQL\DATA\DataModelingAndERDiagrams-Task3_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET COMPATIBILITY_LEVEL = 110
;
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC `DataModelingAndERDiagrams-Task3`.`sp_fulltext_database` @action = 'enable'
end
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET ANSI_NULL_DEFAULT OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET ANSI_NULLS OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET ANSI_PADDING OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET ANSI_WARNINGS OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET ARITHABORT OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET AUTO_CLOSE OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET AUTO_CREATE_STATISTICS ON 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET AUTO_SHRINK OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET AUTO_UPDATE_STATISTICS ON 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET CURSOR_CLOSE_ON_COMMIT OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET CURSOR_DEFAULT  GLOBAL 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET CONCAT_NULL_YIELDS_NULL OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET NUMERIC_ROUNDABORT OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET QUOTED_IDENTIFIER OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET RECURSIVE_TRIGGERS OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET  DISABLE_BROKER 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET DATE_CORRELATION_OPTIMIZATION OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET TRUSTWORTHY OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET ALLOW_SNAPSHOT_ISOLATION OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET PARAMETERIZATION SIMPLE 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET READ_COMMITTED_SNAPSHOT OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET HONOR_BROKER_PRIORITY OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET RECOVERY FULL 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET  MULTI_USER 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET PAGE_VERIFY CHECKSUM  
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET DB_CHAINING OFF 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET TARGET_RECOVERY_TIME = 0 SECONDS 
;
EXEC sys.sp_db_vardecimal_storage_format N'DataModelingAndERDiagrams-Task3', N'ON'
;
USE `DataModelingAndERDiagrams-Task3`
;
/****** Object:  Table `AcademicTitles`    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE `AcademicTitles`(
	`id` int IDENTITY(1,1) NOT NULL,
	`name` varchar(50) NOT NULL,
 CONSTRAINT `PK_AcademicTitles` PRIMARY KEY 
(
	`id` ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

;
/****** Object:  Table `Course`    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE `Course`(
	`id` int IDENTITY(1,1) NOT NULL,
	`name` varchar(50) NOT NULL,
	`department` int NOT NULL,
	`professor` int NOT NULL,
 CONSTRAINT `PK_Course` PRIMARY KEY 
(
	`id` ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

;
/****** Object:  Table `Department`    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE `Department`(
	`id` int IDENTITY(1,1) NOT NULL,
	`name` varchar(50) NOT NULL,
	`faculty` int NOT NULL,
 CONSTRAINT `PK_Department` PRIMARY KEY 
(
	`id` ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

;
/****** Object:  Table `Faculty`    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE `Faculty`(
	`id` int IDENTITY(1,1) NOT NULL,
	`name` varchar(50) NOT NULL,
	`school` int NOT NULL,
 CONSTRAINT `PK_Faculty` PRIMARY KEY 
(
	`id` ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

;
/****** Object:  Table `ProfesorTitles`    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE `ProfesorTitles`(
	`professor` int NOT NULL,
	`title` int NOT NULL,
 CONSTRAINT `PK_ProfesorTitles` PRIMARY KEY 
(
	`professor` ASC,
	`title` ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

;
/****** Object:  Table `professor`    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE `professor`(
	`id` int IDENTITY(1,1) NOT NULL,
	`name` varchar(50) NOT NULL,
	`department` int NOT NULL,
 CONSTRAINT `PK_professor` PRIMARY KEY 
(
	`id` ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

;
/****** Object:  Table `School`    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE `School`(
	`id` int IDENTITY(1,1) NOT NULL,
	`name` varchar(50) NOT NULL,
	`address` varchar(50) NULL,
 CONSTRAINT `PK_School` PRIMARY KEY 
(
	`id` ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

;
/****** Object:  Table `StudentCourses`    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE `StudentCourses`(
	`student` int NOT NULL,
	`course` int NOT NULL,
	`passed` tinyint NULL,
	`score` `tinyint` NULL,
 CONSTRAINT `PK_StudentCourses` PRIMARY KEY 
(
	`student` ASC,
	`course` ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

;
/****** Object:  Table `Students`    Script Date: 21.8.2014 г. 15:24:24 ч. ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE `Students`(
	`id` int IDENTITY(1,1) NOT NULL,
	`name` varchar(50) NOT NULL,
	`faculty` int NOT NULL,
 CONSTRAINT `PK_Students` PRIMARY KEY 
(
	`id` ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

;
ALTER TABLE `Course`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY `FK_Course_Department`(`department`)
REFERENCES `Department` (`id`)
;
ALTER TABLE `Course` CHECK CONSTRAINT `FK_Course_Department`
;
ALTER TABLE `Course`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY `FK_Course_professor`(`professor`)
REFERENCES `professor` (`id`)
;
ALTER TABLE `Course` CHECK CONSTRAINT `FK_Course_professor`
;
ALTER TABLE `Department`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY `FK_Department_Faculty`(`faculty`)
REFERENCES `Faculty` (`id`)
;
ALTER TABLE `Department` CHECK CONSTRAINT `FK_Department_Faculty`
;
ALTER TABLE `Faculty`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY `FK_Faculty_School`(`school`)
REFERENCES `School` (`id`)
;
ALTER TABLE `Faculty` CHECK CONSTRAINT `FK_Faculty_School`
;
ALTER TABLE `ProfesorTitles`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY `FK_ProfesorTitles_AcademicTitles`(`title`)
REFERENCES `AcademicTitles` (`id`)
;
ALTER TABLE `ProfesorTitles` CHECK CONSTRAINT `FK_ProfesorTitles_AcademicTitles`
;
ALTER TABLE `ProfesorTitles`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY `FK_ProfesorTitles_professor`(`professor`)
REFERENCES `professor` (`id`)
;
ALTER TABLE `ProfesorTitles` CHECK CONSTRAINT `FK_ProfesorTitles_professor`
;
ALTER TABLE `professor`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY `FK_professor_Department`(`department`)
REFERENCES `Department` (`id`)
;
ALTER TABLE `professor` CHECK CONSTRAINT `FK_professor_Department`
;
ALTER TABLE `StudentCourses`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY `FK_StudentCourses_Course`(`course`)
REFERENCES `Course` (`id`)
;
ALTER TABLE `StudentCourses` CHECK CONSTRAINT `FK_StudentCourses_Course`
;
ALTER TABLE `StudentCourses`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY `FK_StudentCourses_Students`(`student`)
REFERENCES `Students` (`id`)
;
ALTER TABLE `StudentCourses` CHECK CONSTRAINT `FK_StudentCourses_Students`
;
ALTER TABLE `Students`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY `FK_Students_Faculty`(`faculty`)
REFERENCES `Faculty` (`id`)
;
ALTER TABLE `Students` CHECK CONSTRAINT `FK_Students_Faculty`
;
USE `master`
;
ALTER DATABASE `DataModelingAndERDiagrams-Task3` SET  READ_WRITE 
;
