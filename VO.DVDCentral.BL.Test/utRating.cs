using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.BL.Test
{
    [TestClass]
    public class utRating
    {
        [TestMethod]
        public void InsertTest()
        {
            Rating rating = new Rating { Description = "new description" };
            Assert.AreNotEqual(0, RatingManager.Insert(rating));
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Rating> ratings = RatingManager.Load();
            Assert.AreEqual(4, ratings.Count);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Rating rating = RatingManager.LoadById(5);
            rating.Description = "updated description";
            Assert.IsTrue(RatingManager.Update(rating) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.IsTrue(RatingManager.Delete(5) > 0);
        }
    }
}
