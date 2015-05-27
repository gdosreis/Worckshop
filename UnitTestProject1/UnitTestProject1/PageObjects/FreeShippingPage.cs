using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    public class FreeShippingPage : PageBase
    {
        [FindsBy(How = How.Id, Using = "dialog_box")]
        IWebElement dialogBox;

        [FindsBy(How = How.CssSelector, Using = "div.live_chat a[id^='lpChatBtnHref']")]
        protected IWebElement chatButton;

        [FindsBy(How = How.Id)]
        IWebElement FeedbackOK;

        [FindsBy(How = How.CssSelector, Using = "label:nth-child(2) input")]
        IWebElement FeedbackYes;

        [FindsBy(How = How.CssSelector, Using = "label:nth-child(3) input")]
        IWebElement FeedbackNo;

        [FindsBy(How = How.Id)]
        IWebElement FeedbackSuccess;

        [FindsBy(How = How.ClassName)]
        IWebElement close;

        public FreeShippingPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool BeInFreeShipping()
        {
            return dialogBox.Displayed && dialogBox.Enabled && chatButton.Displayed && chatButton.Enabled && FeedbackOK.Displayed && FeedbackOK.Enabled;
        }

        public bool IsCheckedYesOption()
        {
            return FeedbackYes.Selected;
        }

        public bool IsCheckedNoOption()
        {
            return FeedbackNo.Selected;
        }

        public void CheckYesOption()
        {
            FeedbackYes.Click();
        }

        public void CheckNoOption()
        {
            FeedbackNo.Click();
        }

        public void ClickSubmitButton()
        {
            FeedbackOK.Click();
        }

        public bool IsSubmitedRespons()
        {
            return FeedbackSuccess.Displayed;
        }

        public bool IsDialogPresent()
        {
            return dialogBox.Displayed;
        }

        public void ClickCloseDialogButton() 
        {
            close.Click();
        }
    }
}
