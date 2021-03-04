using NUnit.Framework;
using TechTalk.SpecFlow;
using System.Threading;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemoWebTestingSolution.BDD
{
    [Binding]
    public class SD_LoginSteps
    {
        //public _shared_SD_Website.SD_Website<ChromeDriver> _shared_SD_Website.SD_Website { get; } = new _shared_SD_Website.SD_Website<ChromeDriver>();
        private LoginCredentials _loginCredentials;
        private Shared_SD_Website _shared_SD_Website;

        public SD_LoginSteps(Shared_SD_Website shared_SD_Website)
        {
            _shared_SD_Website = shared_SD_Website;
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _shared_SD_Website.SD_Website.SD_Login_Page.VisitLoginPage();
        }
        
        [Given(@"I have supplied a valid username and password")]
        public void GivenIHaveSuppliedAValidUsernameAndPassword()
        {
            _loginCredentials = new LoginCredentials();
            _shared_SD_Website.SD_Website.SD_Login_Page.EnterCredentials(_loginCredentials);
        }

        [Given(@"I have supplied the following invalid credentials")]
        public void GivenIHaveSuppliedTheFollowingInvalidCredentials(Table table)
        {
            _loginCredentials = table.CreateInstance<LoginCredentials>();
            _shared_SD_Website.SD_Website.SD_Login_Page.EnterCredentials(_loginCredentials);
        }

        [Given(@"I have supplied the following (.*) and (.*)")]
        public void GivenIHaveSuppliedTheFollowingAnd(string username, string password)
        {
            _loginCredentials = new LoginCredentials() { Username = username, Password = password };
            _shared_SD_Website.SD_Website.SD_Login_Page.EnterCredentials(_loginCredentials);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _shared_SD_Website.SD_Website.SD_Login_Page.ClickLogin();
        }
        
        [Then(@"I should land on the products page")]
        public void ThenIShouldLandOnTheProductsPage()
        {
            Thread.Sleep(5000);
            Assert.That(_shared_SD_Website.SD_Website.SD_Products_Page.GetPageLabel(), Does.Contain("Products"));
        }

        //[Then(@"I get the following error message ""(.*)""")]
        //public void ThenIGetTheFollowingErrorMessage(string error)
        //{
        //    Assert.That(_shared_SD_Website.SD_Website.SD_Login_Page.GetErrorMessageText(),Does.Contain(error));
        //}



        [Then(@"I get the following error message (.*)")]
        public void ThenIGetTheFollowingErrorMessage(string error)
        {
            Assert.That(_shared_SD_Website.SD_Website.SD_Login_Page.GetErrorMessageText(), Does.Contain(error));
        }

        //[AfterScenario]
        //public void DisposableWebDriver()
        //{
        //    _shared_SD_Website.SD_Website.SeleniumDriver.Quit();
        //    _shared_SD_Website.SD_Website.SeleniumDriver.Dispose();
        //}
    }
}

