BEGIN
	INSERT INTO dbo.tblCustomer (Id, FirstName, LastName, Address, City, State, ZIP, Phone, UserId)
	VALUES
	(1, 'Maria', 'Depp', '123 Main St', 'Menasha', 'WI', '54901', '9202405683', 2),
	(2, 'Ivan', 'Ivanov', '43 Eagle Ave', 'Seattle', 'WA', '98107', '4605837512', 3),
	(3, 'George', 'Smith', '1150 5th Ave', 'New York City', 'NY', '10036', '3804721122', 1)
END