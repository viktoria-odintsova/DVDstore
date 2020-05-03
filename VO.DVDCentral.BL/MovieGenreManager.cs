using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.PL;

namespace VO.DVDCentral.BL
{
    public static class MovieGenreManager
    {
        public static void Delete(int movieId, int genreId)
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblMovieGenre mg = dc.tblMovieGenres.FirstOrDefault(m => m.MovieId == movieId
                                                    && m.GenreId == genreId);

                if (mg != null)
                {
                    dc.tblMovieGenres.Remove(mg);
                    dc.SaveChanges();
                }
            }
        }

        public static void Add(int movieId, int genreId)
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblMovieGenre mg = new tblMovieGenre();
                mg.Id = dc.tblMovieGenres.Any() ? dc.tblMovieGenres.Max(m => m.Id) + 1 : 1;
                mg.GenreId = genreId;
                mg.MovieId = movieId;

                dc.tblMovieGenres.Remove(mg);
                dc.SaveChanges();
            }
        }
    }
}
