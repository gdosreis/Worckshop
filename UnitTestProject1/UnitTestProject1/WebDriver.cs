using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Util;

namespace UnitTestProject1.TestCases
{
    [TestClass]
    public class WebDriver
    {
        private IWebDriver driver;


        [TestInitialize]
        public void InitBrowser()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(ConfigUtil.GetString("base.url"));
        }

        [TestMethod]
        public void UserLoginsToDxPage()
        {
            driver.FindElement(By.Id("email")).SendKeys(ConfigUtil.GetString("user.username"));//Search the email field by id and set the username value.
            driver.FindElement(By.Name("Password")).SendKeys(ConfigUtil.GetString("user.password"));//Search the password field by name and set the username value.
            driver.FindElement(By.Id("login_btn")).Click();//Search the Login button by id and click on it.
            Assert.IsTrue(driver.FindElement(By.CssSelector("a[title='gercho100']")).Displayed);//Verify if the username link is display.Search it by CssSelector
            Assert.IsTrue(driver.FindElement(By.LinkText("gercho100")).Displayed);//Verify if the username link is display.Search it by LinkText
        }

        [TestMethod]
        public void UserClicksUserNameLink()
        {
            driver.FindElement(By.Id("email")).SendKeys(ConfigUtil.GetString("user.username"));//Search the email field by id and set the username value.
            driver.FindElement(By.Name("Password")).SendKeys(ConfigUtil.GetString("user.password"));//Search the password field by name and set the username value.
            driver.FindElement(By.Id("login_btn")).Click();//Search the Login button by id and click on it.
            driver.FindElement(By.LinkText("gercho100")).Click();//Search the Username link by LinkText and click on it.It open a new windows.
            driver.SwitchTo().Window(driver.WindowHandles[1]);//Switch To new opened windows. WindowHandles return all names to opened windows by open order.
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='member_info']/div[2]/h2/strong")).Displayed);//Verify if the username name is display.Search it by XPath
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='member_info']//strong")).Displayed);//Verify if the username name is display. Search it by a better XPath
            Assert.IsTrue(driver.FindElement(By.ClassName("all_order")).Displayed);//Verify if the All Order link is display. Search it by Class Name
            driver.Close();//Close current windows
            driver.SwitchTo().Window(driver.WindowHandles[0]);//Switch To first window.
        }


        [TestMethod]
        public void UserSeesDxLinksWithinFacebookBox()
        {
            driver.FindElement(By.Id("email")).SendKeys(ConfigUtil.GetString("user.username"));//Search the email field by id and set the username value.
            driver.FindElement(By.Name("Password")).SendKeys(ConfigUtil.GetString("user.password"));//Search the password field by name and set the username value.
            driver.FindElement(By.Id("login_btn")).Click();//Search the Login button by id and click on it.           
            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("iframe[src='//www.facebook.com/plugins/likebox.php?href=http%3A%2F%2Fwww.facebook.com%2FDealExtremeFans&width=210&colorscheme=light&show_faces=true&stream=false&header=true&height=313&connections=9']")));//Switch To Facebook Iframe.Search it by CssSelector
            Assert.IsTrue(driver.FindElement(By.CssSelector("a[href='https://www.facebook.com/DealExtremeFans']")).Displayed);//Verify if the Dx link is display. Search it by CssSelector
            driver.SwitchTo().DefaultContent();//Switch To default content
        }

        //Log out from Dx and closes the current windows
        [TestCleanup]
        public void WebDriverCleanUp()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            driver.Close();
        }
    }
}
