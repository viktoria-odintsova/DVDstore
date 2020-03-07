using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.BL.Test
{
    [TestClass]
    public class utFormat
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Format> formats = FormatManager.Load();
            Assert.AreEqual(3, formats.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Format format = new Format { Description = "JKFL" };
            Assert.AreNotEqual(0, FormatManager.Insert(format));
        }
    }
}
