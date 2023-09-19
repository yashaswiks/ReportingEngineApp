CREATE PROCEDURE [dbo].[sp_InsertCustomerDetails]
	@FirstName VARCHAR(50), 
	@LastName VARCHAR(50),
	@DateOfBirth DATE,
	@Address VARCHAR(200),
	@ZipCode VARCHAR(50),
	@State VARCHAR(50)
AS
BEGIN
	INSERT INTO [dbo].[Customers] ([FirstName], [LastName], [DateOfBirth])
	VALUES (@FirstName, @LastName, @DateOfBirth)

	DECLARE @CustomerId INT = SCOPE_IDENTITY()

	INSERT INTO [dbo].[Address] ([CustomerId], [Address], [ZipCode], [State])
	VALUES (@CustomerId, @Address, @ZipCode, @State)

END