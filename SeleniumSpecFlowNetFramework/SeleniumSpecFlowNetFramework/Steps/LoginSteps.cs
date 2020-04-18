using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlowNetFramework.Steps
{
    [Binding]
    public class LoginSteps
    {
        IWebDriver driver;

        public LoginSteps()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
        }

        [Given(@"I am opening Vitoguide app")]
        public void GivenIAmOpeningVitoguideApp()
        {
            driver.Navigate().GoToUrl(@"https://vitoguide-integration.viessmann.com/");
        }
        
        [When(@"I click Login button")]
        public void WhenIClickLoginButton()
        {
            driver.FindElement(By.CssSelector(".login-button")).Click();
        }
        
        [When(@"I put (.*) as user name")]
        public void WhenIPutAsUserName(string userName)
        {
            var userNameField = driver.FindElement(By.CssSelector("[name='isiwebuserid']"));
            userNameField.Click();
            userNameField.SendKeys(userName);
        }
        
        [When(@"I put (.*) as password")]
        public void WhenIPutAsPassword(string password)
        {
            var passwordField = driver.FindElement(By.CssSelector("[name='isiwebpasswd']"));
            passwordField.Click();
            passwordField.SendKeys(password);
        }

        [When(@"I press login button")]
        public void WhenIPressLoginButton()
        {
            driver.FindElement(By.CssSelector("#loginButton")).Click();
        }
        
        [Then(@"I land on (.*) page")]
        public void ThenILandOnPage(string targetPage)
        {
            string url = $"https://vitoguide-integration.viessmann.com{targetPage}";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var isLoaded = wait.Until(ExpectedConditions.UrlContains(url));
        }
    }
}
