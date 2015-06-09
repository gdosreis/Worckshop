using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using Utils.Util;
using OpenQA.Selenium.Firefox;

namespace UnitTestProject1
{
    [TestClass]
    public class TestBase
    {
        protected IWebDriver driver;

        [TestInitialize]
        public void InitBrowser()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ConfigUtil.GetString("base.url"));
        }

        [TestCleanup]
        public void TearDown()
        {
            try
            {
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Quit();
            }
            catch (Exception)
            {
                driver.Quit();
            }
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }
    }
}
