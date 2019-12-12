# National Careers Service - UI Automation Framework
This is a SpecFlow-Selenium functional testing framework created using Selenium WebDriver with NUnit and C# in SpecFlow BDD methodology and Page Object Pattern.

## Prerequisites to run the application:
* **Visual Studio (2017 with V15.9 or higher)** Please check and upgrade your IDE if this is not the case.
* **Dot Net Core 2.2** Download appropriate 'Dot Net Core 2.2' version matching Visual Studio version. NOTE: If you have been using .NET Framework so far, you might not have this installed in your computer at the moment.
* Browsers (Chrome, Firefox, IE)

#### Set Up:
All other dependencies (ex: Selenium, drivers etc) are packaged within the solution using NuGet package manager. Once the solution is imported and built all the dependencies will be available within the solution.

Note: This framework is built with all standard libraries and ready to write new tests. However solution, project & namespace must be renamed before writing tests.

## Automated SpecFlow Tests:
Acceptance Tests must be written in Feature files (Project/Tests/Features/) using standard Gherkin language using Given, When, Then format with an associated step definition for each test step. Test steps in the scenarios explains the business conditions/behaviour and the associated step definition defines how the individual scenario steps should be automated.

A tag must be provided (ex: @Regression, @Smoke) for each test scenario which groups the tests, this provides the option to select which group of tests to execute. @Regression and @ tags are manadatory.

### Running Tests:
Once the solution is imported and built, open Test Explorer window (Test->Windows->Test Explorer) which shows all the tests generated from the feature files using the scenario titles.

To execute tests on different browsers, below are a list of settings you can use against the Browser key to launch the tests. 

**Local:**
* "local" (will execute in chrome) 
* "chrome" or "googlechrome"
* "firefox" or "mozillafirefox"
* "ie" or "internetexplorer"

**BrowserStack:**
* "browserstack" or "cloud"

Note - Ensure you enter the browserstack username and key to the appsettings

**Zap Proxy:**
* "zapProxyChrome"

**Command Prompt:**

Running Tests from Command Prompt:
c:\> dotnet test C:\SFA\DFE-Standardised-Test-Automation-Framework\src\ESFA.UI.Specflow.TestProject\ESFA.UI.Specflow.TestProject.csproj --filter "TestCategory=regression|TestCategory=anotherregression"

c:\> dotnet vstest C:\SFA\DFE-Standardised-Test-Automation-Framework\src\SFA.DAS.PocProject.UITests\SFA.DAS.PocProject.UITests.dll /TestCaseFilter:"TestCategory=regression|FullyQualifiedName=Namespace.ClassName.MethodName"

## Standards/Rules:
* The framework is designed using Page Object Model
* Each test must be independent of other tests
* Where possible create the users/data on runtime and clear the users/data at the end of the tests
* Every Page class must extend BasePage (Project/Tests/TestSupport/BasePage) and implement the methods from it, which initiate the elements and waits for the page to load and verifies the current page
* Every class must implement single responsible principle. Where:
     * **a.** Every Page class is responsible for only one web page and identifying the elements within the page and implementing methods a user can do on that page 
     * **b.** Every Test Class is responsible to access the methods from Page Classes and execute the test steps with required data 
     * **c.** Helper classes are just responsible for assisting the user with reusable methods to easily interact with the web page, Database and API.

### Helpers

The framework has the following helper classes to assist the testing (Project/Framework/Helpers/)

* FormCompletionHelper - Which helps most of the user actions on a page
* PageInteractionHelper - Helps verifying data and elements on the page
* RandomDataGenerator - Helps creating random data to use
* HttpClientRequestHelper - Helps making some HTTP requests (POST, PUT, GET, DELETE, PATCH)
* SqlDatabaseConnectionHelper - Helps connecting to the SQL Database to read and write the data from Database
* CosmosActionPerformerHelper - Helps connecting to Cosmos DB to read and write the data
* CosmosConnectionHelper - Provides assistance to CosmosActionPerformerHelper by creating DocumentClient and DocumentRepository
### Selenium best practices:
* Use PageObject pattern
* Preferred selector order: id > name > css > xpath
* Avoid Thread.sleep prefer WebDriverWaits
* Create your data set
* Tests must be independent from other tests
* Don't use static user/data, create a user/data for every test and delete the user/data after the test is completed

## Parallel Test Execution:

This framework supports Feature Level parallelization (tests under different feature file will run in parallel) not Scenario Level parallelization (tests under same feature file will not execute in parallel).

No of Threads in parallel test execution
If LevelOfParallelism is not specified, workers defaults to the number of processors on the machine, or 2, whichever is greater.

You can specify no of threads to use in the parameter : [assembly: LevelOfParallelism(2)]

You can specify 0 to exeute tests in sequential order : [assembly: LevelOfParallelism(0)]

