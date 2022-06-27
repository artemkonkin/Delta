CREATE TABLE [dbo].[GuidesLists] (
  [Id] [uniqueidentifier] NOT NULL,
  [Name] [nvarchar](128) NOT NULL,
  CONSTRAINT [PK_GuidesLists] PRIMARY KEY CLUSTERED ([Id])
)
ON [PRIMARY]
GO