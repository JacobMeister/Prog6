CREATE TABLE [dbo].Tamagotchi
(
	[ID] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL , 
    [Age] INT NOT NULL, 
    [Hunger] INT NOT NULL, 
	[Sleep] INT NOT NULL, 
	[Boredom] INT NOT NULL, 
    [DateOfLastAcces] DATETIME NOT NULL
)
