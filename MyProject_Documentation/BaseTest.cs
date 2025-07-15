using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace SeleniumGridTest
{
    public abstract class BaseTest
    {
        protected IWebDriver? driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new RemoteWebDriver(
                new Uri("http://localhost:4444/wd/hub"),
                options.ToCapabilities(),
                TimeSpan.FromSeconds(60));
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
