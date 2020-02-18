BEGIN
	INSERT INTO dbo.tblUser (Id, FirstName, LastName, UserId, Password)
	VALUES
	(1, 'John', 'Brown', 123456, 'password'),
	(2, 'Mike', 'Jordan', 654321, 'topsecret'),
	(3, 'Cayla', 'Gray', 246801, 'apple') 
END