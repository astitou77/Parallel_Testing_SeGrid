# Selenium C# webdriver API

## 1. INSTALL

### 1.1 INSTALL .NET SDK
```bash
> https://dotnet.microsoft.com/en-us/download       # DOWNLOAD & INSTALL .NET 8.0 (or 9.0...etc)
> dotnet --version                                  # VERSION : 8.0.410
```

### 1.2 Base Class Library (BCL) & .NET runtime

> REFERENCE: https://learn.microsoft.com/en-us/dotnet/api/

```bash
> dotnet --list-runtimes                            # Microsoft.NETCore.App 8.0.16 & 6.0.36

    Microsoft.NETCore.App 8.0.16    [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]

        System.Private.CoreLib.dll
        System.Runtime.dll
        System.Console.dll
        System.Collections.dll
        System.Linq.dll
        System.Net.Http.dll
        ...
            > using System;
            > using System.Collections.Generic;
            > using System.IO;
            > using System.Threading;
            > using System.Net;
            ...

    Microsoft.AspNetCore.App 8.0.16 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]

        Microsoft.AspNetCore.Mvc.Core.dll
        Microsoft.AspNetCore.Http.dll
        Microsoft.AspNetCore.Routing.dll
        Microsoft.Extensions.Logging.dll
        ...
            > using Microsoft.AspNetCore
            > using Microsoft.AspNetCore.Mvc
            > using Microsoft.AspNetCore.Http
            > using Microsoft.AspNetCore.Builder
            > using Microsoft.Extensions.DependencyInjection
            ...

```

### 1.3 Install NuGet PACKAGES & NAMESPACE

> NuGet repository : https://www.nuget.org/

```bash
> dotnet list package                           # list currently installed packages

> dotnet search <package-name>                  # search for a package by name
> dotnet search Selenium                        # search Selenium.WebDriver package

> dotnet add package <package-name>             # install NuGet package

> dotnet add package Selenium.WebDriver
    > using OpenQA.Selenium.Chrome;             # Chrome, Firefox, Edge
    > using OpenQA.Selenium.Support.UI;         # WebDriver support classes (e.g.: WebDriverWait, SelectElement)
> dotnet add package NUnit
    > using NUnit.Framework; 

> dotnet remove package <package-name>
> dotnet remove package NUnit



NuGet Package                                   C# Namespace                       Comment
------------------------------------------------------------------------------------------------------------

> using NUnit.Framework;                      // NUnit core attributes and assertions

Selenium.WebDriver
> dotnet add package Selenium.WebDriver     > using OpenQA.Selenium;        // Selenium WebDriver core : IWebDriver, By, IWebElement...etc
                                            > using OpenQA.Selenium.Chrome;               // Chrome-specific WebDriver
                                            > using OpenQA.Selenium.Firefox
                                            > using OpenQA.Selenium.Edge
                                            > using OpenQA.Selenium.Support.UI;           // WebDriver support classes (e.g., WebDriverWait, SelectElement)

> using System;                               // Basic .NET types
> using System.Threading;                     // For thread sleep or delays (not recommended for waits)

> using Selenium.WebDriver.ChromeDriver
> using Selenium.Support.Expected
```


## 2. IMPLEMENT

### 2.1 CREATE PROJECT
```bash
/MySolution
│
├── MySolution.sln                  # Solution file
│
├── /MyApp                         # Class library project
│   ├── MyApp.csproj
│   └── Calculator.cs              # Example class
│
├── /MyApp.Tests                   # NUnit test project
│   ├── MyApp.Tests.csproj
│   ├── CalculatorTests.cs         # NUnit test class
│   └── TestHelpers.cs             # Optional: shared test utilities
```


```bash
> dotnet new list                                   # list available project templates
> dotnet new console -n SeleniumGridTests           # create project
> cd SeleniumGridTests

> dotnet new sln -n MySolution
```

### 2.1 PROJECT NAMESPACE

> REFERENCE: https://www.geeksforgeeks.org/c-sharp/automation-using-selenium-in-c-sharp-with-example/

```bash
> namespace MyApp.GUI;		    using MyApp.GUI;		# var one = MyApp.GUI.MyClass();
> namespace MyApp.DB;			using MyApp.DB;			# var two = MyApp.DB.MyClass();
> namespace MyApp.Logging;	    using MyApp.Logging;	# var three = MyApp.Logging.MyClass();
```

### 2.2 NUnit FRAMEWORK TEST ATTRIBUTES
```bash
# NUnit : entry point is identified by the 'NUnit Test Runner' using attributes NOT by a 'main()' method
# NUnit Test ATTRIBUTES
[SetUpFixture]			# marks a (global) CLASS to define setup/teardown for entire NAMESPACE or ASSEMBLY
	[TestFixture]			# <--- marks a CLASS that contains NUnit tests
		[OneTimeSetUp]			# marks a METHOD to run ONCE BEFORE any tests in the fixture. For expensive setup.
			(Constructor)           # create the CLASS object/instance
			[SetUp]					# marks a METHOD to run BEFORE each test. To initialize the test context.	
				[Test]					# <--- marks a METHOD to be run by the test runner
				[TestCase]				# <--- marks a METHOD for multiple runs using different sets of inputs/parameters.
			[TearDown]				# marks a METHOD to run AFTER each test. To clean up resources.
		[OneTimeTearDown]		# marks a METHOD to run ONCE AFTER any tests in the fixture. For expensive cleanup.

                [Ignore]				# skip a test of test fixture. Can include a reason.
                [Category]				# GROUP tests under a category for filtering.
                [Obsolete]				# marks code as obsolete - compiler shows warning
                [Serializable]			# 
                [NonSerialized]	
```


### 2.3 webdriver [ IWebDriver vs. RemoteWebDriver vs. ChromeWebdriver ]
```bash
>> var options = new ChromeOptions();
>>
>> options.AddArgument("start-maximized"); 
>> options.AddArgument("--disable-gpu"); // Disable GPU acceleration
>> options.AddArgument("--no-sandbox"); // Bypass OS security model
>> options.AddArgument("--disable-dev-shm-usage"); // Overcome limited resource problems
>> options.AddArgument("--headless"); // Run in headless mode (optional)
>>
>> driver = new RemoteWebDriver(
>>     new Uri("http://localhost:4444/wd/hub"),
>>     options.ToCapabilities(),
>>     TimeSpan.FromSeconds(60));
```

### 2.4 locators [Locate Element by...]

### 2.5 actions [scroll, click, input...]

### 2.6 checks [ Assert. ]


## 3. RUN

```bash
# Clean, and build the project
> dotnet clean
> dotnet recover
> dotnet build

> dotnet run                            # does not work for NUnit projects ; no main()

# list available test
> dotnet test -t                        # VisitGoogle, VisitMicrosoft, VisitCanada

# run specific test
> dotnet test --filter <TestName>       # VisitCanada
```


## 4. PERFORMANCE

> PERFORMANCE :

```bash
# 1. TRACE PERFORMANCE : 
> dotnet tool install --global dotnet-trace
> dotnet-trace collect -p <PID> --duration 00:00:10 --format speedscope

# Visualize results in :
# [A] https://www.speedscope.app/ or 
# [B] Google Chrome's --->  chrome://tracing


# 2. ANALYZE .NET DUMPS :
dotnet tool install --global dotnet-symbol
dotnet-symbol --symbols --modules --debugging <dump-file-path>

# Analyze .NET dumps with : 
# [A] lldb or dotnet-dump
# [B] https://learn.microsoft.com/en-us/dotnet/core/diagnostics/dotnet-symbol
```