using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace SeleniumTestDemo
{
    [TestFixture]
    public class SeleniumFeatureDemo
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void ComprehensiveTest()
        {
            // Navigation
            driver.Navigate().GoToUrl("https://example.com");
            /*
            // Element Locators
            var elementById = driver.FindElement(By.Id("elementId"));
            var elementByClass = driver.FindElement(By.ClassName("className"));
            var elementByXPath = driver.FindElement(By.XPath("//input[@name='q']"));
            var elementByCss = driver.FindElement(By.CssSelector(".search-box"));

            // Input & Submit
            elementById.SendKeys("Sample text");
            elementByCss.SendKeys(Keys.Enter);

            // Explicit Wait
            wait.Until(d => d.FindElement(By.Id("results")));

            // Assertions
            Assert.IsTrue(driver.Title.Contains("Example"));

            // Cookies
            driver.Manage().Cookies.AddCookie(new Cookie("test", "value"));

            // Alerts
            IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            alert.Accept();

            // Frames
            driver.SwitchTo().Frame("frameName");
            driver.FindElement(By.TagName("button")).Click();
            driver.SwitchTo().DefaultContent();

            // Multiple windows
            string originalWindow = driver.CurrentWindowHandle;
            driver.FindElement(By.LinkText("Open new tab")).Click();
            wait.Until(d => d.WindowHandles.Count == 2);
            foreach (string handle in driver.WindowHandles)
            {
                if (handle != originalWindow)
                {
                    driver.SwitchTo().Window(handle);
                    break;
                }
            }

            // Screenshot
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);

            */
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                // driver = null;
            }
        }
    }
}
