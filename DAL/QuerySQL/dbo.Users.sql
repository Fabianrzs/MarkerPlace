CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserName] VARCHAR(20) NOT NULL, 
    [Password] VARCHAR(15) NOT NULL, 
    [Role] INT NOT NULL, 
    [State] INT NOT NULL
)
