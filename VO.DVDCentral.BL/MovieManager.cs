using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.PL;

namespace VO.DVDCentral.BL
{
    public class MovieManager
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
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Movie> movies = new List<Movie>();
                    foreach (tblMovie dt in dc.tblMovies)
                    {
                        movies.Add(new Movie
                        {
                            Id = dt.Id,
                            Title = dt.Title,
                            Description = dt.Description,
                            Cost = dt.Cost,
                            RatingId = dt.RatingId,
                            DirectorId = dt.DirectorId,
                            FormatId = dt.FormatId,
                            InStkQty = dt.InStkQty,
                            ImagePath = dt.ImagePath,
                        });
                    }
                    return movies;
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
                    tblMovie row = (from dt in dc.tblMovies
                                    where dt.Id == id
                                    select dt).FirstOrDefault();

                    if (row != null)
                        return new Movie { Id = row.Id, Title = row.Title, Description = row.Description, Cost = row.Cost, DirectorId = row.DirectorId, FormatId = row.FormatId, ImagePath = row.ImagePath, InStkQty = row.InStkQty, RatingId = row.RatingId };
                    else
                        throw new Exception("Row was not found");
                    

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
