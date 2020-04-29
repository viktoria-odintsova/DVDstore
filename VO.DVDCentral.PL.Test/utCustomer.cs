using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using VO.DVDCentral.PL;

namespace VO.DVDCentral.PL.Test
{
    [TestClass]
    public class utCustomer
    {
        [TestMethod]
        public void LoadTest()
        {
            DVDCentralEntities dc = new DVDCentralEntities();

            var results = from customer in dc.tblCustomers
                          select customer;

            int expected = 3;
            int actual = results.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblCustomer newrow = new tblCustomer();

                newrow.Id = -324;
                newrow.UserId = 5;
                newrow.FirstName = "first";
                newrow.LastName = "last";
                newrow.Address = "123 Main";
                newrow.City = "Appleton";
                newrow.State = "WI";
                newrow.ZIP = "54914";
                newrow.Phone = "12432356";

                dc.tblCustomers.Add(newrow);

                int results = dc.SaveChanges();

                Assert.IsTrue(results > 0);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                tblCustomer row = (from dt in dc.tblCustomers
                                where dt.Id == -324
                                select dt).FirstOrDefault();

                if (row != null)
                {
                    row.UserId = 5;
                    row.FirstName = "updated";
                    row.LastName = "updated";
                    row.Address = "123 Main";
                    row.City = "Appleton";
                    row.State = "WI";
                    row.ZIP = "54914";
                    row.Phone = "12432356";

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
                tblCustomer row = (from dt in dc.tblCustomers
                                where dt.Id == -324
                                select dt).FirstOrDefault();

                if (row != null)
                {
                    dc.tblCustomers.Remove(row);
                    int actual = dc.SaveChanges();
                    Assert.AreNotEqual(0, actual);
                }
            }
        }
    }
}
