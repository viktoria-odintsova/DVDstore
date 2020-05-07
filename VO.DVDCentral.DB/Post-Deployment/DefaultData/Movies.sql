BEGIN
	INSERT INTO dbo.tblMovie (Id, Title, Description, Cost, RatingId, FormatId, DirectorId, InStkQty, ImagePath)
	VALUES
	(1, 'Avatar', 'Great Movie', 14.99, 3, 1, 1, 39, 'avatar.jpg'),
	(2, 'La la land', 'another description', 17.99, 4, 1, 3, 25, 'lalaland.jpg'),
	(3, 'Oceans 8', 'description', 11.99, 1, 1, 2, 20, 'oceans8.jpg')
END