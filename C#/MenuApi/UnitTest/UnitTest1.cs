using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MenuApi.Models;
using MenuApi.Controllers;

namespace UnitTest
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void TestGetMenuIsCorrect()
        {
            MenuController c = new MenuController();
            List<MenuCategory> expect = DAO_Menu.theMenu;
            List<MenuCategory> actual /*= c.GetMenu() as List<MenuCategory>*/ = null;

            Assert.AreEqual(expect, actual);
        }
    }
}
