CREATE DATABASE UserManagementDB

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[DateCreated] [datetime] NULL,
	[IsActive] [bit] NULL,
);