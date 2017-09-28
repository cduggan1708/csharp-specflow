using AventStack.ExtentReports;
using CSharpSpecflow.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CSharpSpecflow.StepDefinitions
{
    [Binding]
    class GenericStepDefinitions
    {
        private GenericPageObject page;

        // GIVEN 

        [Given(@"I am a user on Google")]
        public void GivenIAmAUserOnGoogle()
        {
            page = new GenericPageObject();
            page.GoToGoogleLandingPage();
        }

        [Given(@"I am a user on Mortgage Calculator site")]
        public void GivenIAmAUserOnMortgageCalculatorSite()
        {
            page = new GenericPageObject();
            page.GoToMortgageCalculator();
        }

        [Given(@"I am a user on the Calculator app")]
        public void GivenIAmAUserOnTheCalculatorApp()
        {
            page = new GenericPageObject();
        }

        // WHEN

        [When(@"I enter text ""(.*)"" in the text field ""(.*)"" by ""(.*)"" with selector ""(.*)""")]
        public void WhenIEnterTextInTheTextFieldByWithSelector(string text, string fieldName, string by, string selector)
        {
            page.EnterTextInTheTextFieldByWithSelector(text, by, selector, true);
        }

        [When(@"I hit Enter by ""(.*)"" with selector ""(.*)""")]
        public void WhenIHitEnterByWithSelector(string by, string selector)
        {
            page.EnterTextInTheTextFieldByWithSelector("\n", by, selector, false);
        }

        [When(@"I click ""(.*)"" by ""(.*)"" with selector ""(.*)""")]
        public void WhenIClickElementByWithSelector(string buttonName, string by, string selector)
        {
            page.ClickElementByWithSelector(by, selector);
        }

        [When(@"I hover over ""(.*)"" by ""(.*)"" with selector ""(.*)""")]
        public void WhenIHoverOverByWithSelector(string elementName, string by, string selector)
        {
            page.HoverOverElementByWithSelector(by, selector);
        }

        [When(@"I select option ""(.*)"" from dropdown ""(.*)"" by ""(.*)"" with selector ""(.*)""")]
        public void WhenISelectOptionFromDropdownByWithSelector(string optionToSelect, string dropdownName, string by, string selector)
        {
            page.SelectOptionFromDropdownByWithSelector(optionToSelect, by, selector);
        }

        // THEN

        [Then(@"I should be directed to ""(.*)"" page by ""(.*)"" with selector ""(.*)""")]
        public void ThenIShouldBeDirectedToPageByWithSelector(string pageName, string by, string selector)
        {
            Assert.IsTrue(page.VerifyDirectedToPageByWithSelector(by, selector), string.Format("The expected page {0} was not redirected to", pageName));
        }

        [Then(@"I should see value ""(.*)"" in ""(.*)"" field by ""(.*)"" with selector ""(.*)""")]
        public void ThenIShouldSeeValueInFieldByWithSelector(string expectedValue, string fieldName, string by, string selector)
        {
            Assert.AreEqual(expectedValue, page.GetValueOfElementByWithSelector(by, selector), string.Format("The expected value [{0}] was not found in the [{1}] field", expectedValue, fieldName));
        }

        [Then(@"I should see ""(.*)"" with text ""(.*)"" by ""(.*)"" with selector ""(.*)""")]
        public void ThenIShouldSeeElementWithTextByWithSelector(string elementName, string expectedText, string by, string selector)
        {
            Assert.AreEqual(expectedText, page.GetTextOfElementByWithSelector(by, selector), string.Format("The expected text [{0}] was not found in the [{1}] element", expectedText, elementName));
        }

    }
}
