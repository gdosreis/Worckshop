using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    public class HomePage : DxBasePage
    {
        [FindsBy(How = How.Id)]
        protected IWebElement categoryPanel;

        [FindsBy(How = How.LinkText, Using ="Consumer Electronics")]
        protected IWebElement consumerElectronics;

        [FindsBy(How = How.CssSelector, Using = "a[href='http://www.dx.com/c/car-accessories-799']")]
        protected IWebElement carAccessories;

        [FindsBy(How = How.CssSelector, Using = "#categoryPanel li:nth-child(2) a[class='menu_title']")]
        protected IWebElement computersTabletsNetworking;


        public HomePage(IWebDriver d) : base(d) { }

        //Method to verify if be in Home Page
        public bool BeInHomePage()
        {
            return categoryPanel.Displayed && consumerElectronics.Displayed && carAccessories.Displayed && computersTabletsNetworking.Displayed;
        }

        //Method to verify DX link within Facebook box
        //Switch To iframe, because the Facebook box is a iframe
        public bool isDxLInkPresentInFacebbox()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("iframe[src='//www.facebook.com/plugins/likebox.php?href=http%3A%2F%2Fwww.facebook.com%2FDealExtremeFans&width=210&colorscheme=light&show_faces=true&stream=false&header=true&height=313&connections=9']")));
            bool result = driver.FindElement(By.CssSelector("a[href='https://www.facebook.com/DealExtremeFans']")).Displayed;
            driver.SwitchTo().DefaultContent();
            return result;
        }
    }
}
