using OpenQA.Selenium;
using System;

namespace CSharpSpecflow.Common
{
    class ReportingHelper
    {
        public static string CreateScreenshot(IWebDriver driver)
        {
            string uuid = Guid.NewGuid().ToString();
            string fileNameRelative = Constants.ReportingImagesFolder + uuid + ".png";
            string fileName = Constants.ReportingFolder + fileNameRelative;

            Screenshot screen = ((ITakesScreenshot)driver).GetScreenshot();
            screen.SaveAsFile(fileName, ScreenshotImageFormat.Png);

            return fileNameRelative;
        }
    }
}
