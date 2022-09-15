using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace OfficeMate.E2E.StepDefinition.Domains
{
    [Binding]
    public class SearchItemStep : BaseWebdriverStep
    {
        public SearchItemStep(FeatureContext featureContext) : base(featureContext)
        { }

        [Given(@"Clear Abs screen")]
        public void GivenClearAbsScreen()
        {
            ChromeDriver.SwitchTo().Frame(ChromeDriver.FindElement(By.XPath("//div[5]/iframe")));
            ChromeDriver.ExecuteScript("$('.fa.fa-times.element-close-button').click()");
        }

        [When(@"the user seraches ""([^""]*)""")]
        public void WhenTheUserTypes(string item)
        {
            var searchBar = "//input[(data-testid='txt-SearchBar')]";
            Wait(1.0)
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementIsVisible(By.XPath(searchBar)));

            ChromeDriver.FindElement(By.XPath(searchBar)).SendKeys(item);

        }

    }
}
