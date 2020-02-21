BEGIN
	INSERT INTO dbo.tblMovieGenre (Id, MovieId, GenreId)
	VALUES
	(1, 1, 3),
	(2, 1, 4),
	(3, 2, 5),
	(4, 3, 2)
END