CREATE TABLE [dbo].[GuidesRowsColsData] (
  [Id] [uniqueidentifier] NOT NULL,
  [GuideRowId] [uniqueidentifier] NOT NULL,
  [GuideColId] [uniqueidentifier] NOT NULL,
  [Value] [sql_variant] NOT NULL,
  CONSTRAINT [PK_GuidesRowsColsData] PRIMARY KEY CLUSTERED ([Id])
)
ON [PRIMARY]
GO

CREATE INDEX [IX_GuidesRowsColsData_GuideColId]
  ON [dbo].[GuidesRowsColsData] ([GuideColId])
  ON [PRIMARY]
GO

CREATE INDEX [IX_GuidesRowsColsData_GuideRowId]
  ON [dbo].[GuidesRowsColsData] ([GuideRowId])
  ON [PRIMARY]
GO

ALTER TABLE [dbo].[GuidesRowsColsData]
  ADD CONSTRAINT [FK_GuidesRowsColsData_GuidesCols_GuideColId] FOREIGN KEY ([GuideColId]) REFERENCES [dbo].[GuidesCols] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[GuidesRowsColsData]
  ADD CONSTRAINT [FK_GuidesRowsColsData_GuidesRows_GuideRowId] FOREIGN KEY ([GuideRowId]) REFERENCES [dbo].[GuidesRows] ([Id]) ON DELETE CASCADE
GO