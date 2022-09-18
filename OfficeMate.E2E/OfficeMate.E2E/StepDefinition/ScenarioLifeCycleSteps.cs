using OfficeMate.E2E.Common;
using OfficeMate.E2E.Configuration;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using SeleniumExtras.WaitHelpers;

using TechTalk.SpecFlow;

namespace OfficeMate.E2E.StepDefinition
{
    [Binding]
    public sealed class ScenarioLifeCycleSteps : BaseWebdriverStep
    {
        private static WebDriverSessionManager _webDriverSessionMenager;

        public ScenarioLifeCycleSteps(FeatureContext featureContext) : base(featureContext) { }

        [BeforeTestRun(Order = 0)]
        public static void BeforeTestRun()
        {
            _webDriverSessionMenager = new WebDriverSessionManager();
            var driver = _webDriverSessionMenager.GetChrome();

            GotoURL(driver);
            ClearAbsScreen(driver);

            Console.WriteLine("BeforeTestRun");
        }

        private static void GotoURL(ChromeDriver driver)
        {
            var uri = new Uri($"{Settings.WebUrl}");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(uri);

            Console.WriteLine("Goto uri" + uri);
        }

        private static void ClearAbsScreen(ChromeDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.sp-fancybox-wrap > iframe")));
            Thread.Sleep(2000);
            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("div.sp-fancybox-wrap > iframe")));
            driver.FindElement(By.CssSelector(".fa.fa-times.element-close-button")).Click();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            var driver = _webDriverSessionMenager.GetChrome();
            driver.Quit();
        }

        [BeforeFeature(Order = 0)]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureContext.FeatureContainer.RegisterFactoryAs((objectContainer) 
                => _webDriverSessionMenager.GetChrome());
            Console.WriteLine("BeforeFeature");
        }
    }
}
