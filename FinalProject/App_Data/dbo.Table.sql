CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [userName] VARCHAR(20) NULL, 
    [userPassword] VARCHAR(20) NOT NULL, 
    [timeCreated] DATETIME2 NOT NULL
)
