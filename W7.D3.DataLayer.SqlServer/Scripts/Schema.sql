CREATE TABLE [dbo].[Users] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (20)  NOT NULL,
    [Password] NVARCHAR (128) NOT NULL,
	Birthday DATETIME2 ,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);
CREATE TABLE [dbo].Roles
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL UNIQUE
)
CREATE TABLE [dbo].UsersRoles
(
	UserId INT NOT NULL,
	RoleId INT NOT NULL, 
    CONSTRAINT [PK_UserRoles] 
		PRIMARY KEY ([UserId], [RoleId])
)
