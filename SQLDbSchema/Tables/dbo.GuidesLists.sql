CREATE TABLE [dbo].[GuidesLists] (
    [Id]   UNIQUEIDENTIFIER NOT NULL IDENTITY,
    [Name] NVARCHAR (128)   NOT NULL,
    CONSTRAINT [PK_GuidesLists] PRIMARY KEY CLUSTERED ([Id] ASC)
);

