using NUnit.Framework;
using nUnitCrossBrowser.Helpers;
using OpenQA.Selenium;

namespace nUnitCrossBrowser
{
    [TestFixture("Chrome", "81")]
    [TestFixture("Chrome", "75")]
    [TestFixture("Firefox", "75")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Tests
    {

        private readonly string browserName;
        private readonly string version;
        private readonly CreateBrowser browser;
        private IWebDriver driver;

        public Tests(string browserName, string version)
        {
            this.browserName = browserName;
            this.version = version;
            browser = new CreateBrowser();
        }

        [SetUp]
        public void Setup()
        {
            driver = browser.GetDriver(browserName, version);
            driver.Navigate().GoToUrl("https://www.whatismybrowser.com/");
        }

        [Test]
        public void Test1()
        {
            IWebElement browserNameDiv = driver.FindElement(By.ClassName("string-major"));

            Assert.That(browserNameDiv.Text.Contains(browserName), "The Browser Name was not correct!");
            Assert.That(browserNameDiv.Text.Contains(version), "The version was not correct!");
        }

        [Test]
        public void Test2()
        {
            IWebElement browserNameDiv = driver.FindElement(By.ClassName("string-major"));

            Assert.That(browserNameDiv.Text.Contains(browserName), "The Browser Name was not correct!");
            Assert.That(browserNameDiv.Text.Contains(version), "The version was not correct!");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}