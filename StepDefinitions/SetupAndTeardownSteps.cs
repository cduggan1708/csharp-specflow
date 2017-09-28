using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using CSharpSpecflow.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CSharpSpecflow.StepDefinitions
{
    [Binding]
    class SetupAndTeardownSteps
    {

        private static IWebDriver driver;
        private static ExtentTest extentTest;
        private static ExtentReports extentReports;
        private static string browser;
        private static string remoteDriverUrl;
        private static string emulatorVersion;
        private static string apkPath;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            extentReports = new ExtentReports();

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(Constants.ReportingFolder + "TestResultsExtentReport.html");

            htmlReporter.Configuration().Theme = Theme.Dark;

            extentReports.AttachReporter(htmlReporter);
        }

        [BeforeTestRun]
        public static void InitializeCommandLineParameters()
        {
            browser = TestContext.Parameters.Get("browser", Constants.Chrome);
            remoteDriverUrl = TestContext.Parameters.Get("remoteDriverUrl", "http://127.0.0.1:4723/wd/hub");
            emulatorVersion = TestContext.Parameters.Get("emulatorVersion");
            apkPath = TestContext.Parameters.Get("apkPath", "C:\\Users\\cduggan\\Downloads\\Calculator_2.0.apk");
        }

        [BeforeFeature]
        public static void InitializeFeatureReport()
        {
            extentTest = extentReports.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeFeature("web")]
        public static void BeforeWebFeatureStep()
        {
            driver = DriverHelper.GetWebDriver(browser);

            // driver is accessible from FeatureContext
            FeatureContext.Current.Set<IWebDriver>(driver);
        }

        [BeforeFeature("mobile")]
        public static void BeforeMobileFeatureStep()
        {
            driver = DriverHelper.GetAndroidDriver(remoteDriverUrl, emulatorVersion, apkPath);

            // driver is accessible from FeatureContext
            FeatureContext.Current.Set<IWebDriver>(driver);
        }

        [BeforeScenario]
        public static void InitializeReportTest()
        {
            ExtentTest scenario = extentTest.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

            ScenarioContext.Current.Set<ExtentTest>(scenario);
        }

        [AfterStep]
        public static void LogCurrentStep()
        {
            if (ScenarioContext.Current.TestError == null)
            {
                ScenarioContext.Current.Get<ExtentTest>().CreateNode(new GherkinKeyword(ScenarioContext.Current.StepContext.StepInfo.StepDefinitionType.ToString()), ScenarioContext.Current.StepContext.StepInfo.Text).Pass("pass");
            }
            else
            {
                ScenarioContext.Current.Get<ExtentTest>().CreateNode(new GherkinKeyword(ScenarioContext.Current.StepContext.StepInfo.StepDefinitionType.ToString()), ScenarioContext.Current.StepContext.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingHelper.CreateScreenshot(driver)).Build());
            }
        }

        [AfterScenario]
        public static void WrapUpReport()
        {
            ScenarioContext.Current.Clear();
        }

        [AfterFeature]
        public static void AfterFeatureStep()
        {
            driver.Quit();
            FeatureContext.Current.Clear();
        }

        [AfterTestRun]
        public static void CleanUpReport()
        {
            extentReports.Flush();
        }
    }
}
