/****** Object:  StoredProcedure [Security].[UserByUserNameGet]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Security].[UserByUserNameGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Security].[UserByUserNameGet]
GO
/****** Object:  StoredProcedure [General].[SubAreaByIDAreaGet]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[SubAreaByIDAreaGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [General].[SubAreaByIDAreaGet]
GO
/****** Object:  StoredProcedure [General].[EmployeeUpdate]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[EmployeeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [General].[EmployeeUpdate]
GO
/****** Object:  StoredProcedure [General].[EmployeeGetByFilter]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[EmployeeGetByFilter]') AND type in (N'P', N'PC'))
DROP PROCEDURE [General].[EmployeeGetByFilter]
GO
/****** Object:  StoredProcedure [General].[EmployeeGetAll]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[EmployeeGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [General].[EmployeeGetAll]
GO
/****** Object:  StoredProcedure [General].[EmployeeDelete]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[EmployeeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [General].[EmployeeDelete]
GO
/****** Object:  StoredProcedure [General].[EmployeeCreate]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[EmployeeCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [General].[EmployeeCreate]
GO
/****** Object:  StoredProcedure [General].[EmployeeByIDGet]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[EmployeeByIDGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [General].[EmployeeByIDGet]
GO
/****** Object:  StoredProcedure [General].[EmployeeAutocomplete]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[EmployeeAutocomplete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [General].[EmployeeAutocomplete]
GO
/****** Object:  StoredProcedure [General].[DataListByTypeGet]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[DataListByTypeGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [General].[DataListByTypeGet]
GO
/****** Object:  StoredProcedure [General].[AreaGet]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[AreaGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [General].[AreaGet]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Security].[FK_UserRole_User_ID]') AND parent_object_id = OBJECT_ID(N'[Security].[UserRole]'))
ALTER TABLE [Security].[UserRole] DROP CONSTRAINT [FK_UserRole_User_ID]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Security].[FK_UserRole_Role_ID]') AND parent_object_id = OBJECT_ID(N'[Security].[UserRole]'))
ALTER TABLE [Security].[UserRole] DROP CONSTRAINT [FK_UserRole_Role_ID]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Security].[FK_User_Employee_ID]') AND parent_object_id = OBJECT_ID(N'[Security].[User]'))
ALTER TABLE [Security].[User] DROP CONSTRAINT [FK_User_Employee_ID]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[General].[FK_SubArea_Area_ID]') AND parent_object_id = OBJECT_ID(N'[General].[SubArea]'))
ALTER TABLE [General].[SubArea] DROP CONSTRAINT [FK_SubArea_Area_ID]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[General].[FK_Employee_User_IDUserCreation]') AND parent_object_id = OBJECT_ID(N'[General].[Employee]'))
ALTER TABLE [General].[Employee] DROP CONSTRAINT [FK_Employee_User_IDUserCreation]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[General].[FK_Employee_SubArea_ID]') AND parent_object_id = OBJECT_ID(N'[General].[Employee]'))
ALTER TABLE [General].[Employee] DROP CONSTRAINT [FK_Employee_SubArea_ID]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[General].[FK_Employee_DataList_IDDocumentType]') AND parent_object_id = OBJECT_ID(N'[General].[Employee]'))
ALTER TABLE [General].[Employee] DROP CONSTRAINT [FK_Employee_DataList_IDDocumentType]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[General].[FK_DataList_DataListType]') AND parent_object_id = OBJECT_ID(N'[General].[DataList]'))
ALTER TABLE [General].[DataList] DROP CONSTRAINT [FK_DataList_DataListType]
GO
/****** Object:  View [General].[VW_SubArea]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[General].[VW_SubArea]'))
DROP VIEW [General].[VW_SubArea]
GO
/****** Object:  View [General].[VW_Employee]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[General].[VW_Employee]'))
DROP VIEW [General].[VW_Employee]
GO
/****** Object:  View [General].[VW_DataList]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[General].[VW_DataList]'))
DROP VIEW [General].[VW_DataList]
GO
/****** Object:  Table [Security].[UserRole]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Security].[UserRole]') AND type in (N'U'))
DROP TABLE [Security].[UserRole]
GO
/****** Object:  Table [Security].[User]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Security].[User]') AND type in (N'U'))
DROP TABLE [Security].[User]
GO
/****** Object:  Table [Security].[Role]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Security].[Role]') AND type in (N'U'))
DROP TABLE [Security].[Role]
GO
/****** Object:  Table [General].[SubArea]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[SubArea]') AND type in (N'U'))
DROP TABLE [General].[SubArea]
GO
/****** Object:  Table [General].[Employee]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[Employee]') AND type in (N'U'))
DROP TABLE [General].[Employee]
GO
/****** Object:  Table [General].[DataListType]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[DataListType]') AND type in (N'U'))
DROP TABLE [General].[DataListType]
GO
/****** Object:  Table [General].[DataList]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[DataList]') AND type in (N'U'))
DROP TABLE [General].[DataList]
GO
/****** Object:  Table [General].[Area]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[Area]') AND type in (N'U'))
DROP TABLE [General].[Area]
GO
/****** Object:  UserDefinedFunction [General].[ufn_GetDate]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[ufn_GetDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [General].[ufn_GetDate]
GO
/****** Object:  UserDefinedFunction [General].[GetFullName]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[General].[GetFullName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [General].[GetFullName]
GO
/****** Object:  Schema [Security]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Security')
DROP SCHEMA [Security]
GO
/****** Object:  Schema [General]    Script Date: 5/05/2020 4:24:35 p. m. ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'General')
DROP SCHEMA [General]
GO
/****** Object:  Schema [General]    Script Date: 5/05/2020 4:24:35 p. m. ******/
CREATE SCHEMA [General]
GO
/****** Object:  Schema [Security]    Script Date: 5/05/2020 4:24:35 p. m. ******/
CREATE SCHEMA [Security]
GO
/****** Object:  UserDefinedFunction [General].[GetFullName]    Script Date: 5/05/2020 4:24:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  FUNCTION [General].[GetFullName](
@fName VARCHAR(50), 
@sName VARCHAR(50),
@fSurname VARCHAR(50),
@sSurname VARCHAR(50)

)
  
RETURNS VARCHAR(200) AS  
BEGIN 
DECLARE @fullName VARCHAR(200)
SELECT @fullName =	LTRIM(RTRIM(LTRIM(@fName)) + 
					RTRIM(' '+ LTRIM(ISNULL(@sName,''))) + 
					RTRIM(' '+ LTRIM(@fSurname))) +
					RTRIM(' '+ LTRIM(ISNULL(@sSurname,'')))
RETURN @fullName
END
GO
/****** Object:  UserDefinedFunction [General].[ufn_GetDate]    Script Date: 5/05/2020 4:24:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [General].[ufn_GetDate] ()
RETURNS SMALLDATETIME
BEGIN
    RETURN GETDATE()
END
GO
/****** Object:  Table [General].[Area]    Script Date: 5/05/2020 4:24:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [General].[Area](
	[IDArea] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[IDArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [General].[DataList]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [General].[DataList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDDataListType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_DataList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [General].[DataListType]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [General].[DataListType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_DataListType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [General].[Employee]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [General].[Employee](
	[IDEmployee] [int] IDENTITY(1,1) NOT NULL,
	[IDDocumentType] [int] NOT NULL,
	[DocumentNumber] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[SecondName] [varchar](50) NULL,
	[Surname] [varchar](50) NOT NULL,
	[SecondSurname] [varchar](50) NULL,
	[IDSubArea] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[URLImage] [varchar](255) NULL,
	[IDUserCreation] [int] NOT NULL,
	[DateCreation] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[IDEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Employee_DocumentNumber] UNIQUE NONCLUSTERED 
(
	[DocumentNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [General].[SubArea]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [General].[SubArea](
	[IDSubArea] [int] IDENTITY(1,1) NOT NULL,
	[IDArea] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_SubArea] PRIMARY KEY CLUSTERED 
(
	[IDSubArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Security].[Role]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Security].[Role](
	[IDRole] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[IDRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Security].[User]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Security].[User](
	[IDUser] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[IDEmployee] [int] NOT NULL,
	[Password] [varchar](256) NOT NULL,
	[KeyPassword] [varchar](256) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IDUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_User_IDEmployee] UNIQUE NONCLUSTERED 
(
	[IDEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Security].[UserRole]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Security].[UserRole](
	[IDUser] [int] NOT NULL,
	[IDRole] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [General].[VW_DataList]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [General].[VW_DataList]
as
SELECT	LIS.[ID], 
		LIS.[Name], 
		LIS.[Code], 
		LIS.[IDDataListType],
		TPL.[NAME] AS NameDataListType,
		LIS.[Active]
FROM [General].[DataListType] TPL 
	INNER JOIN [General].[DataList] LIS ON TPL.[ID] =  LIS.[IDDataListType]
GO
/****** Object:  View [General].[VW_Employee]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [General].[VW_Employee]
AS
SELECT	
	EMP.[IDEmployee],
	EMP.[IDDocumentType],
	TDC.[Name] As NameDocumentType,
	TDC.[Code] As CodeDocumentType,
	EMP.[DocumentNumber], 
	General.GetFullName(EMP.[Name], EMP.[SecondName],  EMP.[Surname], EMP.[SecondSurname]) AS FullName,
	EMP.[Name], 
	EMP.[SecondName], 
	EMP.[Surname], 
	EMP.[SecondSurname], 
	EMP.[IDSubArea], 
	SAR.[Name] As NameSubArea,
	ARE.[IDArea],
	ARE.[Name] As NameArea,
	EMP.[Active], 
	EMP.[URLImage],
	EMP.[IDUserCreation],
	USU.[UserName] As UserNameCreation,
	EMP.[DateCreation]
FROM [General].[Employee] EMP
		INNER JOIN [Security].[User] USU ON EMP.IDUserCreation = USU.IDUser
		INNER JOIN [General].[VW_DataList] TDC ON EMP.IDDocumentType = TDC.ID
		INNER JOIN [General].[SubArea] SAR ON EMP.IDSubArea = SAR.IDSubArea
		INNER JOIN [General].[Area] ARE ON SAR.IDArea = ARE.IDArea

GO
/****** Object:  View [General].[VW_SubArea]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [General].[VW_SubArea]
AS
SELECT	[ARE].[IDArea],
		[ARE].[Name] AS NameArea,
		[SAR].[IDSubArea],
		[SAR].[Name] AS NameSubArea,
		[SAR].[Description]
FROM [General].[Area] ARE
		INNER JOIN  [General].[SubArea] SAR ON [ARE].[IDArea] = [SAR].[IDArea]

GO
ALTER TABLE [General].[DataList]  WITH CHECK ADD  CONSTRAINT [FK_DataList_DataListType] FOREIGN KEY([IDDataListType])
REFERENCES [General].[DataListType] ([ID])
GO
ALTER TABLE [General].[DataList] CHECK CONSTRAINT [FK_DataList_DataListType]
GO
ALTER TABLE [General].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_DataList_IDDocumentType] FOREIGN KEY([IDDocumentType])
REFERENCES [General].[DataList] ([ID])
GO
ALTER TABLE [General].[Employee] CHECK CONSTRAINT [FK_Employee_DataList_IDDocumentType]
GO
ALTER TABLE [General].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_SubArea_ID] FOREIGN KEY([IDSubArea])
REFERENCES [General].[SubArea] ([IDSubArea])
GO
ALTER TABLE [General].[Employee] CHECK CONSTRAINT [FK_Employee_SubArea_ID]
GO
ALTER TABLE [General].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_User_IDUserCreation] FOREIGN KEY([IDUserCreation])
REFERENCES [Security].[User] ([IDUser])
GO
ALTER TABLE [General].[Employee] CHECK CONSTRAINT [FK_Employee_User_IDUserCreation]
GO
ALTER TABLE [General].[SubArea]  WITH CHECK ADD  CONSTRAINT [FK_SubArea_Area_ID] FOREIGN KEY([IDArea])
REFERENCES [General].[Area] ([IDArea])
GO
ALTER TABLE [General].[SubArea] CHECK CONSTRAINT [FK_SubArea_Area_ID]
GO
ALTER TABLE [Security].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Employee_ID] FOREIGN KEY([IDEmployee])
REFERENCES [General].[Employee] ([IDEmployee])
GO
ALTER TABLE [Security].[User] CHECK CONSTRAINT [FK_User_Employee_ID]
GO
ALTER TABLE [Security].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role_ID] FOREIGN KEY([IDRole])
REFERENCES [Security].[Role] ([IDRole])
GO
ALTER TABLE [Security].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role_ID]
GO
ALTER TABLE [Security].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User_ID] FOREIGN KEY([IDUser])
REFERENCES [Security].[User] ([IDUser])
GO
ALTER TABLE [Security].[UserRole] CHECK CONSTRAINT [FK_UserRole_User_ID]
GO
/****** Object:  StoredProcedure [General].[AreaGet]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento: [General].[AreaGet]
-- Descripción: Se encarga de obtener los registros de Areas por el ID
-- Desarrolló: Nelson Jaramillo
-- Fecha: 29/04/2020
-- 
-- Modificaciones: 
-- 
-- Ejemplo: 
-- 
--  EXEC [General].[AreaGet] 1
--  EXEC [General].[AreaGet] -1

CREATE PROCEDURE [General].[AreaGet]
( 
	@pIDArea INT
)
 -- WITH ENCRYPTION
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  
SET NOCOUNT ON

	SELECT	[ARE].[IDArea],
			[ARE].[Name]
	FROM [General].[Area] ARE
	WHERE	[ARE].[IDArea] =  (CASE WHEN @pIDArea > 0 THEN @pIDArea ELSE [ARE].[IDArea] END) 

SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [General].[DataListByTypeGet]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento: [General].[DataListByTypeGet]
-- Descripción: Se encarga de obtener los registros de listas por el tipo de lista
-- Desarrolló: Nelson Jaramillo
-- Fecha: 27/04/2020
-- 
-- Modificaciones: 
-- 
-- Ejemplo: 
-- 
--  EXEC [General].[DataListByTypeGet] 'TIPODOCUMENTO'
CREATE PROCEDURE [General].[DataListByTypeGet]
( 
	@pNameDateListType VARCHAR(50)
)
 -- WITH ENCRYPTION
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  
SET NOCOUNT ON
SELECT	[ID], 
		[Name], 
		[Code], 
		[IDDataListType], 
		[NameDataListType], 
		[Active]
FROM [General].[VW_DataList] LIS
WHERE	LIS.[NameDataListType] =  @pNameDateListType AND
		LIS.[Active] = 1 

 SET NOCOUNT OFF
 END
GO
/****** Object:  StoredProcedure [General].[EmployeeAutocomplete]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento: [General].[EmployeeAutocomplete]
-- Descripción: Se encarga de obtener un empleado por su nombre o número de documento
-- Desarrolló: Nelson Jaramillo
-- Fecha: 29/04/2020
-- 
-- Ejemplo: 
-- 
--  EXEC [General].[EmployeeAutocomplete] 'ana', '123001'
--  EXEC [General].[EmployeeAutocomplete] 'ana', ''
--  EXEC [General].[EmployeeAutocomplete] '', '123'
--
CREATE PROCEDURE [General].[EmployeeAutocomplete]
( 
	@pName VARCHAR(200),
	@pNit VARCHAR(50)
)
 -- WITH ENCRYPTION
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  


	SELECT	 [IDEmployee]
			,[IDDocumentType]
			,[NameDocumentType]
			,[CodeDocumentType]
			,[DocumentNumber]
			,[Name]
			,[SecondName]
			,[Surname]
			,[SecondSurname]
			,[IDSubArea]
			,[NameSubArea]
			,[IDArea]
			,[NameArea]
			,[Active]
			,[URLImage]
			,[IDUserCreation]
			,[UserNameCreation]
			,[DateCreation]
	FROM [General].[VW_Employee]
	WHERE	[FullName] like '%' + (CASE WHEN LEN(@pName) > 0 THEN @pName ELSE [FullName] END)   +'%' AND
			[DocumentNumber] like '%' + (CASE WHEN LEN(@pNit) > 0 THEN @pNit ELSE [DocumentNumber] END)   +'%' 

END
GO
/****** Object:  StoredProcedure [General].[EmployeeByIDGet]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento: [General].[EmployeeByIDGet]
-- Descripción: Se encarga de obtener los registros de un empleado por su numerop de ID
-- Desarrolló: Nelson Jaramillo
-- Fecha: 27/04/2020
-- 
-- Ejemplo: 
-- 
--  EXEC [General].[EmployeeByIDGet] 2
CREATE PROCEDURE [General].[EmployeeByIDGet]
( 
	@pIDEmployee INT
)
 -- WITH ENCRYPTION
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  
SET NOCOUNT ON
	
	SELECT	EMP.[IDEmployee], 
			EMP.[IDDocumentType],
			TDC.[Name] As NameDocumentType,
			TDC.[Code] As CodeDocumentType,
			EMP.[DocumentNumber], 
			EMP.[Name], 
			EMP.[SecondName], 
			EMP.[Surname], 
			EMP.[SecondSurname], 
			EMP.[IDSubArea], 
			SAR.[Name] As NameSubArea,
			ARE.[IDArea],
			ARE.[Name] As NameArea,
			EMP.[Active], 
			EMP.[URLImage],
			EMP.[IDUserCreation],
			USU.[UserName] As UserNameCreation,
			EMP.[DateCreation]
	FROM [General].[Employee] EMP
		INNER JOIN [Security].[User] USU ON EMP.IDUserCreation = USU.IDUser
		INNER JOIN [General].[VW_DataList] TDC ON EMP.IDDocumentType = TDC.ID
		INNER JOIN [General].[SubArea] SAR ON EMP.IDSubArea = SAR.IDSubArea
		INNER JOIN [General].[Area] ARE ON SAR.IDArea = ARE.IDArea
	WHERE EMP.IDEmployee = @pIDEmployee
SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [General].[EmployeeCreate]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento: [General].[EmployeeCreate]
-- Descripción: Se encarga de registrar un empleado
-- Desarrolló: Nelson Jaramillo
-- Fecha: 27/04/2020
-- 
-- Modificaciones: 
-- 
-- Ejemplo: 
-- 
--  EXEC [General].[EmployeeCreate] 1, '000', 'Nelson', NULL, 'Jaramillo', NULL, 1, 1, NULL, 1
CREATE PROCEDURE [General].[EmployeeCreate]
( 
	@pIDDocumentType INT, 
	@pDocumentNumber VARCHAR(50), 
	@pName VARCHAR(50), 
	@pSecondName VARCHAR(50), 
	@pSurname VARCHAR(50), 
	@pSecondSurname VARCHAR(50), 
	@pIDSubArea INT, 
	@pURLImage VARCHAR(255), 
	@pIDUserCreation INT
)
 -- WITH ENCRYPTION
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  
SET NOCOUNT ON

	DECLARE @IDEmployee INT;

	INSERT INTO [General].[Employee] (IDDocumentType, DocumentNumber, Name, SecondName, Surname, SecondSurname, IDSubArea, Active, URLImage, IDUserCreation, DateCreation)
	VALUES (@pIDDocumentType, @pDocumentNumber, @pName, @pSecondName, @pSurname, @pSecondSurname, @pIDSubArea, 1, @pURLImage, 1, [General].[ufn_GetDate]())
	SET @IDEmployee = @@IDENTITY	
	
	SELECT @IDEmployee
 SET NOCOUNT OFF
 END
GO
/****** Object:  StoredProcedure [General].[EmployeeDelete]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento: [General].[EmployeeUpdate]
-- Descripción: Se encarga de INACTIVAR un empleado
-- Desarrolló: Nelson Jaramillo
-- Fecha: 27/04/2020
-- 
-- Modificaciones: 
-- 
-- Ejemplo: 
-- 
--  EXEC [General].[EmployeeDelete]  2
CREATE PROCEDURE [General].[EmployeeDelete]
( 
	@pIDEmployee INT
)
 -- WITH ENCRYPTION
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  
SET NOCOUNT ON
	
	UPDATE [General].[Employee]
		SET [Active] = 0
	WHERE IDEmployee = @pIDEmployee

	RETURN 1
SET NOCOUNT OFF
END











GO
/****** Object:  StoredProcedure [General].[EmployeeGetAll]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento: [General].[EmployeeGetAll]
-- Descripción: Se encarga de obtener todos los empleados
-- Desarrolló: Nelson Jaramillo
-- Fecha: 30/04/2020
-- 
-- Ejemplo: 
-- 
--  EXEC [General].[EmployeeGetAll]
--
CREATE PROCEDURE [General].[EmployeeGetAll]
 -- WITH ENCRYPTION
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  


	SELECT	 [IDEmployee]
			,[IDDocumentType]
			,[NameDocumentType]
			,[CodeDocumentType]
			,[DocumentNumber]
			,[Name]
			,[SecondName]
			,[Surname]
			,[SecondSurname]
			,[IDSubArea]
			,[NameSubArea]
			,[IDArea]
			,[NameArea]
			,[Active]
			,[URLImage]
			,[IDUserCreation]
			,[UserNameCreation]
			,[DateCreation]
	FROM [General].[VW_Employee]
	WHERE	[Active] = 1

END
GO
/****** Object:  StoredProcedure [General].[EmployeeGetByFilter]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento: General].[EmployeeGetByFilter] 
-- Descripción: Se encarga de obtener un usuario por su nombre de usuario  
-- Desarrolló: Nelson Jaramillo  
-- Fecha: 29/04/2020  
--  EXEC [General].[EmployeeGet] 0, 10  
 CREATE PROCEDURE [General].[EmployeeGetByFilter]  (    @pPagina INT,   @pCantReg INT  )   
-- WITH ENCRYPTION  
AS  
BEGIN 
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED        


SELECT @pCantReg = COUNT(*) FROM [General].[Employee]
DECLARE @skipReg INT = @pPagina * @pCantReg     

	SELECT	EMP.[IDEmployee],      
			EMP.[IDDocumentType],     
			EMP.[NameDocumentType],     
			EMP.[CodeDocumentType],     
			EMP.[DocumentNumber],      
			EMP.[FullName],
			EMP.[Name],      
			EMP.[SecondName],      
			EMP.[Surname],      
			EMP.[SecondSurname],      
			EMP.[IDSubArea],      
			EMP.[NameSubArea] ,     
			EMP.[IDArea],     
			EMP.[NameArea] ,     
			EMP.[Active],      
			EMP.[URLImage],     
			EMP.[IDUserCreation],     
			EMP.[UserNameCreation],     
			EMP.[DateCreation]   
	FROM [General].[VW_Employee] EMP     
	ORDER BY EMP.[IDEmployee]   OFFSET @skipReg ROWS   
	FETCH NEXT @pCantReg ROWS ONLY     -- Consulto la cantida de registros nuevos   
  
	SELECT @pCantReg [CantTotal]  
END   
GO
/****** Object:  StoredProcedure [General].[EmployeeUpdate]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento: [General].[EmployeeUpdate]
-- Descripción: Se encarga de ACTUALIZAR un empleado
-- Desarrolló: Nelson Jaramillo
-- Fecha: 27/04/2020
-- 
-- Modificaciones: 
-- 
-- Ejemplo: 
-- 
--  EXEC [General].[EmployeeUpdate]  2, 1, '000', 'Nelson', NULL, 'Jara', NULL, 1, 1, NULL
CREATE PROCEDURE [General].[EmployeeUpdate]
( 
	@pIDEmployee INT,
	@pIDDocumentType INT, 
	@pDocumentNumber VARCHAR(50), 
	@pName VARCHAR(50), 
	@pSecondName VARCHAR(50), 
	@pSurname VARCHAR(50), 
	@pSecondSurname VARCHAR(50), 
	@pIDSubArea INT, 
	@pActive BIT, 
	@pURLImage VARCHAR(255)
)
 -- WITH ENCRYPTION
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  
SET NOCOUNT ON
	
	UPDATE [General].[Employee]
		SET [IDDocumentType] = @pIDDocumentType, 
			[DocumentNumber] = @pDocumentNumber, 
			[Name] = @pName, 
			[SecondName] = @pSecondName, 
			[Surname] = @pSurname, 
			[SecondSurname] = @pSecondSurname, 
			[IDSubArea] = @pIDSubArea, 
			[Active] = @pActive, 
			[URLImage] = @pURLImage	
	WHERE IDEmployee = @pIDEmployee

	SELECT @pIDEmployee
SET NOCOUNT OFF
END











GO
/****** Object:  StoredProcedure [General].[SubAreaByIDAreaGet]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento: [General].[SubAreaByIDAreaGet]
-- Descripción: Se encarga de obtener los registros de Areas y SubAreas por el ID del área
-- Desarrolló: Nelson Jaramillo
-- Fecha: 29/04/2020
-- 
-- Modificaciones: 
-- 
-- Ejemplo: 
-- 
--  EXEC [General].[SubAreaByIDAreaGet] 1
--  EXEC [General].[SubAreaByIDAreaGet] -1

CREATE PROCEDURE [General].[SubAreaByIDAreaGet]
( 
	@pIDArea INT
)
 -- WITH ENCRYPTION
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  
SET NOCOUNT ON

	SELECT	[SAR].[IDArea],
			[SAR].[NameArea],
			[SAR].[IDSubArea],
			[SAR].[NameSubArea],
			[SAR].[Description]
	FROM [General].[VW_SubArea] SAR
	WHERE	[SAR].[IDArea] =  (CASE WHEN @pIDArea > 0 THEN @pIDArea ELSE [SAR].[IDArea] END) 

SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [Security].[UserByUserNameGet]    Script Date: 5/05/2020 4:24:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento: [Security].[UserByUserNameGet]
-- Descripción: Se encarga de obtener un usuario por su nombre de usuario
-- Desarrolló: Nelson Jaramillo
-- Fecha: 27/04/2020
-- 
-- Ejemplo: 
-- 
--  EXEC [Security].[UserByUserNameGet] 'admin'
--
CREATE PROCEDURE [Security].[UserByUserNameGet]
( 
	@pUserName VARCHAR(100)
)
 -- WITH ENCRYPTION
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  
SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT	
		USU.[IDUser], 
		USU.[IDEmployee],
		USU.[Active],
		ROL.[IDRole], 
		ROL.[NameRole] 
FROM [Security].[User] USU 
		INNER JOIN [Security].[UserRole] UXR ON USU.IDUser = UXR.IDUser
		INNER JOIN [Security].[Role] ROL ON UXR.IDRole = ROL.IDRole
WHERE	USU.[UserName]= @pUserName
		AND USU.Active = 1 -- Solo traigo usuario Activos


SET NOCOUNT OFF
END
GO
