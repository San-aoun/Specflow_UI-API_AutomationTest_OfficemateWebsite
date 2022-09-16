using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using TechTalk.SpecFlow;

using Xunit;

namespace OfficeMate.E2E.StepDefinition.Validation
{
    [Binding]
    public class BasicValidation : BaseWebdriverStep
    {
        public BasicValidation(FeatureContext featureContext) : base(featureContext) { }

        [Then(@"Display should show subject with ""([^""]*)""")]
        public void ThenDisplayShouldShowSubjectWith(string item)
        {
            Wait(1.0)
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementIsVisible(By.CssSelector("div[data-testid='pnl-productGrid']")));
            var results = ChromeDriver.FindElement(By.CssSelector("a[data-product-section=\"" + item + "\"]")).Displayed;
            Assert.True(results);
        }

        [Then(@"Display should not show subject with ""([^""]*)""")]
        public void ThenDisplayShouldNotShowSubjectWith(string item)
        {
            Wait(1.0)
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementIsVisible(By.CssSelector("div[data-testid='pnl-productGrid']")));
            var results = ChromeDriver.FindElement(By.CssSelector("a[data-product-section=\"" + item + "\"]")).Displayed;
            Assert.Null(results);
        }


        [Then(@"the process still being on the url is ""([^""]*)""")]
        public void ThenTheProcessStillBeingOnTheLink(string expectUrl)
        {
            var results = ChromeDriver.Url;
            Assert.Equal(results, expectUrl);

        }

    }
}
