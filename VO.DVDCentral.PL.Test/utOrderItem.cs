using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using VO.DVDCentral.PL;

namespace VO.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrderItem
    {
        [TestMethod]
        public void LoadTest()
        {
            DVDCentralEntities dc = new DVDCentralEntities();

            var results = from orderitem in dc.tblOrderItems
                          select orderitem;

            int expected = 3;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblOrderItem newrow = new tblOrderItem();

                newrow.Id = -324;
                newrow.OrderId = 1;
                newrow.MovieId = 3;
                newrow.Cost = 364.5;
                newrow.Quantity = 4;

                dc.tblOrderItems.Add(newrow);

                int results = dc.SaveChanges();

                Assert.IsTrue(results > 0);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblOrderItem row = (from dt in dc.tblOrderItems
                                   where dt.Id == -324
                                   select dt).FirstOrDefault();

                if (row != null)
                {
                    row.OrderId = 1;
                    row.MovieId = 3;
                    row.Cost = 11.5;
                    row.Quantity = 3;

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
                tblOrderItem row = (from dt in dc.tblOrderItems
                                   where dt.Id == -324
                                   select dt).FirstOrDefault();

                if (row != null)
                {
                    dc.tblOrderItems.Remove(row);
                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }
    }
}
