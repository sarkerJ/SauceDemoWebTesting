using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SauceDemoWebTestingSolution.BDD
{
    [Binding]
    public class SD_Checkout_InfoSteps
    {
        //public _shared_SD_Website.SD_Website<ChromeDriver> _shared_SD_Website.SD_Website { get; } = new _shared_SD_Website.SD_Website<ChromeDriver>();
        private CheckoutCredentials _checkoutCredentials;
        private Shared_SD_Website _shared_SD_Website;

        public SD_Checkout_InfoSteps(Shared_SD_Website shared_SD_Website)
        {
            _shared_SD_Website = shared_SD_Website;
        }

        [Given(@"I am on the checkout info page")]
        public void GivenIAmOnTheCheckoutInfoPage()
        {
            _shared_SD_Website.SD_Website.SD_Checkout_Info_Page.VisitCheckoutInfoPage();
        }
        
        [Given(@"I have filled in valid credentials")]
        public void GivenIHaveFilledInValidCredentials()
        {
            _checkoutCredentials = new CheckoutCredentials();
            _shared_SD_Website.SD_Website.SD_Checkout_Info_Page.FillCredentialFields(_checkoutCredentials);
        }

        [Given(@"I have filled in the following invalid credentials (.*) (.*) (.*)")]
        public void GivenIHaveFilledInTheFollowingInvalidCredentials(string fName, string lName, string zip)
        {
            _checkoutCredentials = new CheckoutCredentials() { FirstName = fName, LastName = lName, Zip = zip };
            _shared_SD_Website.SD_Website.SD_Checkout_Info_Page.FillCredentialFields(_checkoutCredentials);
        }


        [When(@"I click the continue button")]
        public void WhenIClickTheContinueButton()
        {
            _shared_SD_Website.SD_Website.SD_Checkout_Info_Page.ClickContinue();
        }

        [Given(@"I click the cancel button")]
        public void GivenIClickTheCancelButton()
        {
            _shared_SD_Website.SD_Website.SD_Checkout_Info_Page.ClickCancel();
        }

        [Then(@"I land on the Checkout: Overview page")]
        public void ThenILandOnTheCheckoutOverviewPage()
        {
            Assert.That(_shared_SD_Website.SD_Website.SD_Checkout_Info_Page.GetPageUrl(), Is.EqualTo("https://www.saucedemo.com/checkout-step-two.html"));
        }

        [Then(@"I land on the Cart landing page")]
        public void ThenILandOnTheCartLandingPage()
        {
            Assert.That(_shared_SD_Website.SD_Website.SD_Checkout_Info_Page.GetPageUrl(), Is.EqualTo("https://www.saucedemo.com/cart.html"));
        }

        [Then(@"I get the following expected error message (.*)")]
        public void ThenIGetTheFollowingExpectedErrorMessage(string error)
        {
            Assert.That(_shared_SD_Website.SD_Website.SD_Checkout_Info_Page.GetErrorMessage(), Is.EqualTo(error));
        }

    }
}
