using SeleniumGridTest;

[TestFixture, Parallelizable(ParallelScope.Self)]
public class Test_Google : BaseTest
{
    private TestLogger? logger;

    [SetUp]
    public void InitLogger()
    {
        logger = new TestLogger(GetType().Name);
        logger.Log("Microsoft's Test is starting.");
    }

    [Test]
    public void VisitGoogle()
    {
        driver!.Navigate().GoToUrl("https://www.google.com");
        logger!.Log("Webpage title is: " + driver.Title);
        Thread.Sleep(40000); // 40 sec
    }

    [TearDown]
    public new void TearDown()
    {
        logger!.Log("Google's Test is closing.");
        base.TearDown();
    }
}
