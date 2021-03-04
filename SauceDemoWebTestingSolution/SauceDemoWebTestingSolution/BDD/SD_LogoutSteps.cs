using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SauceDemoWebTestingSolution.BDD
{
    [Binding]
    public class SD_LogoutSteps
    {
        //public _shared_SD_Website.SD_Website<ChromeDriver> _shared_SD_Website.SD_Website { get; } = new _shared_SD_Website.SD_Website<ChromeDriver>();
        private LoginCredentials _loginCredentials = new LoginCredentials();
        private Shared_SD_Website _shared_SD_Website;

        public SD_LogoutSteps(Shared_SD_Website shared_SD_Website)
        {
            _shared_SD_Website = shared_SD_Website;
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            _shared_SD_Website.SD_Website.SD_Login_Page.LogInValidCredentials();
        }
        
        [When(@"I click the hamburger menu")]
        public void WhenIClickTheHamburgerMenu()
        {
            _shared_SD_Website.SD_Website.SD_Products_Page.ClickBurgerMenuButton();
        }
        
        [When(@"I click the Logout button")]
        public void WhenIClickTheLogoutButton()
        {
            _shared_SD_Website.SD_Website.SD_Products_Page.ClickLogoutButton();
        }
        
        [Then(@"I land on the sign in page")]
        public void ThenILandOnTheSignInPage()
        {
            Assert.That(_shared_SD_Website.SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/index.html"));
        }

        [AfterScenario]
        public void DisposableWebDriver()
        {
            _shared_SD_Website.SD_Website.SeleniumDriver.Quit();
            _shared_SD_Website.SD_Website.SeleniumDriver.Dispose();
        }
    }
}
