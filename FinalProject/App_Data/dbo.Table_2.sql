CREATE TABLE [dbo].[Posts]
(
	[postID] INT NOT NULL PRIMARY KEY, 
    [postContent] VARCHAR(300) NOT NULL, 
    [timeCreated] DATETIME2 NOT NULL, 
    [threadID] INT NOT NULL, 
    [userID] INT NOT NULL,
	CONSTRAINT [FK_postsUserID] FOREIGN KEY ([userID]) REFERENCES [dbo].[Users]([userID]),
	CONSTRAINT [FK_postsThreadID] FOREIGN KEY ([threadID]) REFERENCES [dbo].[Threads]([threadID])
)
