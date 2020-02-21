BEGIN
	INSERT INTO dbo.tblOrderItem (Id, OrderId, MovieId, Quantity,  Cost)
	VALUES
	(1, 2, 2, 2, 32.98),
	(2, 3, 1, 1, 14.99),
	(3, 3, 3, 1, 11.99)
END