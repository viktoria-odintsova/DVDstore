using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.PL;

namespace VO.DVDCentral.BL
{
    public class DirectorManager
    {
        public static int Insert(out int id, string firstName, string lastName)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblDirector newrow = new tblDirector();

                    newrow.FirstName = firstName;
                    newrow.LastName = lastName;

                    newrow.Id = dc.tblDirectors.Any() ? dc.tblDirectors.Max(dt => dt.Id) + 1 : 1;

                    id = newrow.Id;

                    dc.tblDirectors.Add(newrow);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(Director director)
        {
            try
            {
                int id = 0;
                int results = Insert(out id, director.FirstName, director.LastName);
                director.Id = id;
                return results;
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
                    tblDirector deleterow = (from dt in dc.tblDirectors
                                             where dt.Id == id
                                             select dt).FirstOrDefault();

                    dc.tblDirectors.Remove(deleterow);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Update(int id, string firstName, string lastName)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblDirector updaterow = (from dt in dc.tblDirectors
                                             where dt.Id == id
                                             select dt).FirstOrDefault();

                    updaterow.FirstName = firstName;
                    updaterow.LastName = lastName;

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int Update(Director director)
        {
            return Update(director.Id, director.FirstName, director.LastName);
        }

        public static List<Director> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Director> directors = new List<Director>();
                    foreach (tblDirector dt in dc.tblDirectors)
                    {
                        directors.Add(new Director
                        {
                            Id = dt.Id,
                            FirstName = dt.FirstName,
                            LastName = dt.LastName
                        });
                    }
                return directors;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Director LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblDirector row = (from dt in dc.tblDirectors
                                       where dt.Id == id
                                       select dt).FirstOrDefault();

                    if (row != null)
                        return new Director { Id = row.Id, FirstName = row.FirstName, LastName = row.LastName };
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
