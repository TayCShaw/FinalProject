CREATE TABLE [dbo].[Threads] (
    [threadID]      INT           NOT NULL,
    [threadSubject] VARCHAR (30)  NOT NULL,
    [timeCreated]   DATETIME2 (7) NOT NULL,
    [userID]        INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([threadID] ASC),
    CONSTRAINT [FK_threadsUserID] FOREIGN KEY ([userID]) REFERENCES [dbo].[Users] ([userID])
);

