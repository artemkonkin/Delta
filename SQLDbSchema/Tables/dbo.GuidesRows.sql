CREATE TABLE [dbo].[GuidesRows] (
  [Id] [uniqueidentifier] NOT NULL,
  [GuideId] [uniqueidentifier] NOT NULL,
  [GuideRowId] [uniqueidentifier] NOT NULL,
  CONSTRAINT [PK_GuidesRows] PRIMARY KEY CLUSTERED ([Id])
)
ON [PRIMARY]
GO

CREATE INDEX [IX_GuidesRows_GuideRowId]
  ON [dbo].[GuidesRows] ([GuideRowId])
  ON [PRIMARY]
GO

ALTER TABLE [dbo].[GuidesRows]
  ADD CONSTRAINT [FK_GuidesRows_Guides_GuideRowId] FOREIGN KEY ([GuideRowId]) REFERENCES [dbo].[Guides] ([Id]) ON DELETE CASCADE
GO