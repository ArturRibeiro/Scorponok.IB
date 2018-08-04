CREATE TABLE [dbo].[Church] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (100)   NOT NULL,
    [Photo]       NVARCHAR (100)   NULL,
    [Email]       NVARCHAR (MAX)   NULL,
    [PhoneMobile] NVARCHAR (MAX)   NULL,
    [PhoneFixed]  NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Church] PRIMARY KEY CLUSTERED ([Id] ASC)
);

