using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    public class HomePage : PageBase
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
        IWebElement btnSearch;

        [FindsBy(How = How.Id)]
        IWebElement miniCart;

        [FindsBy(How = How.LinkText)]
        IWebElement Logout;
        
        public HomePage(IWebDriver d) :base(d)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public bool BeInHomePage()
        {
            return freeShippingButton.Displayed && username.Displayed;
        }

        public bool IsShoppingCartPresent()
        {
            return miniCart.Enabled && miniCart.Displayed;
        }

        public bool IsSearchFieldPresent()
        {
            return searchField.Displayed && searchField.Enabled  && btnSearch.Displayed && btnSearch.Enabled;
        }

        public void SetSearchField(string value)
        {
            searchField.Clear();
            searchField.SendKeys(value);
        }

        public SearchResultPage ClickOnSearchField()
        {
            btnSearch.Click();
            return new SearchResultPage(this.driver);
        }

        public SearchResultPage PerformaSearch(string value)
        {
            SetSearchField(value);
            btnSearch.Click();
            return new SearchResultPage(this.driver);
        }

        public MyDxPage ClickUserName()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('target', arguments[1]);", username, "_self");
            username.Click();
            return new MyDxPage(this.driver);
        }

        public LoginPage LogOut()
        {
            Logout.Click();
            return new LoginPage(this.driver);
        }

        public bool isDxLInkPresentInFacebbox()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("iframe[src='//www.facebook.com/plugins/likebox.php?href=http%3A%2F%2Fwww.facebook.com%2FDealExtremeFans&width=210&colorscheme=light&show_faces=true&stream=false&header=true&height=313&connections=9']")));
            bool result = driver.FindElement(By.CssSelector("a[href='https://www.facebook.com/DealExtremeFans']")).Displayed;
            driver.SwitchTo().DefaultContent();
            return result;
        }

        public FreeShippingPage ClickFreeShippingButton()
        {
            freeShipping.Click();
            this.driver.SwitchTo().Window(this.driver.WindowHandles[1]);
            return new FreeShippingPage(this.driver);
        }
    }
}
