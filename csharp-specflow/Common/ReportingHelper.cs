using OpenQA.Selenium;
using System;

namespace CSharpSpecflow.Common
{
    class ReportingHelper
    {
        public static string CreateScreenshot(IWebDriver driver)
        {
            string uuid = Guid.NewGuid().ToString();
            string fileName = Constants.ReportingImagesFolder + uuid + ".png";

            Screenshot screen = ((ITakesScreenshot)driver).GetScreenshot();
            screen.SaveAsFile(fileName, ScreenshotImageFormat.Png);

            return fileName;
        }
    }
}
