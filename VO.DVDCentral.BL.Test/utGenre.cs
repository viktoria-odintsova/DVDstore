using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.BL.Test
{
    [TestClass]
    public class utGenre
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Genre> genres = GenreManager.Load();
            Assert.AreEqual(6, genres.Count);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Genre genre = GenreManager.LoadById(555);

            genre.Description = "Horror";

            Assert.IsTrue(GenreManager.Update(genre) > 0);
        }
    }
}
