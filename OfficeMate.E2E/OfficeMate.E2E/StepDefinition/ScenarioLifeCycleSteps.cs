using System;

using OfficeMate.E2E.Common;
using OfficeMate.E2E.Configuration;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//div[5]/iframe")));
            driver.ExecuteScript("$('.fa.fa-times.element-close-button').click()");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            var driver = _webDriverSessionMenager.GetChrome();
            driver.Close();
            driver.Quit();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureContext.FeatureContainer.RegisterFactoryAs((objectContainer) 
                => _webDriverSessionMenager.GetChrome());
            Console.WriteLine("BeforeFeature");
        }

        [AfterScenario]
        public void ScreenshotTestError()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                OpenQA.Selenium.ITakesScreenshot screenshotDriver = ChromeDriver;
                OpenQA.Selenium.Screenshot screenshot = screenshotDriver.GetScreenshot();
                string title = ScenarioContext.Current.ScenarioInfo.Title;
                string Runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");

                string folder = Directory.CreateDirectory(Environment.CurrentDirectory + @"\ScreenShot_TestError").ToString();
                string path = Path.Combine(Environment.CurrentDirectory, folder, Runname + ".png");


                screenshot.SaveAsFile(path, OpenQA.Selenium.ScreenshotImageFormat.Png);

            }

        }
    }
}
