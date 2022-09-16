using OfficeMate.E2E.StepDefinition;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using TechTalk.SpecFlow;

namespace OfficeMate.E2E.Helper
{
    public class WebElementExtension : BaseWebdriverStep
    {
        public WebElementExtension(FeatureContext featureContext) : base(featureContext) { }
        public void ClickElementByID(string btnId)
        {
            Wait(1.0)
            .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
            .ElementIsVisible(By.Id(btnId)));

            ChromeDriver.FindElement(By.Id(btnId)).Click();
        }
    }
}
