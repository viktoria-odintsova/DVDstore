using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VO.DVDCentral.PL;
using System.Linq;

namespace VO.DVDCentral.PL.Test
{
    /// <summary>
    /// Summary description for utDirector
    /// </summary>
    [TestClass]
    public class utDirector
    {
        [TestMethod]
        public void LoadTest()
        {
            //instantiate a datacontext variable connected to the database
            DVDCentralEntities dc = new DVDCentralEntities();

            var results = from director in dc.tblDirectors
                          select director;

            int expected = 3;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                //make a new director
                tblDirector newrow = new tblDirector();

                //set the column values
                newrow.Id = -32;
                newrow.FirstName = "FirstN";
                newrow.LastName = "LastN";

                //add the row
                dc.tblDirectors.Add(newrow);

                //save the changes
                int results = dc.SaveChanges();

                Assert.IsTrue(results > 0);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                //get the record that I want to update
                tblDirector row = (from dt in dc.tblDirectors
                                   where dt.Id == -32
                                   select dt).FirstOrDefault();

                if(row != null)
                {
                    row.FirstName = "updated FN";
                    row.LastName = "updated LN";

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
                tblDirector row = (from dt in dc.tblDirectors
                                   where dt.Id == -32
                                   select dt).FirstOrDefault();

                if(row != null)
                {
                    dc.tblDirectors.Remove(row);

                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }
    }
}
