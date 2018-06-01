CREATE TABLE [dbo].[LoginPasswords] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [Login]    NVARCHAR(50) NOT NULL,
    [Password] NVARCHAR(MAX) NOT NULL,
    [Type]     NCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

