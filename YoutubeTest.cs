using SeleniumGridTest;

[TestFixture, Parallelizable(ParallelScope.Self)]
public class YouTubeTest : BaseTest
{
    private TestLogger? logger;

    [SetUp]
    public void InitLogger()
    {
        logger = new TestLogger(nameof(MicrosoftTest));
        logger.Log("Youtube's Test is starting.");
    }

    [Test]
    public void VisitYouTube()
    {
        driver!.Navigate().GoToUrl("https://www.youtube.com");
        logger!.Log("Webpage title is: " + driver.Title);
        Thread.Sleep(60000); // 60 sec
    }

    [TearDown]
    public new void TearDown()
    {
        logger!.Log("Youtube's Test is closing.");
        base.TearDown();
    }
}
