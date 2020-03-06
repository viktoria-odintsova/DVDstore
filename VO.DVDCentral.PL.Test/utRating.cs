using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VO.DVDCentral.PL.Test
{
    
    [TestClass]
    public class utRating
    {
        [TestMethod]
        public void LoadTest()
        {
            DVDCentralEntities dc = new DVDCentralEntities();

            var results = from rating in dc.tblRatings
                          select rating;

            int expected = 4;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblRating newrow = new tblRating();

                newrow.Id = -3;
                newrow.Description = "ABC";

                dc.tblRatings.Add(newrow);

                int results = dc.SaveChanges();

                Assert.IsTrue(results > 0);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblRating row = (from dt in dc.tblRatings
                                 where dt.Id == -3
                                 select dt).FirstOrDefault();

                if(row != null)
                {
                    row.Description = "DJ";

                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblRating row = (from dt in dc.tblRatings
                                 where dt.Id == -3
                                 select dt).FirstOrDefault();

                if(row != null)
                {
                    dc.tblRatings.Remove(row);

                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }
    }
}
