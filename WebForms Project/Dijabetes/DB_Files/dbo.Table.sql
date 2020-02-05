CREATE TABLE [dbo].[Table] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [Email]    VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    [Age] INT NULL, 
    [Height] INT NULL, 
    [Weight] INT NULL, 
    [DiabetesType] NVARCHAR(50) NULL, 
    [Gender] NVARCHAR(50) NULL, 
    [Activity] NVARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([Email] ASC)
);

