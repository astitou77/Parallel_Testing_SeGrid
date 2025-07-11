using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumAdvancedDemo
{
    [TestFixture]
    public class FeatureRichTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("running [SetUp]...");

            var options = new ChromeOptions();
            options.AddArguments("start-maximized", "--disable-notifications"); // Disable notifications

            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void AdnaneTests()
        {
            Console.WriteLine("running [Test]...");

            /* [01] Navigate to a site :
            *
            * driver.Url = "https://the-internet.herokuapp.com/";
            * driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            * driver.Navigate().Refresh();
            *
            */
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            Thread.Sleep(3000); // Wait for the page to load


            /* [02] Find Elements :
            *
            * By.Id("username");
            * By.Name("password");
            * By.ClassName("example");
            * By.TagName("h2");
            * By.LinkText("Form Authentication");
            * By.PartialLinkText("Form");
            * By.CssSelector("h2");
            *
            * By.XPath("//h2[text()='Welcome to the-internet']");
            *
            */
            IWebElement formLink = driver.FindElement(By.LinkText("Form Authentication"));
            //IWebElement button = driver.FindElement(By.XPath("//form[@id='login']"));
            Thread.Sleep(3000);


            /* [03] Interact with Elements :
            *
            * Click();
            * SendKeys("password");
            * Clear();
            * Submit();
            *
            * GetAttribute("href");
            * GetCssValue("font-size");
            * GetLocation();
            * GetSize();
            * GetRect();
            *
            * GetTagName();     // <Div>, <Input>, <Button>, etc.
            * GetText();        // <?> Retrieve This Text <?/>
            *
            * IsDisplayed();
            * IsEnabled();      // Is the element enabled?
            * IsSelected();     // Is the element selected? (for checkboxes, radio buttons) 
            *
            */
            formLink.SendKeys("SuperSecretPassword!");
            button.Click();
            Thread.Sleep(3000); // Wait for the form to load



            /*
            // Assert login success
            var flash = driver.FindElement(By.Id("flash")).Text;
            Assert.IsTrue(flash.Contains("You logged into a secure area!"));

            // Hover over image
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/hovers");
            Actions actions = new Actions(driver);
            var avatar = driver.FindElement(By.ClassName("figure"));
            actions.MoveToElement(avatar).Perform();

            // Drag and drop
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/drag_and_drop");
            var source = driver.FindElement(By.Id("column-a"));
            var target = driver.FindElement(By.Id("column-b"));
            actions.DragAndDrop(source, target).Perform();

            // JavaScript alert
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.FindElement(By.XPath("//button[text()='Click for JS Alert']")).Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            // Notification message
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/notification_message_rendered");
            driver.FindElement(By.LinkText("Click here")).Click();
            var notification = driver.FindElement(By.Id("flash")).Text;
            Assert.IsTrue(notification.Contains("Action"));

            // Frame interaction
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/iframe");
            driver.SwitchTo().Frame("mce_0_ifr");
            var editor = driver.FindElement(By.Id("tinymce"));
            editor.Clear();
            editor.SendKeys("Hello from Selenium!");
            driver.SwitchTo().DefaultContent();

            // Multiple windows
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
            driver.FindElement(By.LinkText("Click Here")).Click();
            wait.Until(d => d.WindowHandles.Count == 2);
            var windows = driver.WindowHandles;
            driver.SwitchTo().Window(windows[1]);
            var header = driver.FindElement(By.TagName("h3")).Text;
            Assert.AreEqual("New Window", header);
            driver.Close();
            driver.SwitchTo().Window(windows[0]);
            */
            

            
            /* [04] Assertions :
            * Assert.IsTrue(condition);
            * Assert.IsFalse(condition);
            * Assert.AreEqual(expected, actual);
            * Assert.IsNull(object);
            * Assert.IsNotNull(object);
            * Assert.Throws<ExceptionType>(() => { Console.WriteLine("Test"); });
            * */
            // var flashMessage = driver.FindElement(By.Id("flash")).Text;
            // Assert.IsTrue(flashMessage.Contains("You logged into a secure area!"), "Login failed or flash message not found.");

            /* [05] Waits :
            * WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            * wait.Until(ExpectedConditions.ElementIsVisible(By.Id("elementId")));
            * wait.Until(d => d.FindElement(By.Id("elementId")).Displayed);
            * wait.Until(d => d.FindElement(By.Id("elementId")).Enabled);
            * wait.Until(d => d.FindElement(By.Id("elementId")).Text.Contains("text"));
            * */
            //wait.Until(ExpectedConditions.ElementIsVisible(By.Id("flash")));
            //wait.Until(d => d.FindElement(By.Id("flash")).Text.Contains("You logged into a secure area!"));
            //Thread.Sleep(3000); // Wait for the flash message to be visible

            /* [06] Cookies :
            * driver.Manage().Cookies.AddCookie(new Cookie("name", "value"));
            * driver.Manage().Cookies.DeleteCookieNamed("name");
            * driver.Manage().Cookies.DeleteAllCookies();
            * var cookies = driver.Manage().Cookies.AllCookies; 
            */
            //driver.Manage().Cookies.AddCookie(new Cookie("session", "123456"));
            //var allCookies = driver.Manage().Cookies.AllCookies;
            //Assert.IsTrue(allCookies.Count > 0, "No cookies found after adding a new cookie.");
            //driver.Manage().Cookies.DeleteCookieNamed("session");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}