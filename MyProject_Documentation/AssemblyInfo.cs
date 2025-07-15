using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(16)] // Set the maximum number of parallel test threads to 16

// [assembly: NonParallelizable] // Uncomment to disable parallel execution for all tests
/*
[assembly: Timeout(60000)] // Set a default timeout for tests to 60 seconds
[assembly: Category("SeleniumGridTests")]
[assembly: Description("Tests for Selenium Grid functionality using NUnit framework")]
[assembly: AssemblyTitle("SeleniumGridTests")]
[assembly: AssemblyDescription("A collection of tests for Selenium Grid using NUnit")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("YourCompanyName")]
[assembly: AssemblyProduct("SeleniumGridTests")]
[assembly: AssemblyCopyright("Copyright © YourCompanyName 2023")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
*/