using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SauceDemoWebTestingSolution.BDD
{
    [Binding]
    public class SD_LogoutSteps
    {
        public SD_Website<ChromeDriver> SD_Website { get; } = new SD_Website<ChromeDriver>();
        private LoginCredentials _loginCredentials = new LoginCredentials();
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            SD_Website.SD_Login_Page.LogInValidCredentials();
        }
        
        [When(@"I click the hamburger menu")]
        public void WhenIClickTheHamburgerMenu()
        {
            SD_Website.SD_Products_Page.ClickBurgerMenuButton();
        }
        
        [When(@"I click the Logout button")]
        public void WhenIClickTheLogoutButton()
        {
            SD_Website.SD_Products_Page.ClickLogoutButton();
        }
        
        [Then(@"I land on the sign in page")]
        public void ThenILandOnTheSignInPage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/index.html"));
        }

        [AfterScenario]
        public void DisposableWebDriver()
        {
            SD_Website.SeleniumDriver.Quit();
            SD_Website.SeleniumDriver.Dispose();
        }
    }
}
