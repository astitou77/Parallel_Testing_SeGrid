using SeleniumGridTest;

[TestFixture, Parallelizable(ParallelScope.Self)]
public class MicrosoftTest : BaseTest
{
    [Test]
    public void VisitMicrosoft()
    {
        driver!.Navigate().GoToUrl("https://www.microsoft.com");
        Console.WriteLine($"Title: {driver.Title}");
        Thread.Sleep(20000); // 20 sec
    }
}
