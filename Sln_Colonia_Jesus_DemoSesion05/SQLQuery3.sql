
GO
/****** Object:  StoredProcedure [dbo].[GetStudentGrades]    Script Date: 3/15/2021 9:29:06 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetStudentGrades]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentCourse]') AND type in (N'U'))
ALTER TABLE [dbo].[StudentCourse] DROP CONSTRAINT IF EXISTS [FK_StudentCourse_Student]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentCourse]') AND type in (N'U'))
ALTER TABLE [dbo].[StudentCourse] DROP CONSTRAINT IF EXISTS [FK_StudentCourse_Course]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Grades]') AND type in (N'U'))
ALTER TABLE [dbo].[Grades] DROP CONSTRAINT IF EXISTS [FK_Grades_StudentCourse]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Grades]') AND type in (N'U'))
ALTER TABLE [dbo].[Grades] DROP CONSTRAINT IF EXISTS [DF_Grades_InsertedDate]
GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 3/15/2021 9:29:06 AM ******/
DROP TABLE IF EXISTS [dbo].[StudentCourse]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 3/15/2021 9:29:06 AM ******/
DROP TABLE IF EXISTS [dbo].[Student]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 3/15/2021 9:29:06 AM ******/
DROP TABLE IF EXISTS [dbo].[Grades]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 3/15/2021 9:29:06 AM ******/
DROP TABLE IF EXISTS [dbo].[Course]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 3/15/2021 9:29:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Description] [varchar](100) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 3/15/2021 9:29:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentCourseId] [varchar](100) NOT NULL,
	[Grade] [numeric](18, 2) NOT NULL,
	[InsertedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Grades_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 3/15/2021 9:29:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](100) NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[BirthDate] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 3/15/2021 9:29:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourse](
	[Id] [varchar](100) NOT NULL,
	[Student_Id] [int] NOT NULL,
	[Course_Id] [int] NOT NULL,
	[Year] [int] NULL,
	[Term] [varchar](3) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_StudentCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Grades] ADD  CONSTRAINT [DF_Grades_InsertedDate]  DEFAULT (getdate()) FOR [InsertedDate]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_StudentCourse] FOREIGN KEY([StudentCourseId])
REFERENCES [dbo].[StudentCourse] ([Id])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_StudentCourse]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Course] FOREIGN KEY([Course_Id])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Course]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Student] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Student]
GO
/****** Object:  StoredProcedure [dbo].[GetStudentGrades]    Script Date: 3/15/2021 9:29:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Andres Triana
-- Create date: 3/14/2021
-- Description:	Obtiene Todas las notas para 
-- estudiantes pertenecientes a un a�o y periodo 
-- especificos.
-- =============================================
CREATE PROCEDURE [dbo].[GetStudentGrades] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	
	Select S.Code,s.LastName,s.FirstName,C.Name as Course,SC.Year,SC.Term,G.Grade 
	from Grades G
	inner join StudentCourse SC ON G.StudentCourseId = SC.Id
	inner join Student S ON SC.Student_Id=S.Id
	inner join Course C ON SC.Course_Id=C.Id
	Order by SC.Year desc ,Sc.Term desc,S.LastName asc
	
END
GO

--delete [Grades]
--delete [StudentCourse]
--delete [Student]
--delete [Course]
--DBCC CHECKIDENT ('Student', RESEED, 1)
--DBCC CHECKIDENT ('Course', RESEED, 1)

declare @year int = 2020
declare @term varchar(3)='B'

INSERT INTO [dbo].[Course]VALUES('SEMINARIO ACTUALIZACION','.Net Core',1)
INSERT INTO [dbo].[Course]VALUES('INGENIERIA DE SOFTWARE','Scrum Agile',1)
INSERT INTO [dbo].[Course]VALUES('MATEMATICA 2','Integrales',1);
INSERT INTO [dbo].[Course]VALUES('BASE DE DATOS I','SQLServer/Posgresql',1)
INSERT INTO [dbo].[Course]VALUES('SEMINARIO DEPORTIVO','Educacion Fisica',1)
--([Code],[FirstName],[LastName],[BirthDate],[Active])
INSERT INTO [dbo].[Student]VALUES('113025894','Andres','Triana','6/1/1986',1)
declare @id int = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025895','Fernando','Cordoba','3/5/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025896','Lina','Mu�oz','7/16/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025897','Sandra','Cardona','9/15/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025898','Francia','Lopez','2/12/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025899','John','Murillo','10/15/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025800','Joaquin','Mosquera','3/22/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025801','Alba','Quijano','12/29/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025802','Claudia','Lopera','2/28/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025803','Pedro','Arroyo','1/8/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course

/*-------------------------------------------------------------------------------------
*/
set @year = 2021
set @term ='A'
INSERT INTO [dbo].[Student]VALUES('113025622','Miguel','Ruiz','6/1/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025623','Juan','Gomez','3/5/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025624','Milena','Arias','7/16/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025625','Tatiana','Castillo','9/15/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025626','Estefani','Jimenez','2/12/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025627','Oscar','Ararat','10/15/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025628','Carlos','Martinez','3/22/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025629','Richard','Zapata','12/29/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025630','Yully','Velez','2/28/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course
INSERT INTO [dbo].[Student]VALUES('113025631','Ricardo','Torres','1/8/1986',1)
set @id = @@identity
INSERT INTO [dbo].[StudentCourse] select cast(NEWID() as varchar(100)),@id,Id,@year,@term,1 from Course



DECLARE @Random numeric(10,2);
DECLARE @Upper INT;
DECLARE @Lower INT
SET @Lower = 1 ---- The lowest random number
SET @Upper = 50 ---- The highest random number
--SELECT @Random = ROUND(((@Upper - @Lower -1) * RAND() + @Lower), 0)/10 
--SELECT @Random




DECLARE @SCId varchar(100)
DECLARE contact_cursor CURSOR FOR  
SELECT Id FROM [dbo].[StudentCourse] 
OPEN contact_cursor;  
-- Perform the first fetch.  
FETCH NEXT FROM contact_cursor into @SCId;  
  
-- Check @@FETCH_STATUS to see if there are any more rows to fetch.  
WHILE @@FETCH_STATUS = 0  
BEGIN  
   -- This is executed as long as the previous fetch succeeds.  
   INSERT INTO [dbo].[Grades] VALUES(@SCId,ROUND(((@Upper - @Lower -1) * RAND() + @Lower), 0)/10 ,GETDATE())   
   FETCH NEXT FROM contact_cursor into @SCId;  
END  
  
CLOSE contact_cursor;  
DEALLOCATE contact_cursor; 