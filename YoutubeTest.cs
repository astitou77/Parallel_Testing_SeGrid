using SeleniumGridTest;

[TestFixture, Parallelizable(ParallelScope.Self)]
public class YouTubeTest : BaseTest
{
    [Test]
    public void VisitYouTube()
    {
        driver!.Navigate().GoToUrl("https://www.youtube.com");
        Console.WriteLine($"Title: {driver.Title}");
        Thread.Sleep(60000); // 60 sec
    }
}
