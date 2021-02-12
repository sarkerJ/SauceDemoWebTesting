using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SauceDemoWebTestingSolution.BDD
{
    [Binding]
    public class SD_Checkout_InfoSteps
    {
        public SD_Website<ChromeDriver> SD_Website { get; } = new SD_Website<ChromeDriver>();
        private CheckoutCredentials _checkoutCredentials;

        [Given(@"I am on the checkout info page")]
        public void GivenIAmOnTheCheckoutInfoPage()
        {
            SD_Website.SD_Checkout_Info_Page.VisitCheckoutInfoPage();
        }
        
        [Given(@"I have filled in valid credentials")]
        public void GivenIHaveFilledInValidCredentials()
        {
            _checkoutCredentials = new CheckoutCredentials();
            SD_Website.SD_Checkout_Info_Page.FillCredentialFields(_checkoutCredentials);
        }

        [Given(@"I have filled in the following invalid credentials (.*) (.*) (.*)")]
        public void GivenIHaveFilledInTheFollowingInvalidCredentials(string fName, string lName, string zip)
        {
            _checkoutCredentials = new CheckoutCredentials() { FirstName = fName, LastName = lName, Zip = zip };
            SD_Website.SD_Checkout_Info_Page.FillCredentialFields(_checkoutCredentials);
        }


        [When(@"I click the continue button")]
        public void WhenIClickTheContinueButton()
        {
            SD_Website.SD_Checkout_Info_Page.ClickContinue();
        }

        [Given(@"I click the cancel button")]
        public void GivenIClickTheCancelButton()
        {
            SD_Website.SD_Checkout_Info_Page.ClickCancel();
        }

        [Then(@"I land on the Checkout: Overview page")]
        public void ThenILandOnTheCheckoutOverviewPage()
        {
            Assert.That(SD_Website.SD_Checkout_Info_Page.GetPageUrl(), Is.EqualTo("https://www.saucedemo.com/checkout-step-two.html"));
        }

        [Then(@"I land on the Cart landing page")]
        public void ThenILandOnTheCartLandingPage()
        {
            Assert.That(SD_Website.SD_Checkout_Info_Page.GetPageUrl(), Is.EqualTo("https://www.saucedemo.com/cart.html"));
        }

        [Then(@"I get the following expected error message (.*)")]
        public void ThenIGetTheFollowingExpectedErrorMessage(string error)
        {
            Assert.That(SD_Website.SD_Checkout_Info_Page.GetErrorMessage(), Is.EqualTo(error));
        }


        [AfterScenario]
        public void DisposableWebDriver()
        {
            SD_Website.SeleniumDriver.Quit();
            SD_Website.SeleniumDriver.Dispose();
        }
    }
}
