using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects;
using Utils.Util;

namespace UnitTestProject1.TestCases
{
    /// <summary>
    /// This class checks the Home page functionality
    /// </summary>
    [TestClass]
    public class HomeTestCases: TestBase
    {
        HomePage home;

        /// <summary>
        ///  Login in the application
        /// </summary>
        [TestInitialize]
        public void InitHomeTestCases()
        {
            home = new LoginPage(GetDriver()).Login(ConfigUtil.GetString("user.username"), ConfigUtil.GetString("user.password"));
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if the Shopping Cart is displayed.
        /// </summary>
        [TestMethod]
        public void UserSeesHisShoppingCart()
        {
            MyDxPage myDx = home.ClickUserName();
            Assert.IsTrue(myDx.BeInMyDX());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if Search Field Cart is displayed.
        /// </summary>
        [TestMethod]
        public void UserSeesaSearchFieldCart()
        {
            Assert.IsTrue(home.IsSearchFieldPresent());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify the Username link behavior.
        /// </summary>
        [TestMethod]
        public void UserClicksOnUsername()
        {
            MyDxPage myDx = home.ClickUserName();
            Assert.IsTrue(myDx.BeInMyDX());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if the DX link is displayed within the Facebook box.
        /// </summary>
        [TestMethod]
        public void UserSeesTheDXLinkWithinTheFacebookBox()
        {
            Assert.IsTrue(home.isDxLInkPresentInFacebbox());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify the search functionality.
        /// <summary>
        [TestMethod]
        public void UserPerformsaSearch()
        {
            SearchResultPage search = home.PerformaSearch("test");
            Assert.IsTrue(search.BeInSearchResultPage());
        }

        /// <summary>
        /// Logout from the application.
        /// <summary>
        [TestCleanup]
        public void HomeTestCasesCleanUp()
        {
            home.LogOut();
        }
    }
}
