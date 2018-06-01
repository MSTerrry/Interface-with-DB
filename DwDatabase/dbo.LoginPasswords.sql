CREATE TABLE [dbo].[LoginPasswords] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [Login]    NCHAR (10) NOT NULL,
    [Password] NCHAR (10) NOT NULL,
    [Type]     NCHAR (10) DEFAULT user NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);