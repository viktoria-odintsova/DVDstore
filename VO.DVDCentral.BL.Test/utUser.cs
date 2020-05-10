using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VO.DVDCentral.BL.Models;

namespace VO.DVDCentral.BL.Test
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void UpdateTest()
        {
            User user = new User(3, "third", "Cayla", "Gray", "third");
            UserManager.Update(user);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LoginPassTest()
        {
            User user = new User("first", "first");
            bool actual = UserManager.Login(user);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void LoginFailTest()
        {
            User user = new User("first", "second");
            bool actual = UserManager.Login(user);
            Assert.IsFalse(actual);
        }
    }
}
