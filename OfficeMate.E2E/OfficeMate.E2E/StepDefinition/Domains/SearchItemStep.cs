using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace OfficeMate.E2E.StepDefinition.Domains
{
    [Binding]
    public class SearchItemStep : BaseWebdriverStep
    {
        public SearchItemStep(FeatureContext featureContext) : base(featureContext){ }

        [Given(@"the user seraches ""([^""]*)""")]
        [When(@"the user seraches ""([^""]*)""")]
        public void WhenTheUserTypes(string item)
        {
            WaitUntilPageLodingFinished();

            var searchBar = "input[data-testid='txt-SearchBar']";
            Wait(1.0)
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementIsVisible(By.CssSelector(searchBar)));

            ChromeDriver.FindElement(By.CssSelector(searchBar)).SendKeys(item);
            ChromeDriver.FindElement(By.Id("btn-searchResultPage")).Click();

        }

    }
}
