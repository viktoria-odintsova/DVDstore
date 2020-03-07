using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.BL.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoadByIdTest()
        {
            Movie movie = MovieManager.LoadById(1);
            Assert.IsTrue(movie != null);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.IsTrue(MovieManager.Delete(3) > 0);
        }
    }
}
