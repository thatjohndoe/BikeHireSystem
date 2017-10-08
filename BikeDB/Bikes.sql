CREATE TABLE [dbo].[Bikes]
(
	[Bike Id] INT NOT NULL PRIMARY KEY, 
    [Bike Model] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Cost] MONEY NOT NULL, 
    [Status] CHAR(10) NOT NULL
)
