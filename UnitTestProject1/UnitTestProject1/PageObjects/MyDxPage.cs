using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    public class MyDxPage : PageBase
    {
        [FindsBy(How = How.CssSelector, Using = "#member_info img")]
        IWebElement userImage;

        [FindsBy(How = How.CssSelector, Using = "a[href='/Points/MyPoints']")]
        protected IWebElement myPointsLink;

        [FindsBy(How = How.CssSelector, Using = "a[jtype='privateMessages']")]
        protected IWebElement privateMessageLink;

        [FindsBy(How = How.LinkText, Using = "My Store Credits")]
        protected IWebElement myStoreCreditsLink;

        [FindsBy(How = How.LinkText, Using = "Gift Card Redeem")]
        protected IWebElement giftCardRedeemLink;

        [FindsBy(How = How.CssSelector, Using = "#member_info strong")]
        protected IWebElement userName;

        [FindsBy(How = How.Id)]
        protected IWebElement imageupload;

        [FindsBy(How = How.CssSelector, Using = "a[mid='110']")]
        protected IWebElement myOrders;

        [FindsBy(How = How.LinkText, Using = "My Profile")]
        protected IWebElement myProfile;

        public MyDxPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool BeInMyDX()
        {
            return userName.Displayed && myPointsLink.Displayed && myStoreCreditsLink.Displayed && privateMessageLink.Displayed && giftCardRedeemLink.Displayed;
        }

        public string GetUsername()
        {
            return userName.Text;
        }

        public bool IsMyOrdersLinkPresent()
        {
            return myOrders.Displayed && myOrders.Enabled;
        }

        public bool IsMyProfileLinkPresent()
        {
            return myOrders.Displayed && myOrders.Enabled;
        }

        public void UploadImage(string path)
        {
            imageupload.SendKeys(path);
        }

        public string GetValidationAlert()
        {
            return driver.SwitchTo().Alert().Text;
        }
    }
}
