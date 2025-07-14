using SeleniumGridTest;

[TestFixture, Parallelizable(ParallelScope.Self)]
public class Test_Microsoft : BaseTest
{
    private TestLogger? logger;

    [SetUp]
    public void InitLogger()
    {
        logger = new TestLogger(GetType().Name);
        logger.Log("Microsoft's Test is starting.");
    }

    [Test]
    public void VisitMicrosoft()
    {
        driver!.Navigate().GoToUrl("https://www.microsoft.com");
        logger!.Log("Webpage title is: " + driver.Title);
        Thread.Sleep(20000);
    }

    [TearDown]
    public new void TearDown()
    {
        logger!.Log("Microsoft's Test is closing.");
        base.TearDown();
    }
}
