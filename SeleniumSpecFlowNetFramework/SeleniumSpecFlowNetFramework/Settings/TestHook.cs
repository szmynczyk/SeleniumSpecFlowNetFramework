using OpenQA.Selenium;
using SeleniumSpecFlowNetFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlowNetFramework.Settings
{
    [Binding]
    public sealed class TestHook
    {
        private IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = DriverFactory.ReturnDriver(DriverType.Chrome);
            ScenarioContext.Current["driver"] = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
            driver.Dispose();
            driver.Dispose();
        }
    }
}
