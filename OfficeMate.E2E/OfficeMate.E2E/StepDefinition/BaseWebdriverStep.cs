using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using TechTalk.SpecFlow;

namespace OfficeMate.E2E.StepDefinition
{
    public abstract class BaseWebdriverStep : BaseStepDefinition
    {
        protected readonly ChromeDriver ChromeDriver;

        protected BaseWebdriverStep(FeatureContext featureContext) : base(featureContext)
        {
            ChromeDriver = featureContext.FeatureContainer.Resolve<ChromeDriver>();
        }

        protected WebDriverWait Wait(double durationInMinutes)
        {
            return new WebDriverWait(ChromeDriver, TimeSpan.FromMinutes(durationInMinutes));
        }

        protected void WaitloadStatusFinished(string status)
        {
            var wait = Wait(5.0);
            wait.Until(driver =>
            {
                RefreshPage();
                WaitUntilPageLodingFinished();
                var chrome = driver as ChromeDriver;
                var gridStatus = chrome.ExecuteScript("return $('.grid-status').text().trim()").ToString();
                return gridStatus != status;
            });
        }

        protected void WaitUntilPageLodingFinished()
        {
            var wait = Wait(3.0);
            wait.Until(driver =>
            {
                var chrome = driver as ChromeDriver;
                var checkLoad = int.Parse(chrome.ExecuteScript("return document.getElementsByClassName('material-loading-logo').length").ToString());
                return checkLoad == 0;
            });
        }

        protected void RefreshPage()
        {
            ChromeDriver.ExecuteScript("location.reload();");
        }

        protected void WaitUntilEmailNotFound()
        {
            var wait = Wait(3.0);
            wait.Until(driver =>
            {
                RefreshPage();
                WaitUntilPageLodingFinished();
                var chrome = driver as ChromeDriver;
                var emailNotFound = chrome.ExecuteScript("return $('#noEmails').text().trim()").ToString();
                return emailNotFound == "No emails found.";
            });
        }

        protected void WaiUntilEmailDeletedFinish()
        {
            var wait = Wait(3.0);
            wait.Until(driver =>
            {
                var chrome = driver as ChromeDriver;
                var deletedRow = int.Parse(chrome.ExecuteScript("return $('.deletedRow').length").ToString());
                return deletedRow != 0;
            });
        }
    }
}
