CREATE TABLE [dbo].[Orders] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50)    NOT NULL,
    [PlacesAmount] INT              NOT NULL,
    [TotalPrice]   DECIMAL (18)     NOT NULL,
    [State]        NVARCHAR (50)    NOT NULL,
    [Filepath]     NVARCHAR (MAX)   NOT NULL,
    [UserId]       INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Orders_ToLoginPasswords] FOREIGN KEY ([UserId]) REFERENCES [dbo].[LoginPasswords] ([Id])
);

