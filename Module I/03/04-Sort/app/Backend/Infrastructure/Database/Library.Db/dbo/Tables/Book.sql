CREATE TABLE [dbo].[Book] (
    [BookId]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [AuthorId]    UNIQUEIDENTIFIER NOT NULL,
    [Title]       NVARCHAR (100)   NOT NULL,
    [Description] NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([BookId] ASC),
    CONSTRAINT [FK_Book_Author] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Author] ([AuthorId]) ON DELETE CASCADE
);

