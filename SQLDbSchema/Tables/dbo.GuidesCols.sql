CREATE TABLE [dbo].[GuidesCols] (
  [Id] [uniqueidentifier] NOT NULL,
  [Name] [nvarchar](64) NOT NULL,
  [DataType] [int] NOT NULL,
  [GuideRowId] [uniqueidentifier] NULL,
  CONSTRAINT [PK_GuidesCols] PRIMARY KEY CLUSTERED ([Id])
)
ON [PRIMARY]
GO

CREATE INDEX [IX_GuidesCols_GuideRowId]
  ON [dbo].[GuidesCols] ([GuideRowId])
  ON [PRIMARY]
GO

ALTER TABLE [dbo].[GuidesCols]
  ADD CONSTRAINT [FK_GuidesCols_GuidesRows_GuideRowId] FOREIGN KEY ([GuideRowId]) REFERENCES [dbo].[GuidesRows] ([Id])
GO