USE [DB_MIS442];
GO

CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProductCode] [varchar](10) NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[ProductVersion] [decimal](5, 1) NOT NULL,
	[ProductReleaseDate] [date] NOT NULL)
