CREATE TABLE [dbo].[Threads]
(
	[threadID] INT NOT NULL PRIMARY KEY, 
    [threadSubject] VARCHAR(30) NOT NULL, 
    [timeCreated] DATETIME2 NOT NULL, 
    [userID] INT NOT NULL,
	--CONSTRAINT ([userID]) [FK_threadsUserID] FOREIGN KEY REFERENCES [dbo].[Users](userID)
)
