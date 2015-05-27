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
        public void InitHomeTestCases()
        {
            freeShipping = new LoginPage(GetDriver()).Login(ConfigUtil.GetString("user.username"), ConfigUtil.GetString("user.password")).ClickFreeShippingButton();
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void UserDirectsToFreeShippingPage()
        {
            Assert.IsTrue(freeShipping.BeInFreeShipping()); //Manejo de errores
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void UserSeeYesAsDefaultCheckedOption()
        {
            Assert.IsTrue(freeShipping.IsCheckedYesOption()); //Manejo de errores
            Assert.IsFalse(freeShipping.IsCheckedNoOption());
        }

        [TestMethod]
        public void UserCheckesNoOption()
        {
            freeShipping.CheckNoOption();
            Assert.IsFalse(freeShipping.IsCheckedYesOption()); //Manejo de errores
            Assert.IsTrue(freeShipping.IsCheckedNoOption());
        }

        [TestMethod]
        public void UserSubmitsYourResponse()
        {
            Assert.IsFalse(freeShipping.IsSubmitedRespons());
            freeShipping.CheckNoOption();
            freeShipping.ClickSubmitButton();
            Assert.IsTrue(freeShipping.IsSubmitedRespons());
        }

        [TestMethod]
        public void UserClosesDialogBox()
        {
            freeShipping.ClickCloseDialogButton();
            Assert.IsFalse(freeShipping.IsDialogPresent());
        }
    }
}
