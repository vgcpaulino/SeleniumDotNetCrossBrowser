using OpenQA.Selenium;
using System;
using Xunit;
using xUnitCrossBrowser.Helpers;

namespace xUnitCrossBrowser.InLine
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
        [InlineData("Chrome", "81")]
        [InlineData("Chrome", "75")]
        [InlineData("Firefox", "75")]
        public void InLineTest1(string browserName, string version)
        {
            driver = browser.GetDriver(browserName, version);

            driver.Navigate().GoToUrl("https://www.whatismybrowser.com/");
            IWebElement browserNameDiv = driver.FindElement(By.ClassName("string-major"));

            Assert.Contains(browserName, browserNameDiv.Text);
            Assert.Contains(version, browserNameDiv.Text);
        }
        
        [Theory]
        [InlineData("Chrome", "81")]
        [InlineData("Chrome", "75")]
        [InlineData("Firefox", "75")]
        public void InLineTest2(string browserName, string version)
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
