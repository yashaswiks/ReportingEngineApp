/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- Insert sample data into the Customers table
DECLARE @CustomerRowCount INT = (SELECT COUNT(*) FROM [dbo].[Customers])
IF @CustomerRowCount = 0
BEGIN
-- Generate 1000 customers
	INSERT INTO [dbo].[Customers] ([FirstName], [LastName], [DateOfBirth])
	VALUES ('John', 'Doe', '1980-01-01')
		, ('John', 'Smith', '1980-01-01')
		, ('Jane', 'Smith', '1980-01-01')
		, ('John', 'Johnson', '1980-01-01')
		, ('Jane', 'Johnson', '1980-01-01')
		, ('John', 'Williams', '1980-01-01')
		, ('Jane', 'Williams', '1980-01-01')
		, ('John', 'Jones', '1980-01-01')
		, ('Jane', 'Jones', '1980-01-01')
		, ('John', 'Brown', '1980-01-01')
		, ('Jane', 'Brown', '1980-01-01')
		, ('John', 'Davis', '1980-01-01')
		, ('Jane', 'Davis', '1980-01-01')
		, ('John', 'Miller', '1980-01-01')
		, ('Jane', 'Miller', '1980-01-01')
		, ('John', 'Wilson', '1980-01-01')
		, ('Jane', 'Wilson', '1980-01-01')
		, ('John', 'Moore', '1980-01-01')
		, ('Jane', 'Moore', '1980-01-01')
		, ('John', 'Taylor', '1980-01-01')
		, ('Jane', 'Taylor', '1980-01-01')
		, ('John', 'Anderson', '1980-01-01')
		, ('Jane', 'Anderson', '1980-01-01')
		, ('John', 'Thomas', '1980-01-01')
		, ('Jane', 'Thomas', '1980-01-01')
		, ('John', 'Jackson', '1980-01-01')
		, ('Jane', 'Jackson', '1980-01-01')
		, ('John', 'White', '1980-01-01')
		, ('Jane', 'White', '1980-01-01')
		, ('John', 'Harris', '1980-01-01')
		, ('Jane', 'Harris', '1980-01-01')
		, ('John', 'Martin', '1980-01-01')

	INSERT INTO [dbo].[Address] ([CustomerId], [Address], [ZipCode], [State])
	VALUES (1, '123 Main St', '12345', 'CA')
		, (2, '123 Main St', '12345', 'CA')
		, (3, '123 Main St', '12345', 'CA')
		, (4, '123 Main St', '12345', 'CA')
		, (5, '123 Main St', '12345', 'CA')
		, (6, '123 Main St', '12345', 'CA')
		, (7, '123 Main St', '12345', 'CA')
		, (8, '123 Main St', '12345', 'CA')
		, (9, '123 Main St', '12345', 'CA')
		, (10, '123 Main St', '12345', 'CA')
		, (11, '123 Main St', '12345', 'CA')
		, (12, '123 Main St', '12345', 'CA')
		, (13, '123 Main St', '12345', 'CA')
		, (14, '123 Main St', '12345', 'CA')
		, (15, '123 Main St', '12345', 'CA')
		, (16, '123 Main St', '12345', 'CA')
		, (17, '123 Main St', '12345', 'CA')
		, (18, '123 Main St', '12345', 'CA')
		, (19, '123 Main St', '12345', 'CA')
		, (20, '123 Main St', '12345', 'CA')
		, (21, '123 Main St', '12345', 'CA')
		, (22, '123 Main St', '12345', 'CA')
		, (23, '123 Main St', '12345', 'CA')
		, (24, '123 Main St', '12345', 'CA')
		, (25, '123 Main St', '12345', 'CA')
		, (26, '123 Main St', '12345', 'CA')
END