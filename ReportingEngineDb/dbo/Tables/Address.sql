CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT NULL, 
    [Address] NVARCHAR(200) NULL, 
    [ZipCode] VARCHAR(50) NULL, 
    [State] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Address_ToCustomers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id])
)
