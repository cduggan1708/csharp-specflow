using CSharpSpecflow.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpSpecflow.PageObjects
{
    class GenericPageObject : BasePageObject
    {
        
        public void GoToGoogleLandingPage()
        {
            GoToUrl(Constants.GoogleLandingPage);
            WaitUntil(ExpectedConditions.ElementIsVisible(By.Id(Constants.GoogleLandingPageLoadedId)));
        }

        public void GoToMortgageCalculator()
        {
            GoToUrl(Constants.MortgageCalculator);
            WaitUntil(ExpectedConditions.ElementIsVisible(By.Id(Constants.MortgageCalculatorLoadedId)));
        }

        public void EnterTextInTheTextFieldByWithSelector(string text, string by, string selector, bool clearField)
        {
            IWebElement element = GetElement(GetSelector(by, selector));
            if (clearField) element.Clear();
            element.SendKeys(text);
        }

        public void ClickElementByWithSelector(string by, string selector)
        {
            IWebElement element = GetClickableElement(GetSelector(by, selector));
            element.Click();
        }

        public bool VerifyDirectedToPageByWithSelector(string by, string selector)
        {
            IWebElement element = GetElement(GetSelector(by, selector));
            return (element != null);
        }

        public string GetValueOfElementByWithSelector(string by, string selector)
        {
            return GetElementValue(GetSelector(by, selector));
        }

        public string GetTextOfElementByWithSelector(string by, string selector)
        {
            return GetElementText(GetSelector(by, selector));
        }

        public void HoverOverElementByWithSelector(string by, string selector)
        {
            HoverOverElement(GetSelector(by, selector));
        }

        public void SelectOptionFromDropdownByWithSelector(string optionToSelect, string by, string selector)
        {
            SelectOptionFromDropdown(GetSelector(by, selector), optionToSelect);
        }

        private By GetSelector(string by, string selector)
        {
            By ret = null;

            switch (by.ToLower())
            {
                case "id":
                    ret = By.Id(selector);
                    break;
                case "name":
                    ret = By.Name(selector);
                    break;
                case "cssselector":
                    ret = By.CssSelector(selector);
                    break;
                case "xpath":
                    ret = By.XPath(selector);
                    break;
            }

            return ret;
        }
    }
}
