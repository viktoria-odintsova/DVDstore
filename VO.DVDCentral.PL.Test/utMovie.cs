using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VO.DVDCentral.PL.Test
{
    
    [TestClass]
    public class utMovie
    {
        [TestMethod]
        public void LoadTest()
        {
            DVDCentralEntities dc = new DVDCentralEntities();

            var results = from movie in dc.tblMovies
                          select movie;

            int expected = 3;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblMovie newrow = new tblMovie();

                newrow.Id = -111;
                newrow.Title = "Moon";
                newrow.Description = "Drama movie with ...";
                newrow.Cost = 9.99;
                newrow.DirectorId = 1;
                newrow.FormatId = 2;
                newrow.RatingId = 2;
                newrow.InStkQty = 40;
                newrow.ImagePath = "path";

                dc.tblMovies.Add(newrow);

                int results = dc.SaveChanges();

                Assert.IsTrue(results > 0);
            }
        }
    }
}
