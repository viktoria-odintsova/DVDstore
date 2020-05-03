using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.PL;

namespace VO.DVDCentral.BL
{
    public static class MovieManager
    {
        public static int Insert(out int id, string title, string description, double cost, int ratingId, int directorId, int formatId, int inStkQty, string imagePath)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovie newrow = new tblMovie();

                    newrow.Title = title;
                    newrow.Description = description;
                    newrow.Cost = cost;
                    newrow.RatingId = ratingId;
                    newrow.DirectorId = directorId;
                    newrow.FormatId = formatId;
                    newrow.InStkQty = inStkQty;
                    newrow.ImagePath = imagePath;

                    //giving a new row the next id after existing one or if there is none id equals to 1
                    newrow.Id = dc.tblMovies.Any() ? dc.tblMovies.Max(dt => dt.Id) + 1 : 1;

                    id = newrow.Id;

                    dc.tblMovies.Add(newrow);

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(Movie movie)
        {
            try
            {
                int id = 0;
                int result = Insert(out id, movie.Title, movie.Description, movie.Cost, movie.RatingId, movie.DirectorId, movie.FormatId, movie.InStkQty, movie.ImagePath);
                movie.Id = id;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Delete(int id)
        {
            try
            {
                using(DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovie deleterow = (from dt in dc.tblMovies
                                          where dt.Id == id
                                          select dt).FirstOrDefault();
                    dc.tblMovies.Remove(deleterow);
                    return dc.SaveChanges();


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Update(int id, string title, string description, double cost, int ratingId, int directorId, int formatId, int inStkQty, string imagePath)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovie updaterow = (from dt in dc.tblMovies
                                          where dt.Id == id
                                          select dt).FirstOrDefault();

                    updaterow.Title = title;
                    updaterow.Description = description;
                    updaterow.Cost = cost;
                    updaterow.RatingId = ratingId;
                    updaterow.DirectorId = directorId;
                    updaterow.FormatId = formatId;
                    updaterow.InStkQty = inStkQty;
                    updaterow.ImagePath = imagePath;

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Update(Movie movie)
        {
            return Update(movie.Id, movie.Title, movie.Description, movie.Cost, movie.RatingId, movie.DirectorId, movie.FormatId, movie.InStkQty, movie.ImagePath);
        }

        public static List<Movie> Load()
        {
            return Load(null);
        }
        public static List<Movie> Load(int? genreId)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Movie> results = new List<Movie>();

                    var movies = (from m in dc.tblMovies
                                  join r in dc.tblRatings on m.RatingId equals r.Id
                                  join d in dc.tblDirectors on m.DirectorId equals d.Id
                                  join f in dc.tblFormats on m.FormatId equals f.Id
                                  join mg in dc.tblMovieGenres on m.Id equals mg.MovieId
                                  where (mg.GenreId == genreId || genreId == null)
                                  orderby m.Title
                                  select new
                                  {
                                      MovieId = m.Id,
                                      m.Title,
                                      m.Description,
                                      m.Cost,
                                      RatingId = r.Id,
                                      DirectorId = d.Id,
                                      FormatId = f.Id,
                                      Quantity = m.InStkQty,
                                      m.ImagePath,
                                      RatingDescription = r.Description,
                                      d.FirstName,
                                      d.LastName,
                                      FormatDescription = f.Description
                                  }).ToList();

                    movies.ForEach(m => results.Add(new Movie {
                        Id = m.MovieId,
                        Title = m.Title,
                        Description = m.Description,
                        Cost = m.Cost,
                        RatingId = m.RatingId,
                        FormatId = m.FormatId,
                        DirectorId = m.DirectorId,
                        InStkQty = m.Quantity,
                        ImagePath = m.ImagePath,
                        RatingDescription = m.RatingDescription,
                        DirectorName = m.LastName + ", " + m.FirstName,
                        FormatDescription = m.FormatDescription
                    }));
                    
                    return results;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Movie LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //tblMovie row = (from dt in dc.tblMovies
                    //                where dt.Id == id
                    //                select dt).FirstOrDefault();

                    var row = (from m in dc.tblMovies
                               join r in dc.tblRatings on m.RatingId equals r.Id
                               join d in dc.tblDirectors on m.DirectorId equals d.Id
                               join f in dc.tblFormats on m.FormatId equals f.Id
                               where m.Id == id
                               select new
                               {
                                   MovieId = m.Id,
                                   m.Title,
                                   m.Description,
                                   m.Cost,
                                   RatingId = r.Id,
                                   DirectorId = d.Id,
                                   FormatId = f.Id,
                                   Quantity = m.InStkQty,
                                   m.ImagePath,
                                   RatingDescription = r.Description,
                                   d.FirstName,
                                   d.LastName,
                                   FormatDescription = f.Description
                               }).FirstOrDefault();

                    if (row != null)
                        return new Movie { 
                            Id = row.MovieId, 
                            Title = row.Title, 
                            Description = row.Description, 
                            Cost = row.Cost, 
                            DirectorId = row.DirectorId, 
                            FormatId = row.FormatId, 
                            ImagePath = row.ImagePath, 
                            InStkQty = row.Quantity, 
                            RatingId = row.RatingId,
                            RatingDescription = row.RatingDescription,
                            DirectorName = row.LastName + ", " + row.FirstName,
                            FormatDescription = row.FormatDescription
                        };
                    else
                        throw new Exception("Row was not found");
                    

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static List<Genre> LoadGenres(int movieId)
        {
            return GenreManager.LoadByMovieId(movieId);
        }
    }
}
