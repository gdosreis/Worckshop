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

        [TestMethod]
        public void UserSeesPasswordfieldTC13()
        {
            Assert.IsTrue(login.IsPasswordFieldPresent());
        }

        [TestMethod]
        public void UserTryLoginsToTheAppWithoutPasswordTC14()
        {
            login.SetEmail(ConfigUtil.GetString("user.username"));
            login.ClickLogingButton();
            Assert.IsTrue(login.IsPasswordValidationPresent());
        }

        [TestMethod]
        public void UserTryLoginsToTheAppWithoutEmailTC14()
        {
            login.SetPassword(ConfigUtil.GetString("user.password"));
            login.ClickLogingButton();
            Assert.IsTrue(login.IsUsernameValidationPresent());
        }

        [TestMethod]
        public void UserTryLoginsToTheAppWithInvalidCredentialsTC15()
        {
            login.SetEmail(ConfigUtil.GetString("base.url"));
            login.SetEmail(ConfigUtil.GetString("user.username"));
            login.ClickLogingButton();
            Assert.IsTrue(login.IsLoginValidationPresent());
        }

        [TestMethod]
        public void UserLoginstoAppTC12()
        {
            HomePage page = login.Login(ConfigUtil.GetString("user.username"), ConfigUtil.GetString("user.password"));
            Assert.IsTrue(page.BeInHomePage());
        }
    }
}
