CREATE TABLE [dbo].[Notes] (
  [Id] [uniqueidentifier] NOT NULL,
  [Title] [nvarchar](max) NOT NULL,
  [Text] [nvarchar](max) NOT NULL,
  [UserId] [nvarchar](450) NOT NULL,
  CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED ([Id])
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO

CREATE INDEX [IX_Notes_UserId]
  ON [dbo].[Notes] ([UserId])
  ON [PRIMARY]
GO

ALTER TABLE [dbo].[Notes]
  ADD CONSTRAINT [FK_Notes_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO