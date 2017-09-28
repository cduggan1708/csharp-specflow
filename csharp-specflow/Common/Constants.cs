using OpenQA.Selenium;

namespace CSharpSpecflow.Common
{
    class Constants
    {
        public const string Chrome = "chrome";
        public const string Firefox = "firefox";
        public const string Ie = "ie";
        public const string GoogleLandingPage = @"http://www.google.com";
        public const string GoogleLandingPageLoadedId = "lst-ib";
        public const string MortgageCalculator = @"https://www.mortgagecalculator.net/";
        public const string MortgageCalculatorLoadedId = "mortageCalculatorForm";
        public const int DefaultTimeout = 20;
        public const string ReportingFolder = @"C:\Source\Reports\";
        public const string ReportingImagesFolder = ReportingFolder + @"images\";
    }
}