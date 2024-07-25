CREATE TABLE [dbo].[Articles] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (80)  NOT NULL,
    [Content]  NVARCHAR (MAX) NOT NULL,
    [AuthorId] INT            NOT NULL,
	[PublicationDate] DATETIME2 DEFAULT GETDATE()
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Authors] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (30)  NOT NULL,
    [Password] NVARCHAR (128) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);

CREATE TABLE [dbo].[Comments] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Content]   NVARCHAR (MAX) NOT NULL,
    [AuthorId]  INT            NOT NULL,
    [ArticleId] INT            NOT NULL,
	PublicationDate DATETIME2 DEFAULT GETDATE()
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

