USE [master]
GO
/****** Object:  Database [ClassRegDemo]    Script Date: 06/04/2012 21:52:58 ******/
CREATE DATABASE [ClassRegDemo] ON  PRIMARY 
( NAME = N'GHClassReg2', FILENAME = N'c:\temp\ClassRegDemo.mdf' , SIZE = 4048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GHClassReg2_log', FILENAME = N'c:\temp\ClassRegDemo_1.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ClassRegDemo] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ClassRegDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ClassRegDemo] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ClassRegDemo] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ClassRegDemo] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ClassRegDemo] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ClassRegDemo] SET ARITHABORT OFF
GO
ALTER DATABASE [ClassRegDemo] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ClassRegDemo] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ClassRegDemo] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ClassRegDemo] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ClassRegDemo] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ClassRegDemo] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ClassRegDemo] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ClassRegDemo] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ClassRegDemo] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ClassRegDemo] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ClassRegDemo] SET  DISABLE_BROKER
GO
ALTER DATABASE [ClassRegDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ClassRegDemo] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ClassRegDemo] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ClassRegDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ClassRegDemo] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ClassRegDemo] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ClassRegDemo] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ClassRegDemo] SET  READ_WRITE
GO
ALTER DATABASE [ClassRegDemo] SET RECOVERY SIMPLE
GO
ALTER DATABASE [ClassRegDemo] SET  MULTI_USER
GO
ALTER DATABASE [ClassRegDemo] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ClassRegDemo] SET DB_CHAINING OFF
GO
USE [ClassRegDemo]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 06/04/2012 21:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Zip] [int] NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [City], [State], [Country], [Zip]) VALUES (1, N'Dealv THOMAS', N'555 4th ave', N'Fremont', N'CA', N'USA', 92301)
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [City], [State], [Country], [Zip]) VALUES (2, N'Yorida Moor', N'7 Melrose Ave', N'Fremont', N'CA', N'USA', 92302)
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [City], [State], [Country], [Zip]) VALUES (3, N'JACKSON Jimm', N'1372 Mission Blvd', N'San Jose', N'CA', N'USA', 92401)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
/****** Object:  Table [dbo].[Student]    Script Date: 06/04/2012 21:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Zip] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Student] ON
INSERT [dbo].[Student] ([Id], [Name], [Address], [City], [State], [Country], [Zip]) VALUES (1, N'Johson Smith', N'234 I street', N'Fremont', N'CA', N'USA', 92313)
INSERT [dbo].[Student] ([Id], [Name], [Address], [City], [State], [Country], [Zip]) VALUES (2, N'Mike Miller', N'345 T Str', N'Fremont', N'CA', N'USA', 92030)
INSERT [dbo].[Student] ([Id], [Name], [Address], [City], [State], [Country], [Zip]) VALUES (3, N'Christin Moore', N'3 F Str', N'Fremont', N'CA', N'USA', 92103)
SET IDENTITY_INSERT [dbo].[Student] OFF
/****** Object:  Table [dbo].[Club]    Script Date: 06/04/2012 21:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Club](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Class2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Club] ON
INSERT [dbo].[Club] ([Id], [Name], [Description]) VALUES (1, N'Basketball', N'Backetball')
INSERT [dbo].[Club] ([Id], [Name], [Description]) VALUES (2, N'Dancing', N'Dancing')
INSERT [dbo].[Club] ([Id], [Name], [Description]) VALUES (3, N'Tennis', N'Tennis')
INSERT [dbo].[Club] ([Id], [Name], [Description]) VALUES (4, N'Singing', N'Singing')
SET IDENTITY_INSERT [dbo].[Club] OFF
/****** Object:  Table [dbo].[Class]    Script Date: 06/04/2012 21:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[TeacherId] [int] NULL,
	[Grade] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Class] ON
INSERT [dbo].[Class] ([Id], [Name], [Description], [TeacherId], [Grade]) VALUES (2, N'CSC1201', N'Hahaffaffa', 1, 1)
INSERT [dbo].[Class] ([Id], [Name], [Description], [TeacherId], [Grade]) VALUES (3, N'CSC1202', N'Java', 1, 1)
INSERT [dbo].[Class] ([Id], [Name], [Description], [TeacherId], [Grade]) VALUES (4, N'CSC3201', N'Data Structure', 2, 2)
INSERT [dbo].[Class] ([Id], [Name], [Description], [TeacherId], [Grade]) VALUES (5, N'CSC4403', N'Database', 2, 3)
INSERT [dbo].[Class] ([Id], [Name], [Description], [TeacherId], [Grade]) VALUES (6, N'CSC3456', N'Good', 1, 3)
INSERT [dbo].[Class] ([Id], [Name], [Description], [TeacherId], [Grade]) VALUES (96, N'CSC3456-7777777', N'Good7777777', NULL, 3)
INSERT [dbo].[Class] ([Id], [Name], [Description], [TeacherId], [Grade]) VALUES (97, N'CSC3756-7777777', N'OK-7777777', NULL, 3)
INSERT [dbo].[Class] ([Id], [Name], [Description], [TeacherId], [Grade]) VALUES (98, N'TestClassOnly', N'e5255fd509bd49e3', NULL, 3)
INSERT [dbo].[Class] ([Id], [Name], [Description], [TeacherId], [Grade]) VALUES (99, N'24518d35', N'15902388cbb7418d', 3, 3)
INSERT [dbo].[Class] ([Id], [Name], [Description], [TeacherId], [Grade]) VALUES (100, N'706c571f', N'2ce7900d865a4c02', 2, 3)
INSERT [dbo].[Class] ([Id], [Name], [Description], [TeacherId], [Grade]) VALUES (101, N'846246b4', N'1b892895ead04cae', 3, 3)
SET IDENTITY_INSERT [dbo].[Class] OFF
/****** Object:  Table [dbo].[StudentClubMatch]    Script Date: 06/04/2012 21:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentClubMatch](
	[StudentId] [int] NOT NULL,
	[ClubId] [int] NOT NULL,
	[IsCommiteMember] [bit] NOT NULL,
 CONSTRAINT [PK_StudentClassMatch3] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[ClubId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentClassMatch]    Script Date: 06/04/2012 21:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentClassMatch](
	[StudentId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
 CONSTRAINT [PK_StudentClassMatch2] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[ClassId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Class_Teacher]    Script Date: 06/04/2012 21:52:59 ******/
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_Teacher]
GO
/****** Object:  ForeignKey [FK_StudentClubMatch_Club]    Script Date: 06/04/2012 21:52:59 ******/
ALTER TABLE [dbo].[StudentClubMatch]  WITH CHECK ADD  CONSTRAINT [FK_StudentClubMatch_Club] FOREIGN KEY([ClubId])
REFERENCES [dbo].[Club] ([Id])
GO
ALTER TABLE [dbo].[StudentClubMatch] CHECK CONSTRAINT [FK_StudentClubMatch_Club]
GO
/****** Object:  ForeignKey [FK_StudentClubMatch_Student]    Script Date: 06/04/2012 21:52:59 ******/
ALTER TABLE [dbo].[StudentClubMatch]  WITH CHECK ADD  CONSTRAINT [FK_StudentClubMatch_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentClubMatch] CHECK CONSTRAINT [FK_StudentClubMatch_Student]
GO
/****** Object:  ForeignKey [FK_School1StudentClassMatch_School1Class]    Script Date: 06/04/2012 21:52:59 ******/
ALTER TABLE [dbo].[StudentClassMatch]  WITH CHECK ADD  CONSTRAINT [FK_School1StudentClassMatch_School1Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([Id])
GO
ALTER TABLE [dbo].[StudentClassMatch] CHECK CONSTRAINT [FK_School1StudentClassMatch_School1Class]
GO
/****** Object:  ForeignKey [FK_School1StudentClassMatch_School1Student]    Script Date: 06/04/2012 21:52:59 ******/
ALTER TABLE [dbo].[StudentClassMatch]  WITH CHECK ADD  CONSTRAINT [FK_School1StudentClassMatch_School1Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentClassMatch] CHECK CONSTRAINT [FK_School1StudentClassMatch_School1Student]
GO
