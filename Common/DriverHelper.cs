using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;

namespace CSharpSpecflow.Common
{
    class DriverHelper
    {
        public static IWebDriver GetWebDriver(string browser)
        {
            IWebDriver driver;
            switch (browser)
            {
                case Constants.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case Constants.Ie:
                    driver = new InternetExplorerDriver();
                    break;
                case Constants.Chrome:
                default:
                    driver = new ChromeDriver();
                    break;
            }
            
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static AppiumDriver<AndroidElement> GetAndroidDriver(string uri, string platformVersion, string apkPath)
        {
            DesiredCapabilities desiredCapabilities = new DesiredCapabilities();
            desiredCapabilities.SetCapability("deviceName", "Android Emulator");
            desiredCapabilities.SetCapability("platformName", "Android");
            desiredCapabilities.SetCapability("platformVersion", platformVersion);
            desiredCapabilities.SetCapability("app", apkPath);

            return new AndroidDriver<AndroidElement>(new Uri(uri), desiredCapabilities);
        }
    }
}
