using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrderItem
    {
        [TestMethod]
        public void LoadByOrderIdTest()
        {
            List<OrderItem> items = OrderItemManager.LoadByOrderId(2);
            Assert.AreEqual(1, items.Count);
        }
    }
}
