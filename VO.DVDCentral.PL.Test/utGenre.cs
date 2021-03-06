using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VO.DVDCentral.PL;
using System.Linq;

namespace VO.DVDCentral.PL.Test
{
   
    [TestClass]
    public class utGenre
    {
        [TestMethod]
        public void LoadTest()
        {
            DVDCentralEntities dc = new DVDCentralEntities();

            var results = from genre in dc.tblGenres
                          select genre;

            int expected = 5;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblGenre newrow = new tblGenre();

                newrow.Id = 555;
                newrow.Description = "name of genre";

                dc.tblGenres.Add(newrow);
                int results = dc.SaveChanges();

                Assert.IsTrue(results > 0);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblGenre row = (from dt in dc.tblGenres
                                where dt.Id == 555
                                select dt).FirstOrDefault();

                if(row != null)
                {
                    row.Description = "updated description";

                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblGenre row = (from dt in dc.tblGenres
                                where dt.Id == 555
                                select dt).FirstOrDefault();

                if(row != null)
                {
                    dc.tblGenres.Remove(row);
                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }
    }
}
