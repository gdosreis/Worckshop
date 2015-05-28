using Utils.Util;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    public class PageBase
    {
        protected IWebDriver driver;

        public PageBase(IWebDriver d)
        {
            driver = d;
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

        public void SwitchToWindows(string name)
        {
            driver.SwitchTo().Window(name);
        }

        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }

        //Method to take a screenshot in the page.
        public void TakeScreenshot(string baseFileName) 
        {
            try
            {
                string screenshotsPath = ConfigUtil.GetString("screenshots.path");
                if (!screenshotsPath.EndsWith("\\"))
                    screenshotsPath += "\\";
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(
                    screenshotsPath + baseFileName + ".png",
                    System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception) { }
        }
    }
}
