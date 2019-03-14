CREATE TABLE [dbo].[Users] (
    [userID]       INT           NOT NULL,
    [userName]     VARCHAR (20)  NOT NULL,
    [userPassword] VARCHAR (20)  NOT NULL,
    [timeCreated]  DATETIME2 (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([userID] ASC)
);

