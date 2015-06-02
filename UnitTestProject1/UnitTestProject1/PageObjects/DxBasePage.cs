using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    public class DxBasePage : PageBase
    {
        [FindsBy(How = How.CssSelector, Using = "span.flag.t.flag-ar")]
        IWebElement freeShippingButton; 

        [FindsBy(How = How.LinkText, Using="gercho100")]
        protected IWebElement username;

        [FindsBy(How = How.LinkText, Using = "Logout")]
        protected IWebElement logout;

        [FindsBy(How = How.CssSelector, Using = "img[alt='Cool Gadgets at DX']")]
        protected IWebElement logo;

        [FindsBy(How = How.CssSelector, Using = "span.flag.t.flag-ar")]
        protected IWebElement freeShipping;

        [FindsBy(How = How.Id, Using = "txtKeyword")]
        protected IWebElement searchField;

        [FindsBy(How = How.Id)]
        protected IWebElement btnSearch;

        [FindsBy(How = How.Id)]
        protected IWebElement miniCart;

        [FindsBy(How = How.LinkText)]
        protected IWebElement Logout;

        public DxBasePage(IWebDriver d) : base(d) { }

        //Method to verify if Shopping Cart is present 
        public bool IsShoppingCartPresent()
        {
            return miniCart.Enabled && miniCart.Displayed;
        }

        //Method to verify if Search Field is present 
        public bool IsSearchFieldPresent()
        {
            return searchField.Displayed && searchField.Enabled  && btnSearch.Displayed && btnSearch.Enabled;
        }

        //Method to set a value in the search field 
        public void SetSearchField(string value)
        {
            searchField.Clear();
            searchField.SendKeys(value);
        }

        //Method to click Search button
        public SearchResultPage ClickOnSearchButton()
        {
            btnSearch.Click();
            return new SearchResultPage(this.driver);
        }

        //Method to perform a search 
        public SearchResultPage PerformaSearch(string value)
        {
            SetSearchField(value);
            btnSearch.Click();
            return new SearchResultPage(this.driver);
        }

        //Method to click the Username link
        public MyDxPage ClickUserName()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('target', arguments[1]);", username, "_self");
            username.Click();
            return new MyDxPage(this.driver);
        }

        //Method to perform a log out 
        public LoginPage LogOut()
        {
            Logout.Click();
            return new LoginPage(this.driver);
        }

        //Method to click the Free Shipping button
        //Return a Freeshipping page object, because redirest to this page.
        public FreeShippingPage ClickFreeShippingButton()
        {
            freeShipping.Click();
            this.driver.SwitchTo().Window(this.driver.WindowHandles[1]);
            return new FreeShippingPage(this.driver);
        }
    }
}
