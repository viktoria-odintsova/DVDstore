//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using VO.DVDCentral.BL.Models;
//using VO.DVDCentral.PL;

//namespace VO.DVDCentral.BL
//{
//    class MovieManager
//    {
//        public static int Insert(out int id, int movieId, string title, string description, float cost, int ratingId, int directorId, int formatId, int inStkQty, string imagePath)
//        {
//            try
//            {
//                using ()
//                {
                    
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public static int Insert(Movie movie)
//        {
//            try
//            {
//                int id = 0;
//                int result = Insert(out id, movie.Title, movie.Description, movie.Cost, movie.RatingId, movie.DirectorId, movie.FormatId, movie.InStkQty, movie.ImagePath)
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }

//        public static int Delete(int id)
//        {
//            try
//            {

//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }

//        public static int Update(int id, string title, string description, float cost, int ratingId, int directorId, int formatId, int inStkQty, string imagePath)
//        {
//            try
//            {
//                using ()
//                {

//                }
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }
//        public static int Update(Movie movie)
//        {
//            return Update(movie.Id, movie.Title, movie.Description, movie.Cost, movie.RatingId, movie.DirectorId, movie.FormatId, movie.InStkQty, movie.ImagePath);
//        }

//        public static List<Movie> Load()
//        {
//            try
//            {
//                using ()
//                {
//                    List<Movie> movies = new List<Movie>();
//                    foreach ()
//                    {
//                        movies.Add(new Movie
//                        {
//                            Id = mv.Id,
//                            Title = mv.Title,
//                            Description = mv.Description,
//                            Cost = ,
//                            RatingId = ,
//                            DirectorId = ,
//                            FormatId = ,
//                            InStkQty = ,
//                            ImagePath = ,
//                        });
//                    }
//                }
//                return;
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }

//        public static Movie LoadById(int id)
//        {
//            try
//            {
//                using ()
//                {



//                }
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }
//    }
//}
