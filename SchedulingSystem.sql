USE [SchedulingSystem]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 1/26/2022 10:31:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 1/26/2022 10:31:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentClassMapper]    Script Date: 1/26/2022 10:31:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentClassMapper](
	[MapperID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[AssignedDate] [datetime] NULL,
	[AssignedBy] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Mapper] PRIMARY KEY CLUSTERED 
(
	[MapperID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Class] ON 
GO
INSERT [dbo].[Class] ([ClassID], [Code], [Title], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, 1000, N'Python', N'Learn Python', CAST(N'2022-01-25T12:28:00.530' AS DateTime), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Class] ([ClassID], [Code], [Title], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, 1001, N'Java', N'Learn Java', CAST(N'2022-01-25T12:28:00.577' AS DateTime), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Class] ([ClassID], [Code], [Title], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3, 1002, N'Javascript', N'Learn Javascript', CAST(N'2022-01-25T12:28:00.577' AS DateTime), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Class] ([ClassID], [Code], [Title], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (4, 1003, N'C#', N'Learn C#', CAST(N'2022-01-25T12:28:00.577' AS DateTime), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Class] ([ClassID], [Code], [Title], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (5, 1004, N'C and C++', N'Learn C and C++', CAST(N'2022-01-25T12:28:00.577' AS DateTime), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Class] ([ClassID], [Code], [Title], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (6, 1005, N'PHP', N'Learn PHP', CAST(N'2022-01-25T12:28:00.577' AS DateTime), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Class] ([ClassID], [Code], [Title], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (7, 1006, N'Angular', N'Learn Angular', CAST(N'2022-01-25T12:28:00.577' AS DateTime), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Class] ([ClassID], [Code], [Title], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (8, 1007, N'SQL', N'Learn SQL', CAST(N'2022-01-25T12:28:00.577' AS DateTime), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Class] ([ClassID], [Code], [Title], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (9, 1008, N'Swift', N'Learn Swift', CAST(N'2022-01-25T12:28:00.577' AS DateTime), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Class] ([ClassID], [Code], [Title], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (10, 1009, N'MongoDB', N'Learn MongoDB', CAST(N'2022-01-25T12:28:00.577' AS DateTime), N'System', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([StudentID], [LastName], [FirstName], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, N'Narendra', N'Kosireddy', CAST(N'2022-01-25T06:47:55.093' AS DateTime), N'System', CAST(N'2022-01-25T06:47:55.093' AS DateTime), N'None', 1)
GO
INSERT [dbo].[Student] ([StudentID], [LastName], [FirstName], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, N'Mission', N'A', CAST(N'2022-01-26T04:57:52.217' AS DateTime), N'string', CAST(N'2022-01-26T04:57:52.217' AS DateTime), N'string', 1)
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentClassMapper] ON 
GO
INSERT [dbo].[StudentClassMapper] ([MapperID], [StudentID], [ClassID], [AssignedDate], [AssignedBy], [IsActive]) VALUES (1, 1, 2, CAST(N'2022-01-26T05:15:35.277' AS DateTime), N'system', 0)
GO
INSERT [dbo].[StudentClassMapper] ([MapperID], [StudentID], [ClassID], [AssignedDate], [AssignedBy], [IsActive]) VALUES (2, 1, 1, CAST(N'2022-01-26T05:47:53.223' AS DateTime), N'Sys', 1)
GO
SET IDENTITY_INSERT [dbo].[StudentClassMapper] OFF
GO
/****** Object:  Index [UQ__StudentC__2E74B802ABD22CDC]    Script Date: 1/26/2022 10:31:21 AM ******/
ALTER TABLE [dbo].[StudentClassMapper] ADD UNIQUE NONCLUSTERED 
(
	[StudentID] ASC,
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[StudentClassMapper] ADD  CONSTRAINT [DF_StudentClassMapper_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[StudentClassMapper]  WITH CHECK ADD FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
GO
ALTER TABLE [dbo].[StudentClassMapper]  WITH CHECK ADD FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
/****** Object:  StoredProcedure [dbo].[usp_GetClassMappingByStudentId]    Script Date: 1/26/2022 10:31:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Narendra>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetClassMappingByStudentId] 
	@Id int	
AS
BEGIN
	select c.Title as ClassName,C.Description from [dbo].[Class] c
	join [dbo].[StudentClassMapper] scm
	on scm.ClassID = c.ClassID
	where scm.StudentID = @Id and scm.IsActive = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetStudentMappingByClassId]    Script Date: 1/26/2022 10:31:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Narendra>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetStudentMappingByClassId] 
	@Id int	
AS
BEGIN
	select s.StudentId,s.LastName + ','+s.FirstName as 'StudentName' from [dbo].[Student] s 
	join [dbo].[StudentClassMapper] scm
	on scm.StudentID = s.StudentId
	where scm.ClassID = @Id and scm.IsActive = 1;
END
GO
