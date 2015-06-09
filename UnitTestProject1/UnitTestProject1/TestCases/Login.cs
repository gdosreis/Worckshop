﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    /// This class checks the Login page functionality
    /// </summary>
    [TestClass]
    public class Login: TestBase
    {
        private LoginPage login;

        /// <summary>
        /// Create a LoginPage object.
        /// <summary>
        [TestInitialize]
        public void InitLogin()
        {
            login = new LoginPage(GetDriver());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if the email field is displayed.
        /// </summary>
        [TestMethod]
        public void UserSeesEmailFielTC12()
        {
            Assert.IsTrue(login.IsEmailFieldPresent());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if the password field is displayed.
        /// </summary>
        [TestMethod]
        public void UserSeesPasswordfieldTC13()
        {
            Assert.IsTrue(login.IsPasswordFieldPresent());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if the password validation.
        /// </summary>
        [TestMethod]
        public void UserTryLoginsToTheAppWithoutPasswordTC14()
        {
            login.SetEmail(ConfigUtil.GetString("user.username"));
            login.ClickLogingButton();
            Assert.IsTrue(login.IsPasswordValidationPresent());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if the username validation.
        /// </summary>
        [TestMethod]
        public void UserTryLoginsToTheAppWithoutEmailTC14()
        {
            login.SetPassword(ConfigUtil.GetString("user.password"));
            login.ClickLogingButton();
            Assert.IsTrue(login.IsUsernameValidationPresent());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if the login validation.
        /// </summary>
        [TestMethod]
        public void UserTryLoginsToTheAppWithInvalidCredentialsTC15()
        {
            login.SetEmail(ConfigUtil.GetString("base.url"));
            login.SetPassword(ConfigUtil.GetString("user.username"));
            login.ClickLogingButton();
            Assert.IsTrue(login.IsLoginValidationPresent());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify the login functionality.
        /// </summary>
        [TestMethod]
        public void UserLoginstoAppTC12()
        {
            HomePage page = login.Login(ConfigUtil.GetString("user.username"), ConfigUtil.GetString("user.password"));
            Assert.IsTrue(page.BeInHomePage());
            page.LogOut();
        }
    }
}
