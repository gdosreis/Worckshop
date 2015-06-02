using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    public class SearchResultPage : DxBasePage
    {
        [FindsBy(How = How.Id, Using = "content_plHaveProducts")]
        protected IWebElement ResultTable;

        [FindsBy(How = How.Id, Using = "J_Filter")]
        protected IWebElement filters;

        public SearchResultPage(IWebDriver driver) : base(driver) { }

        //Method to verify if be in Search Result Page
        public bool BeInSearchResultPage()
        {
            return ResultTable.Displayed && ResultTable.Enabled && filters.Displayed && filters.Enabled;
        }
    }
}
