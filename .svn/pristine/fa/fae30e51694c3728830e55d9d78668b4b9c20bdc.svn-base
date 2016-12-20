CREATE TABLE CurrentLocationType (
	Id INTEGER PRIMARY KEY, 
	Name VARCHAR(25) Not NULL 
)
GO
ALTER TABLE dbo.Label ADD CurrentLocationId INTEGER NULL REFERENCES dbo.CurrentLocationType(Id)
GO
INSERT INTO dbo.CurrentLocationType(Id, Name) VALUES (1,'destroyed')
INSERT INTO dbo.CurrentLocationType(Id, Name) VALUES (2,'finished goods') 
INSERT INTO dbo.CurrentLocationType(Id, Name) VALUES (3,'shipped')
INSERT INTO dbo.[Status] (Id, Name, SortOrder) VALUES ('8','Shipped','7'); 