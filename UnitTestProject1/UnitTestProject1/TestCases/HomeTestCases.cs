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
    [TestClass]
    public class HomeTestCases: TestBase
    {
        HomePage home;

        [TestInitialize]
        public void InitHomeTestCases()
        {
            home = new LoginPage(GetDriver()).Login(ConfigUtil.GetString("user.username"), ConfigUtil.GetString("user.password"));
        }

        // TEST CASE ID = *****. This test case verify if the Shopping Cart is displayed.
        [TestMethod]
        public void UserSeesHisShoppingCart()
        {
            MyDxPage myDx = home.ClickUserName();
            Assert.IsTrue(myDx.BeInMyDX());
        }

        // TEST CASE ID = *****. This test case verify if Search Field Cart is displayed.
        [TestMethod]
        public void UserSeesaSearchFieldCart()
        {
            Assert.IsTrue(home.IsSearchFieldPresent());
        }

        // TEST CASE ID = *****. This test case verify the Username link behavior.
        [TestMethod]
        public void UserClicksOnUsername()
        {
            MyDxPage myDx = home.ClickUserName();
            Assert.IsTrue(myDx.BeInMyDX());
        }

        // TEST CASE ID = *****. This test case verify if the DX link is displayed within the Facebook box.
        [TestMethod]
        public void UserSeesTheDXLinkWithinTheFacebookBox()
        {
            Assert.IsTrue(home.isDxLInkPresentInFacebbox());
        }

        // TEST CASE ID = *****. This test case verify the search functionality.
        [TestMethod]
        public void UserPerformsaSearch()
        {
            SearchResultPage search = home.PerformaSearch("test");
            Assert.IsTrue(search.BeInSearchResultPage());
        }

        [TestCleanup]
        public void HomeTestCasesCleanUp()
        {
            home.LogOut();
        }
    }
}
