CREATE TABLE [dbo].[Author] (
    [AuthorId]    UNIQUEIDENTIFIER   DEFAULT (newid()) NOT NULL,
    [FirstName]   VARCHAR (50)       NOT NULL,
    [LastName]    VARCHAR (50)       NOT NULL,
    [DateOfBirth] DATETIMEOFFSET (7) NOT NULL,
    [DateOfDeath] DATETIMEOFFSET (7) NULL,
    [Genre]       VARCHAR (50)       NOT NULL,
    [Sex]         VARCHAR (50)       NOT NULL,
    CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED ([AuthorId] ASC)
);

