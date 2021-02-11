using NUnit.Framework;
using TechTalk.SpecFlow;
using System.Threading;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;

namespace SauceDemoWebTestingSolution.BDD
{
    [Binding]
    public class SD_LoginSteps
    {
        public SD_Website SD_Website { get; } = new SD_Website("chrome");
        private LoginCredentials _loginCredentials;

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            SD_Website.SD_Login_Page.VisitLoginPage();
        }
        
        [Given(@"I have supplied a valid username and password")]
        public void GivenIHaveSuppliedAValidUsernameAndPassword()
        {
            _loginCredentials = new LoginCredentials();
            SD_Website.SD_Login_Page.EnterCredentials(_loginCredentials);
        }

        [Given(@"I have supplied the following invalid credentials")]
        public void GivenIHaveSuppliedTheFollowingInvalidCredentials(Table table)
        {
            _loginCredentials = table.CreateInstance<LoginCredentials>();
            SD_Website.SD_Login_Page.EnterCredentials(_loginCredentials);
        }

        [Given(@"I have supplied the following (.*) and (.*)")]
        public void GivenIHaveSuppliedTheFollowingAnd(string username, string password)
        {
            _loginCredentials = new LoginCredentials() { Username = username, Password = password };
            SD_Website.SD_Login_Page.EnterCredentials(_loginCredentials);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            SD_Website.SD_Login_Page.ClickLogin();
        }
        
        [Then(@"I should land on the products page")]
        public void ThenIShouldLandOnTheProductsPage()
        {
            Thread.Sleep(5000);
            Assert.That(SD_Website.SD_Products_Page.GetPageLabel(), Does.Contain("Products"));
        }

        //[Then(@"I get the following error message ""(.*)""")]
        //public void ThenIGetTheFollowingErrorMessage(string error)
        //{
        //    Assert.That(SD_Website.SD_Login_Page.GetErrorMessageText(),Does.Contain(error));
        //}



        [Then(@"I get the following error message (.*)")]
        public void ThenIGetTheFollowingErrorMessage(string error)
        {
            Assert.That(SD_Website.SD_Login_Page.GetErrorMessageText(), Does.Contain(error));
        }

        



        [AfterScenario]
        public void DisposableWebDriver()
        {
            SD_Website.SeleniumDriver.Quit();
            SD_Website.SeleniumDriver.Dispose();
        }
    }
}

