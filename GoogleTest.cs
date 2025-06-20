using SeleniumGridTest;

[TestFixture, Parallelizable(ParallelScope.Self)]
public class GoogleTest : BaseTest
{
    [Test]
    public void VisitGoogle()
    {
        driver!.Navigate().GoToUrl("https://www.google.com");
        Console.WriteLine($"Title: {driver.Title}");
        Thread.Sleep(40000); // 40 sec
    }
}
