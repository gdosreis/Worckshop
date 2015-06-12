using Utils.Util;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.PageObjects
{
    public class PageBase
    {
        protected IWebDriver driver;

        public PageBase(IWebDriver d)
        {
            driver = d;
            PageFactory.InitElements(this.driver, this);
        }

        //Method to maximaze the page
        public void MaximazePage()
        {
            driver.Manage().Window.Maximize();
        }

        //Method to close the page
        public void ClosePage()
        {
            driver.Close();
        }

        //Method to clear all coockies
        public void ClearAllCoockies()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }


        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }

        //Method to refresh the current page.
        public void RefreshPage() 
        {
            driver.Navigate().Refresh();
        }

        //Method to take a screenshot in the page.
        public void TakeScreenshot(string baseFileName) 
        {
            try
            {
                string screenshotsPath = ConfigUtil.GetString("screenshots.path");
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(
                    screenshotsPath + baseFileName + ".png",
                    System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception) { }
        }
    }
}
