using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1.PageObjects
{
    public class LoginPage : PageBase
    {
        [FindsBy(How = How.Id)]
        protected IWebElement email;

        [FindsBy(How = How.Name)]
        protected IWebElement Password;

        [FindsBy(How = How.CssSelector, Using = "div[class='error_tips23']")]
        protected IWebElement userNameError;

        [FindsBy(How = How.CssSelector, Using = "#loginForm > div:nth-child(5)")]
        protected IWebElement passwordError;

        [FindsBy(How = How.CssSelector, Using = "div.error_tips.all_error_tips")]
        protected IWebElement loginValidation;

        [FindsBy(How = How.Id)]
        protected IWebElement login_btn;

        private WebDriverWait wait;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(this.driver, new TimeSpan(0, 0, 15));
        }

        //Method to verify if the Email field is present
        public bool IsEmailFieldPresent()
        {
            return email.Displayed && email.Enabled;
        }

        //Method to verify if the Password field is present
        public bool IsPasswordFieldPresent()
        {
            return Password.Displayed && Password.Enabled;
        }

        //Method to verify if the Login button is present
        public bool IsLoginButtonPresent()
        {
            return login_btn.Displayed && login_btn.Enabled;
        }

        //Method to set the email value
        public void SetEmail(string mail)
        { email.SendKeys(mail); }

        //Method to set the password value
        public void SetPassword(string pass)
        { Password.SendKeys(pass); }

        //Method to click Login button
        public void ClickLogingButton()
        { login_btn.Click(); }

        //Method to verify if the Password validation is present
        public bool IsPasswordValidationPresent() 
        { return passwordError.Displayed; }

        //Method to verify if the username validation is present
        public bool IsUsernameValidationPresent()
        { return userNameError.Displayed; }

        //Method to verify if the login validation is present
        public bool IsLoginValidationPresent() 
        { return loginValidation.Displayed; }

        //Method to perform a login
        public HomePage Login(string mail, string pass)
        {
            SetEmail(mail);
            SetPassword(pass);
            ClickLogingButton();
            return new HomePage(this.driver);
        }
    }
}
