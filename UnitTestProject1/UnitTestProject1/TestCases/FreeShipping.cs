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
    public class FreeShipping : TestBase
    {
        FreeShippingPage freeShipping;

        [TestInitialize]
        public void InitFreeShipping()
        {
            freeShipping = new LoginPage(GetDriver()).Login(ConfigUtil.GetString("user.username"), ConfigUtil.GetString("user.password")).ClickFreeShippingButton();
        }

        // TEST CASE ID = *****. This test case verify if the users is directs to Free Shiping page.
        [TestMethod]
        public void UserDirectsToFreeShippingPage()
        {
            Assert.IsTrue(freeShipping.BeInFreeShipping());
        }

        // TEST CASE ID = *****. This test case verify if the YES option is selected by default.
        [TestMethod]
        public void UserSeeYesAsDefaultCheckedOption()
        {
            Assert.IsTrue(freeShipping.IsCheckedYesOption());
            Assert.IsFalse(freeShipping.IsCheckedNoOption());
        }

        // TEST CASE ID = *****. This test case verify if the NO option could be select.
        [TestMethod]
        public void UserCheckesNoOption()
        {
            freeShipping.CheckNoOption();
            Assert.IsFalse(freeShipping.IsCheckedYesOption());
            Assert.IsTrue(freeShipping.IsCheckedNoOption());
        }

        // TEST CASE ID = *****. This test case verify the Submit respons functionality.
        [TestMethod]
        public void UserSubmitsYourResponse()
        {
            Assert.IsFalse(freeShipping.IsSubmitedRespons());
            freeShipping.CheckNoOption();
            freeShipping.ClickSubmitButton();
            Assert.IsTrue(freeShipping.IsSubmitedRespons());
        }

        // TEST CASE ID = *****. This test case verify the Close dialog box functionality.
        [TestMethod]
        public void UserClosesDialogBox()
        {
            freeShipping.ClickCloseDialogButton();
            Assert.IsFalse(freeShipping.IsDialogPresent());
        }

        [TestCleanup]
        public void FreeShippingCleanUp()
        {
            freeShipping.LogOut();
        }
    }
}
