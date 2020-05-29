using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace xUnitCrossBrowser.Helpers
{
    public class CreateBrowser
    {

        private readonly DriverSetUp driverSetUp;

        public CreateBrowser()
        {
            driverSetUp = new DriverSetUp();
        }

        public IWebDriver GetDriver(string browserName, string version)
        {
            browserName = browserName + version;

            IWebDriver driver = null;
            ChromeOptions chromeOpt;
            FirefoxOptions firefoxOpt;

            switch (browserName)
            {
                
                case "Chrome81":
                    chromeOpt = new ChromeOptions();
                    chromeOpt.BrowserVersion = "81.0.4044.92";
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOpt.ToCapabilities(), TimeSpan.FromSeconds(120));
                    break;

                case "Chrome75":
                    chromeOpt = new ChromeOptions();
                    chromeOpt.BrowserVersion = "75.0.3770.80";
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOpt.ToCapabilities(), TimeSpan.FromSeconds(120));
                    break;
                
                case "Firefox75":
                    firefoxOpt = new FirefoxOptions();
                    firefoxOpt.BrowserVersion = "75.0";
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), firefoxOpt.ToCapabilities(), TimeSpan.FromSeconds(120));
                    break;

                default:
                    throw new Exception("Browser specification not found!");
            }

            driver.Manage().Window.Maximize();
            return driver;
        }

    }
}
