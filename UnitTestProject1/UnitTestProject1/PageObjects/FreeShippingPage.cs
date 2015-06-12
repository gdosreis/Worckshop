using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    public class FreeShippingPage : DxBasePage
    {
        [FindsBy(How = How.Id, Using = "dialog_box")]
        protected IWebElement dialogBox;

        [FindsBy(How = How.CssSelector, Using = "div.live_chat a[id^='lpChatBtnHref']")]
        protected IWebElement chatButton;

        [FindsBy(How = How.Id)]
        protected IWebElement FeedbackOK;

        [FindsBy(How = How.CssSelector, Using = "label:nth-child(2) input")]
        protected IWebElement FeedbackYes;

        [FindsBy(How = How.CssSelector, Using = "label:nth-child(3) input")]
        protected IWebElement FeedbackNo;

        [FindsBy(How = How.Id)]
        protected IWebElement FeedbackSuccess;

        [FindsBy(How = How.ClassName)]
        protected IWebElement close;


        public FreeShippingPage(IWebDriver driver) : base(driver) { }

        //Method to verify if be in Free Shipping page
        public bool AreFreeShipingElementsPresents()
        {
            return dialogBox.Displayed && dialogBox.Enabled && chatButton.Displayed && chatButton.Enabled && FeedbackOK.Displayed && FeedbackOK.Enabled;
        }

        //Method to verify if the corresponding option is selected
        public bool IsCheckedYesOption()
        {
            return FeedbackYes.Selected;
        }

        //Method to verify if the corresponding option is selected
        public bool IsCheckedNoOption()
        {
            return FeedbackNo.Selected;
        }

        //Method to select the YES option
        public void CheckYesOption()
        {
            FeedbackYes.Click();
        }

        //Method to select the NO option
        public void CheckNoOption()
        {
            FeedbackNo.Click();
        }

        //Method to click Submit button
        public void ClickSubmitButton()
        {
            FeedbackOK.Click();
        }

        //Method to verify is the respons was submited
        public bool IsSubmitedRespons()
        {
            return FeedbackSuccess.Displayed;
        }

        //Method to verify is the Dialog Box is present
        public bool IsDialogPresent()
        {
            return dialogBox.Displayed;
        }

        //Method to close the dialog box
        public void ClickCloseDialogButton() 
        {
            close.Click();
        }
    }
}
