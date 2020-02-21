BEGIN
	INSERT INTO dbo.tblOrder (Id, CustomerId, OrderDate, UserId, ShipDate)
	VALUES
	(1, 3, '2019-12-06', 1, '2019-12-08'),
	(2, 1, '2020-01-15', 2, '2020-01-16'),
	(3, 3, '2020-02-11', 3, '2020-02-12')
END