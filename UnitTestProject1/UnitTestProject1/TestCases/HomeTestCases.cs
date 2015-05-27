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

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void UserSeesHisShoppingCart()
        {
            MyDxPage myDx = home.ClickUserName();
            Assert.IsTrue(myDx.BeInMyDX()); //Manejo de errores
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void UserSeesaSearchFieldCart()
        {
            Assert.IsTrue(home.IsSearchFieldPresent()); //Manejo de errores
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void UserClicksOnUsername()
        {
            MyDxPage myDx = home.ClickUserName();
            Assert.IsTrue(myDx.BeInMyDX()); //Manejo de errores
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestCleanup]
        public void HomeTestCasesCleanUp()
        {
            home.LogOut();
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void IsDxLink()
        {
            Assert.IsTrue(home.isDxLInkPresentInFacebbox()); //Manejo de errores
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void UserPerformsaSearch()
        {
            SearchResultPage search = home.PerformaSearch("test");
            Assert.IsTrue(search.BeInSearchResultPage()); //Manejo de errores
        }
    }
}
