using OpenQA.Selenium;

using TechTalk.SpecFlow;

using Xunit;

namespace OfficeMate.E2E.StepDefinition.Domains
{
    [Binding]
    public class SearchItemStep : BaseWebdriverStep
    {
        public SearchItemStep(FeatureContext featureContext) : base(featureContext)
        { }

        [When(@"the user seraches ""([^""]*)""")]
        public void WhenTheUserTypes(string item)
        {
            var searchBar = "input[data-testid='txt-SearchBar']";
            Wait(1.0)
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementIsVisible(By.CssSelector(searchBar)));

            ChromeDriver.FindElement(By.CssSelector(searchBar)).SendKeys(item);
            ChromeDriver.FindElement(By.Id("btn-searchResultPage")).Click();

        }

        [Then(@"Display should show subject with ""([^""]*)""")]
        public void ThenDisplayShouldShowSubjectWith(string item)
        {
            Wait(1.0)
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementIsVisible(By.CssSelector("div[data-testid='pnl-productGrid']")));
            var results = ChromeDriver.FindElement(By.CssSelector("a[data-product-section=\"" + item + "\"]")).Displayed;
            Assert.True(results);
        }


    }
}
