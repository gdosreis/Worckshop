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
    public class Login: TestBase
    {
        private LoginPage login;

        [TestInitialize]
        public void InitLogin()
        {
            login = new LoginPage(GetDriver());
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void UserSeesEmailFielTC12()
        {
            Assert.IsTrue(login.IsEmailFieldPresent());
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void UserSeesPasswordfieldTC13()
        {
            Assert.IsTrue(login.IsPasswordFieldPresent());
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void UserTryLoginsToTheAppWithoutPasswordTC14()
        {
            login.SetEmail(ConfigUtil.GetString("user.username"));
            login.ClickLogingButton();
            Assert.IsTrue(login.IsPasswordValidationPresent());
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void UserTryLoginsToTheAppWithoutEmailTC14()
        {
            login.SetPassword(ConfigUtil.GetString("user.password"));
            login.ClickLogingButton();
            Assert.IsTrue(login.IsUsernameValidationPresent());
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void UserTryLoginsToTheAppWithInvalidCredentialsTC15()
        {
            login.SetEmail(ConfigUtil.GetString("base.url"));
            login.SetPassword(ConfigUtil.GetString("user.username"));
            login.ClickLogingButton();
            Assert.IsTrue(login.IsLoginValidationPresent());
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void UserLoginstoAppTC12()
        {
            HomePage page = login.Login(ConfigUtil.GetString("user.username"), ConfigUtil.GetString("user.password"));
            Assert.IsTrue(page.BeInHomePage());
        }
    }
}
