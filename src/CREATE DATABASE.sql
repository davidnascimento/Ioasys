CREATE DATABASE Ioasys
GO

USE Ioasys
GO

CREATE TABLE [dbo].[Ett_EnterpriseType](
	[Ett_EnterpriseType_Id] [int] IDENTITY(1,1) NOT NULL,
	[Ett_Name] [nvarchar](200) NULL,
 CONSTRAINT [PK_Ett_EnterpriseType] PRIMARY KEY CLUSTERED 
(
	[Ett_EnterpriseType_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

---------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[Ent_Enterprise](
	[Ent_Enterprise_Id] [int] IDENTITY(1,1) NOT NULL,
	[Ent_Email] [nvarchar](200) NULL,
	[Ent_Facebook] [nvarchar](200) NULL,
	[Ent_Twitter] [nvarchar](200) NULL,
	[Ent_Linkedin] [nvarchar](200) NULL,
	[Ent_Phone] [nvarchar](200) NULL,
	[Ent_Own] [bit] NOT NULL,
	[Ent_Name] [nvarchar](200) NULL,
	[Ent_Photo] [nvarchar](200) NULL,
	[Ent_Description] [nvarchar](max) NULL,
	[Ent_City] [nvarchar](200) NULL,
	[Ent_Country] [nvarchar](200) NULL,
	[Ent_Value] [int] NOT NULL,
	[Ent_SharePrice] [real] NOT NULL,
	[Ett_EnterpriseType_Id] [int] NOT NULL,
 CONSTRAINT [PK_Ent_Enterprise] PRIMARY KEY CLUSTERED 
(
	[Ent_Enterprise_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Ent_Enterprise]  WITH CHECK ADD  CONSTRAINT [FK_Ent_Enterprise_Ett_EnterpriseType_Ett_EnterpriseType_Id] FOREIGN KEY([Ett_EnterpriseType_Id])
REFERENCES [dbo].[Ett_EnterpriseType] ([Ett_EnterpriseType_Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Ent_Enterprise] CHECK CONSTRAINT [FK_Ent_Enterprise_Ett_EnterpriseType_Ett_EnterpriseType_Id]
GO

---------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[Inv_Investor](
	[Inv_Investor_Id] [int] IDENTITY(1,1) NOT NULL,
	[Inv_Name] [nvarchar](200) NULL,
	[Inv_Email] [nvarchar](200) NULL,
	[Ent_City] [nvarchar](200) NULL,
	[Ent_Country] [nvarchar](200) NULL,
	[Inv_Balance] [real] NOT NULL,
	[Inv_Photo] [nvarchar](200) NULL,
	[Inv_PortfolioValue] [real] NOT NULL,
	[Inv_FirstAccess] [bit] NOT NULL,
	[Inv_SuperAngel] [bit] NOT NULL,
 CONSTRAINT [PK_Inv_Investor] PRIMARY KEY CLUSTERED 
(
	[Inv_Investor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

---------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[Usr_User](
	[Usr_User_Id] [int] IDENTITY(1,1) NOT NULL,
	[Usr_Email] [nvarchar](150) NULL,
	[Usr_Password] [nvarchar](150) NULL,
	[Ent_Enterprise_Id] [int] NULL,
	[Inv_Investor_Id] [int] NULL,
 CONSTRAINT [PK_Usr_User] PRIMARY KEY CLUSTERED 
(
	[Usr_User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usr_User]  WITH CHECK ADD  CONSTRAINT [FK_Usr_User_Ent_Enterprise_Ent_Enterprise_Id] FOREIGN KEY([Ent_Enterprise_Id])
REFERENCES [dbo].[Ent_Enterprise] ([Ent_Enterprise_Id])
GO

ALTER TABLE [dbo].[Usr_User] CHECK CONSTRAINT [FK_Usr_User_Ent_Enterprise_Ent_Enterprise_Id]
GO

ALTER TABLE [dbo].[Usr_User]  WITH CHECK ADD  CONSTRAINT [FK_Usr_User_Inv_Investor_Inv_Investor_Id] FOREIGN KEY([Inv_Investor_Id])
REFERENCES [dbo].[Inv_Investor] ([Inv_Investor_Id])
GO

ALTER TABLE [dbo].[Usr_User] CHECK CONSTRAINT [FK_Usr_User_Inv_Investor_Inv_Investor_Id]
GO

---------------------------------------------------------------------------------------------------------------------------------------

DECLARE @Ett_Id INT,
		@Inv_Id INT;

INSERT INTO [dbo].[Ett_EnterpriseType]
           ([Ett_Name])
     VALUES
           ('Tipo Teste')

SELECT @Ett_Id = SCOPE_IDENTITY();

INSERT INTO [dbo].[Ent_Enterprise]
           ([Ent_Email]
           ,[Ent_Facebook]
           ,[Ent_Twitter]
           ,[Ent_Linkedin]
           ,[Ent_Phone]
           ,[Ent_Own]
           ,[Ent_Name]
           ,[Ent_Photo]
           ,[Ent_Description]
           ,[Ent_City]
           ,[Ent_Country]
           ,[Ent_Value]
           ,[Ent_SharePrice]
           ,[Ett_EnterpriseType_Id])
     VALUES
           ('teste@teste.com'
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,0
           ,'Nome teste'
           ,NULL
           ,'Descricao'
           ,'Sao Paulo'
           ,'Brasil'
           ,0
           ,5000
           ,@Ett_Id)

INSERT INTO [dbo].[Inv_Investor]
           ([Inv_Name]
           ,[Inv_Email]
           ,[Ent_City]
           ,[Ent_Country]
           ,[Inv_Balance]
           ,[Inv_Photo]
           ,[Inv_PortfolioValue]
           ,[Inv_FirstAccess]
           ,[Inv_SuperAngel])
     VALUES
           ('Teste'
           ,'Teste@teste.com'
           ,'Rio de Janeiro'
           ,'Brasil'
           ,4000
           ,NULL
           ,0
           ,0
           ,0)

SELECT @Inv_Id = SCOPE_IDENTITY();

INSERT INTO Usr_User VALUES ('testeapple@ioasys.com.br', 'ED2B1F468C5F915F3F1CF75D7068BAAE', NULL, @Inv_Id)

GO