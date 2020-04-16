using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecFlowNetFramework.Helpers
{
    class DriverFactory
    {
        internal static IWebDriver ReturnDriver(DriverType driverType)
        {
            switch (driverType)
            {
                case DriverType.Firefox:
                    return new FirefoxDriver();
                case DriverType.Edge:
                    return new EdgeDriver();
                case DriverType.Chrome:
                default:
                    var driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    return driver;
            }
        }
    }

    enum DriverType
    {
        Chrome,
        Firefox,
        Edge
    }
}
