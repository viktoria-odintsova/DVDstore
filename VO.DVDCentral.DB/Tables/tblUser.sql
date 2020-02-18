CREATE TABLE [dbo].[tblUser]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [UserId] VARCHAR(20) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL
)
