**Introduction**
We use Specflow 3+ in this project to run automated tests and Selenium.

**Requirements**
Please install the following:

- Visual Studio 2017
- SpecRun.SpecFlow-3.0.0+ and SpecFlow.MsTest
- Selenium

**Feature files**
Make sure that when you add feature files, you remove the references to them in the csproj. See "Adding Feature Files" in https://specflow.org/2018/specflow-3-public-preview-now-available/ 

Note that we use MsTest because xUnit not allow to add attachment in test output at the moment.
