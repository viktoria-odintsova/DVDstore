using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void InsertTest()
        {
            Order order = new Order { UserId = 34, CustomerId = 24, OrderDate = DateTime.Now, ShipDate = DateTime.Now };
            Assert.AreNotEqual(0, OrderManager.Insert(order));
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Order> orders = OrderManager.Load();
            Assert.AreEqual(3, orders.Count);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Order order = OrderManager.LoadById(4);
            order.UserId = 555;
            Assert.IsTrue(OrderManager.Update(order) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.IsTrue(OrderManager.Delete(4) > 0);
        }
    }
}
