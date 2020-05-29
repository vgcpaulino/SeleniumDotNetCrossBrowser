using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Xunit;
using xUnitCrossBrowser.Helpers;

namespace xUnitCrossBrowser.MemberData
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
        [MemberData(nameof(DataGeneratorString.GetDriversFromAnotherClass), MemberType = typeof(DataGeneratorString))]
        public void MemberDataTest1(string browserName, string version)
        {
            driver = browser.GetDriver(browserName, version);

            driver.Navigate().GoToUrl("https://www.whatismybrowser.com/");
            IWebElement browserNameDiv = driver.FindElement(By.ClassName("string-major"));

            Assert.Contains(browserName, browserNameDiv.Text);
            Assert.Contains(version, browserNameDiv.Text);
        }

        [Theory]
        [MemberData(nameof(GetDriversFromSameClass))]
        public void MemberDataTest2(string browserName, string version)
        {
            driver = browser.GetDriver(browserName, version);

            driver.Navigate().GoToUrl("https://www.whatismybrowser.com/");
            IWebElement browserNameDiv = driver.FindElement(By.ClassName("string-major"));

            Assert.Contains(browserName, browserNameDiv.Text);
            Assert.Contains(version, browserNameDiv.Text);
        }

        public static IEnumerable<object[]> GetDriversFromSameClass()
        {
            yield return new object[] { "Chrome", "81" };
            yield return new object[] { "Chrome", "75" };
            yield return new object[] { "Firefox", "75" };
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
