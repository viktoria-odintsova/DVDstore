BEGIN
	INSERT INTO dbo.tblUser (Id, FirstName, LastName, UserId, Password)
	VALUES
	(1, 'John', 'Brown', 123456, 'password'),
	(2, 'Mike', 'Jordan', 654321, 'topsecret')
END