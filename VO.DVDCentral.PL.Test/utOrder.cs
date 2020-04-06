using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using VO.DVDCentral.PL;

namespace VO.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void LoadTest()
        {
            DVDCentralEntities dc = new DVDCentralEntities();

            var results = from order in dc.tblOrders
                          select order;

            int expected = 3;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblOrder newrow = new tblOrder();

                newrow.Id = -324;
                newrow.UserId = 5;
                newrow.OrderDate = DateTime.Now;
                newrow.ShipDate = DateTime.Now;
                newrow.CustomerId = 35324534;

                dc.tblOrders.Add(newrow);

                int results = dc.SaveChanges();

                Assert.IsTrue(results > 0);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using(DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblOrder row = (from dt in dc.tblOrders
                                where dt.Id == -324
                                select dt).FirstOrDefault();

                if(row != null)
                {
                    row.CustomerId = 111;
                    row.UserId = 999;
                    row.ShipDate = DateTime.Now;
                    row.OrderDate = DateTime.Today;

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
                tblOrder row = (from dt in dc.tblOrders
                                where dt.Id == -324
                                select dt).FirstOrDefault();

                if(row != null)
                {
                    dc.tblOrders.Remove(row);
                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }
    }
}
