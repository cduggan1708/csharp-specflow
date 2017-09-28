using CSharpSpecflow.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace CSharpSpecflow.PageObjects
{
    class BasePageObject
    { 
        private IWebDriver driver;

        public BasePageObject()
        {
            driver = FeatureContext.Current.Get<IWebDriver>();
        }

        public void GoToUrl(String url)
        {
            if (!driver.Url.Equals(url)) { 
               driver.Navigate().GoToUrl(url);
            }
        }

        public IWebElement GetElement(By identifier)
        {
            return WaitUntil(ExpectedConditions.ElementIsVisible(identifier));
        }

        public IWebElement GetClickableElement(By identifier)
        {
            return WaitUntil(ExpectedConditions.ElementToBeClickable(identifier));
        }

        public string GetElementValue(By identifier)
        {
            return GetElement(identifier).GetAttribute("value");
        }

        public string GetElementText(By identifier)
        {
            return GetElement(identifier).Text.Trim();
        }

        public void HoverOverElement(By identifier)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(GetElement(identifier)).Perform();
        }

        public void SelectOptionFromDropdown(By identifier, string optionToSelectText)
        {
            SelectElement selectElement = new SelectElement(GetElement(identifier));
            selectElement.SelectByText(optionToSelectText);
        }

        protected IWebElement WaitUntil(Func<IWebDriver, IWebElement> expectedCondition)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.DefaultTimeout)).Until(expectedCondition);
        }

        protected bool WaitUntil(Func<IWebDriver, bool> expectedCondition)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.DefaultTimeout)).Until(expectedCondition);
        }
    }
}
