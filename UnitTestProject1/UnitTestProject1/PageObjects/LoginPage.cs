using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    public class LoginPage : PageBase
    {
        [FindsBy(How = How.Id)]
        IWebElement email;

        [FindsBy(How = How.Name)]
        protected IWebElement Password;

        [FindsBy(How = How.CssSelector, Using = "div[class='error_tips']")]
        IWebElement userNameError;

        [FindsBy(How = How.CssSelector, Using = "#loginForm > div:nth-child(5)")]
        protected IWebElement passwordError;

        [FindsBy(How = How.CssSelector, Using = "div.error_tips.all_error_tips")]
        protected IWebElement loginValidation;

        [FindsBy(How = How.Id)]
        protected IWebElement login_btn;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        //Method to verify if the Email field is present
        public bool IsEmailFieldPresent() //Manejo de errores
        {
            return email.Displayed && email.Enabled;
        }

        //Method to verify if the Password field is present
        public bool IsPasswordFieldPresent() //Manejo de errores
        {
            return Password.Displayed && Password.Enabled;
        }

        //Method to verify if the Login button is present
        public bool IsLoginButtonPresent() //Manejo de errores
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
        public bool IsPasswordValidationPresent() //Manejo de errores
        { return passwordError.Displayed; }

        //Method to verify if the username validation is present
        public bool IsUsernameValidationPresent() //Manejo de errores
        { return userNameError.Displayed; }

        //Method to verify if the login validation is present
        public bool IsLoginValidationPresent() //Manejo de errores
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
