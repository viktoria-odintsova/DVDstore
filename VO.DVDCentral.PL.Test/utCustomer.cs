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
    }
}
