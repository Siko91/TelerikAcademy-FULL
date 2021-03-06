USE [master]
GO
/****** Object:  Database [EmployeeProjectSystem]    Script Date: 8.9.2014 г. 12:45:42 ч. ******/
CREATE DATABASE [EmployeeProjectSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeProjectSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SIKOSQLSERVER\MSSQL\DATA\EmployeeProjectSystem.mdf' , SIZE = 6144KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EmployeeProjectSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SIKOSQLSERVER\MSSQL\DATA\EmployeeProjectSystem_log.ldf' , SIZE = 10176KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EmployeeProjectSystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeProjectSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeProjectSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeProjectSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeProjectSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeProjectSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeProjectSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeProjectSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [EmployeeProjectSystem] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeProjectSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeProjectSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeProjectSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeProjectSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EmployeeProjectSystem', N'ON'
GO
USE [EmployeeProjectSystem]
GO
/****** Object:  Table [dbo].[Departaments]    Script Date: 8.9.2014 г. 12:45:42 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departaments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Departaments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_DepartamentName] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 8.9.2014 г. 12:45:42 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[YearSalary] [money] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[ManagerId] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeesWorkOnProjects]    Script Date: 8.9.2014 г. 12:45:42 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesWorkOnProjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 8.9.2014 г. 12:45:42 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reports]    Script Date: 8.9.2014 г. 12:45:42 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[TimeOfReport] [datetime] NOT NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Employee_Department]    Script Date: 8.9.2014 г. 12:45:42 ч. ******/
CREATE NONCLUSTERED INDEX [IX_Employee_Department] ON [dbo].[Employees]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Employee_FullName]    Script Date: 8.9.2014 г. 12:45:42 ч. ******/
CREATE NONCLUSTERED INDEX [IX_Employee_FullName] ON [dbo].[Employees]
(
	[FirstName] ASC,
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employee_Salery]    Script Date: 8.9.2014 г. 12:45:42 ч. ******/
CREATE NONCLUSTERED INDEX [IX_Employee_Salery] ON [dbo].[Employees]
(
	[YearSalary] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeId]    Script Date: 8.9.2014 г. 12:45:42 ч. ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeId] ON [dbo].[EmployeesWorkOnProjects]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeesWorkOnProjects]    Script Date: 8.9.2014 г. 12:45:42 ч. ******/
CREATE NONCLUSTERED INDEX [IX_EmployeesWorkOnProjects] ON [dbo].[EmployeesWorkOnProjects]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectId]    Script Date: 8.9.2014 г. 12:45:42 ч. ******/
CREATE NONCLUSTERED INDEX [IX_ProjectId] ON [dbo].[EmployeesWorkOnProjects]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ProjectName]    Script Date: 8.9.2014 г. 12:45:42 ч. ******/
CREATE NONCLUSTERED INDEX [IX_ProjectName] ON [dbo].[Projects]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReportDate]    Script Date: 8.9.2014 г. 12:45:42 ч. ******/
CREATE NONCLUSTERED INDEX [IX_ReportDate] ON [dbo].[Reports]
(
	[TimeOfReport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departaments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departaments] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departaments]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Employees] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees]
GO
ALTER TABLE [dbo].[EmployeesWorkOnProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesWorkOnProjects_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[EmployeesWorkOnProjects] CHECK CONSTRAINT [FK_EmployeesWorkOnProjects_Employees]
GO
ALTER TABLE [dbo].[EmployeesWorkOnProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesWorkOnProjects_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[EmployeesWorkOnProjects] CHECK CONSTRAINT [FK_EmployeesWorkOnProjects_Projects]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_Employees]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [CK_MinFirstNameLength] CHECK  ((len(ltrim(rtrim([FirstName])))>(4)))
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [CK_MinFirstNameLength]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [CK_MinLastNameLength] CHECK  ((len(ltrim(rtrim([LastName])))>(4)))
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [CK_MinLastNameLength]
GO
USE [master]
GO
ALTER DATABASE [EmployeeProjectSystem] SET  READ_WRITE 
GO
