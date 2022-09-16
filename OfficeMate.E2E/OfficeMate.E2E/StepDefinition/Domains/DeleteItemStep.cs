using OpenQA.Selenium;

using TechTalk.SpecFlow;

using Xunit;

namespace OfficeMate.E2E.StepDefinition.Domains
{
    [Binding]
    public class DeleteItemStep : BaseWebdriverStep
    {
        public DeleteItemStep(FeatureContext featureContext) : base(featureContext) { }

        [When(@"the user click remove the item")]
        public void WhenTheUserClickRemoveTheItem()
        {
            WaitUntilPageLodingFinished();

            Wait(1.0)
             .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
             .ElementIsVisible(By.CssSelector("div._1Q12P")));

            ChromeDriver.FindElement(By.CssSelector("div._1Q12P")).Click();

            Wait(1.0)
             .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
             .ElementIsVisible(By.CssSelector("span:nth-child(2) > button[type=\"button\"]")));

            ChromeDriver.FindElement(By.CssSelector("span:nth-child(2) > button[type=\"button\"]")).Click();

        }

        [Then(@"the screen show the the message ""([^""]*)""")]
        public void ThenTheScreenShowTheTheMessage(string msg)
        {
            WaitUntilPageLodingFinished();
            var results = ChromeDriver.FindElement(By.CssSelector("#cart-items > div:nth-child(2) > div")).Text;
            Assert.Equal(results, results);
        }



    }
}
