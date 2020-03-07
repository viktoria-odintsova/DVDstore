using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO.DVDCentral.BL.Models;
using VO.DVDCentral.PL;

namespace VO.DVDCentral.BL
{
    public class RatingManager
    {
        public static int Insert(out int id, string description)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblRating newrow = new tblRating();

                    newrow.Description = description;

                    //giving a new row the next id after existing one or if there is none id equals to 1
                    newrow.Id = dc.tblRatings.Any() ? dc.tblRatings.Max(dt => dt.Id) + 1 : 1;

                    id = newrow.Id;

                    //add the row
                    dc.tblRatings.Add(newrow);

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(Rating rating)
        {
            try
            {
                int id = 0;
                int result = Insert(out id, rating.Description);
                rating.Id = id;
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
                    tblRating deleterow = (from dt in dc.tblRatings
                                           where dt.Id == id
                                           select dt).FirstOrDefault();
                    dc.tblRatings.Remove(deleterow);
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
                    tblRating updaterow = (from dt in dc.tblRatings
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
        public static int Update(Rating rating)
        {
            return Update(rating.Id, rating.Description);
        }

        public static List<Rating> Load()
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    List<Rating> ratings = new List<Rating>();
                    foreach (tblRating dt in dc.tblRatings)
                    {
                        ratings.Add(new Rating
                        {
                            Id = dt.Id,
                            Description = dt.Description
                        });
                    }
                    return ratings;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Rating LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblRating row = (from dt in dc.tblRatings
                                     where dt.Id == id
                                     select dt).FirstOrDefault();

                    if (row != null)
                        return new Rating { Id = row.Id, Description = row.Description };
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
