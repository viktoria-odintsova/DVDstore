using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.PL;

namespace VO.DVDCentral.BL
{
    public static class GenreManager
    {
        public static int Insert(out int id, string description)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblGenre newrow = new tblGenre();

                    newrow.Description = description;

                    newrow.Id = dc.tblGenres.Any() ? dc.tblGenres.Max(dt => dt.Id) + 1 : 1;

                    id = newrow.Id;

                    dc.tblGenres.Add(newrow);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(Genre genre)
        {
            try
            {
                int id = 0;
                int result = Insert(out id, genre.Description);
                genre.Id = id;
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
                    tblGenre deleterow = (from dt in dc.tblGenres
                                          where dt.Id == id
                                          select dt).FirstOrDefault();
                    dc.tblGenres.Remove(deleterow);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Update(int id, string description)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblGenre updaterow = (from dt in dc.tblGenres
                                          where dt.Id == id
                                          select dt).FirstOrDefault();
                    updaterow.Description = description;

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Update(Genre genre)
        {
            return Update(genre.Id, genre.Description);
        }

        public static List<Genre> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Genre> genres = new List<Genre>();
                    foreach (tblGenre dt in dc.tblGenres)
                    {
                        genres.Add(new Genre
                        {
                            Id = dt.Id,
                            Description = dt.Description
                        });
                    }
                return genres;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Genre LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblGenre row = (from dt in dc.tblGenres
                                    where dt.Id == id
                                    select dt).FirstOrDefault();

                    if (row != null)
                        return new Genre { Id = row.Id, Description = row.Description };
                    else
                        throw new Exception("Row was not found");


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Genre> LoadByMovieId(int movieId)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Genre> genres = new List<Genre>();

                    var results = (from g in dc.tblGenres
                                   join mg in dc.tblMovieGenres on g.Id equals mg.GenreId
                                   where mg.MovieId == movieId
                                   select new
                                   {
                                       g.Id,
                                       g.Description
                                   }).ToList();

                    results.ForEach(r => genres.Add(new Genre { Id = r.Id, Description = r.Description }));

                    return genres;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
