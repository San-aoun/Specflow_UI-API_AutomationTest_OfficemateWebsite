using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium.Chrome;

using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OfficeMate.E2E.Configuration;

namespace OfficeMate.E2E.Common
{
    public class WebDriverSessionManager
    {
        private ChromeDriver _driver;
        public ChromeDriver GetChrome()
        {
            if (_driver == null)
            {
                var envChromeWebDriver = Environment.GetEnvironmentVariable("ChromeWebDriver");
                var options = new ChromeOptions
                {
                    Proxy = null,
                };
                //options.AddArguments("--headless", "--disable-gpu");
                //options.AddArgument("auto-open-devtools-for-tabs");

                if (!string.IsNullOrEmpty(envChromeWebDriver) && File.Exists(Path.Combine(envChromeWebDriver, "chromedriver.exe")))
                {
                    _driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(envChromeWebDriver), options, TimeSpan.FromMinutes(3.0)); // Use agent built-in
                }
                else
                {
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3.0)); // Download latest version
                }
            }
            return _driver;
        }
        //public ChromeDriver GoToUrl(ChromeDriver driver)
        //{
        //    var uri = new Uri($"{Settings.WebUrl}");

        //    driver.Manage().Window.Maximize();
        //    driver.Navigate().GoToUrl(uri);

        //    Console.WriteLine("Goto uri" + uri);
        //}
    }
}
