using OpenQA.Selenium;
using System;
using Xunit;
using xUnitCrossBrowser.Helpers;

namespace xUnitCrossBrowser.ClassData
{
    public class TestReturnString : IDisposable
    {
        private IWebDriver driver;
        private readonly CreateBrowser browser;

        public TestReturnString()
        {
            browser = new CreateBrowser();
        }

        [Theory]
        [ClassData(typeof(DataGeneratorString))]
        public void ClassDataStringTest(string browserName, string version)
        {
            driver = browser.GetDriver(browserName, version);

            driver.Navigate().GoToUrl("https://www.whatismybrowser.com/");
            IWebElement browserNameDiv = driver.FindElement(By.ClassName("string-major"));

            Assert.Contains(browserName, browserNameDiv.Text);
            Assert.Contains(version, browserNameDiv.Text);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
