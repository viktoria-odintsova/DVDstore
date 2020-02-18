BEGIN
	INSERT INTO dbo.tblOrder (Id, CustomerId, OrderDate, UserId, ShipDate)
	VALUES
	(1001, 3, '2019-12-06', 1, '2019-12-08'),
	(1002, 1, '2020-01-15', 2, '2020-01-16'),
	(1003, 3, '2020-02-11', 3, '2020-02-12')
END