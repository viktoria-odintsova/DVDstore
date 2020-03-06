using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VO.DVDCentral.PL.Test
{
    
    [TestClass]
    public class utFormat
    {
        [TestMethod]
        public void LoadTest()
        {
            DVDCentralEntities dc = new DVDCentralEntities();

            var results = from format in dc.tblFormats
                          select format;

            int expected = 3;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblFormat newrow = new tblFormat();

                newrow.Id = -44;
                newrow.Description = "new format";

                dc.tblFormats.Add(newrow);

                int results = dc.SaveChanges();

                Assert.IsTrue(results > 0);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblFormat row = (from dt in dc.tblFormats
                                 where dt.Id == -44
                                 select dt).FirstOrDefault();

                if (row != null)
                {
                    row.Description = "updated";

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
                tblFormat row = (from dt in dc.tblFormats
                                 where dt.Id == -44
                                 select dt).FirstOrDefault();

                if (row != null)
                {
                    dc.tblFormats.Remove(row);

                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }
        
    }
}
