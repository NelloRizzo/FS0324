CREATE TABLE [dbo].Customers
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	LastName NVARCHAR(30) NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	City NVARCHAR(80) NOT NULL,
	Province CHAR(2) NOT NULL,
	FiscalCode CHAR(16) NOT NULL UNIQUE,
	Phone CHAR(15),
	Mobile CHAR(15),
	Email CHAR(128) NOT NULL
);
CREATE TABLE [dbo].Roles
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	RoleName NVARCHAR(20) NOT NULL UNIQUE
);
CREATE TABLE [dbo].[Rooms] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Number]      NVARCHAR (20)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [RoomType]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Number] ASC)
);
CREATE TABLE [dbo].[Users] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (20)  NOT NULL,
    [Email]    NVARCHAR (128) NOT NULL,
    [Password] NVARCHAR (128) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);
CREATE TABLE [dbo].Cities
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(80) NOT NULL,
	Capital BIT NULL DEFAULT 0,
	Cadastral CHAR(4) NOT NULL,
	ProvinceId INT NOT NULL
);
CREATE TABLE [dbo].Provinces
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(80) NOT NULL,
	Acronym CHAR(2) NOT NULL
);

CREATE TABLE [dbo].UsersRoles
(
	UserId INT NOT NULL,
	RoleId INT NOT NULL, 
    CONSTRAINT [PK_UsersRoles] PRIMARY KEY ([UserId], [RoleId])
)

