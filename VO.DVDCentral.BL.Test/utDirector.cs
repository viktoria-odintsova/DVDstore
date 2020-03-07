using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.BL.Test
{
    [TestClass]
    public class utDirector
    {
        [TestMethod]
        public void InsertTest()
        {
            Director director = new Director { FirstName = "Ann", LastName = "Krueger" };
            Assert.AreNotEqual(0, DirectorManager.Insert(director));
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Director> directors = DirectorManager.Load();
            Assert.AreEqual(3, directors.Count);
        }
    }
}
