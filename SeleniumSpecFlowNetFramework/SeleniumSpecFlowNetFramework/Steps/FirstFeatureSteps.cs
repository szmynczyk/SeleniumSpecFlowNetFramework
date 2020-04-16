using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlowNetFramework.Steps
{
    [Binding]
    public class CheckContactFormSteps
    {
        private IWebDriver driver;

        public CheckContactFormSteps()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
        }

        [Given(@"I enter to ""(.*)"" page")]
        public void GivenIEnterToPage(string pageName)
        {
            string url = null;
            if (pageName == "home")
                url = @"https://courseofautomationtesting.wordpress.com/";
            driver.Navigate().GoToUrl(url);
        }

        [Given(@"I Accept cookies")]
        public void GivenIAcceptCookies()
        {
            driver.FindElement(By.CssSelector(".accept")).Click();
        }


        [Given(@"I click on ""(.*)"" in menu")]
        public void GivenIClickOnInMenu(string menuItem)
        {
            var menuElements = driver.FindElements(By.CssSelector("#site-navigation .menu-item"));

            switch (menuItem)
            {
                case "Home":
                    menuElements.First(x => x.Text == "Home").Click();
                    break;
                case "About":
                    menuElements.First(x => x.Text == "About").Click();
                    break;
                case "Contact":
                    menuElements.First(x => x.Text == "Contact").Click();
                    Assert.True(driver.Url.Contains("/contact"));
                    try
                    {
                        driver.FindElement(By.CssSelector(".bottom-sticky__ad-close-btn")).Click();
                    }
                    catch { }
                    
                    break;
            }
        }

        [When(@"I fill contact form")]
        public void WhenIFillContactForm()
        {
            var name = driver.FindElement(By.CssSelector("#g3-name"));
            var email = driver.FindElement(By.CssSelector("#g3-email"));
            var website = driver.FindElement(By.CssSelector("#g3-website"));
            var comment = driver.FindElement(By.CssSelector("#contact-form-comment-g3-comment"));
            var submitButton = driver.FindElement(By.CssSelector(".pushbutton-wide"));

            name.SendKeys("name");
            email.SendKeys("email@testmail.com");
            website.SendKeys("http://www.mywebsite.com");
            comment.SendKeys("some really helpful comment");
            submitButton.Click();
        }

        [Then(@"I expect to see message as ""(.*)""")]
        public void ThenIExpectToSeeMessageAs(string message)
        {
            var expectedText = driver.FindElement(By.CssSelector("#contact-form-3 h3"));
            Assert.AreEqual(expectedText.Text, message);
        }
    }
}