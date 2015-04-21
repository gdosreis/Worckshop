﻿using Utils.Util;
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

        protected void MaximazePage()
        {
            driver.Manage().Window.Maximize();
        }

        protected void ClosePage()
        {
            driver.Close();
        }

        protected void ClearAllCoockies()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        protected void TakeScreenshot(string baseFileName) 
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