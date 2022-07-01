CREATE TABLE [dbo].[Guides] (
  [Id] [uniqueidentifier] NOT NULL,
  [Name] [nvarchar](128) NOT NULL,
  [GuideListId] [uniqueidentifier] NOT NULL,
  CONSTRAINT [PK_Guides] PRIMARY KEY CLUSTERED ([Id])
)
ON [PRIMARY]
GO

CREATE INDEX [IX_Guides_GuideListId]
  ON [dbo].[Guides] ([GuideListId])
  ON [PRIMARY]
GO

ALTER TABLE [dbo].[Guides]
  ADD CONSTRAINT [FK_Guides_GuidesLists_GuideListId] FOREIGN KEY ([GuideListId]) REFERENCES [dbo].[GuidesLists] ([Id]) ON DELETE CASCADE
GO