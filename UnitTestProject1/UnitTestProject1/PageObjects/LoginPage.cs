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

         [FindsBy(How = How.XPath, Using = "div[@class='error_tips'][0]")]
        IWebElement userNameError;

        [FindsBy(How = How.XPath, Using = "div[@class='error_tips'][1]")]
        protected IWebElement passwordError;

        [FindsBy(How = How.ClassName, Using = "error_tips all_error_tips")]
        protected IWebElement loginValidation;

        [FindsBy(How = How.Id)]
        protected IWebElement login_btn;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public bool IsEmailFieldPresent() //Manejo de errores
        {
            return email.Displayed && email.Enabled;
        }

        public bool IsPasswordFieldPresent() //Manejo de errores
        {
            return Password.Displayed && Password.Enabled;
        }

        public bool IsLoginButtonPresent() //Manejo de errores
        {
            return login_btn.Displayed && login_btn.Enabled;
        }

        public void SetEmail(string mail)
        { email.SendKeys(mail); }

        public void SetPassword(string pass)
        { Password.SendKeys(pass); }

        public void ClickLogingButton()
        { login_btn.Click(); }

        public bool IsPasswordValidationPresent() //Manejo de errores
        { return passwordError.Displayed; }

        public bool IsUsernameValidationPresent() //Manejo de errores
        { return userNameError.Displayed; }

        public bool IsLoginValidationPresent() //Manejo de errores
        { return loginValidation.Displayed; }

        public HomePage Login(string mail, string pass)
        {
            SetEmail(mail);
            SetPassword(pass);
            ClickLogingButton();
            return new HomePage(this.driver);
        }
    }
}
