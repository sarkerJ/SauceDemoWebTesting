using System.Threading;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SauceDemoWebTestingSolution.BDD
{
    [Binding]
    public class SD_CheckoutSteps
    {
        public SD_Website SD_Website { get; } = new SD_Website("chrome");

        [Given(@"I am on the products page again")]
        public void GivenIAmOnTheProductsPageAgain()
        {
            SD_Website.SD_Products_Page.VisitProductsPage();
        }

        [Given(@"I have the following amount of items in my basket (.*)")]
        public void GivenIHaveTheFollowingAmountOfItemsInMyBasket(int items)
        {
            SD_Website.SD_Products_Page.AddMultipleItemsToCart(items);
        }
        
        [When(@"I go to My Basket page")]
        public void WhenIGoToMyBasketPage()
        {
            SD_Website.SD_Products_Page.ClickBasketButton();
        }

		[When(@"I click Checkout")]
		public void WhenIClickCheckout()
		{
            SD_Website.SD_Checkout_Page.ClickCheckout();
            Thread.Sleep(3000);
		}

        [When(@"I click continue shopping")]
        public void WhenIClickContinueShopping()
        {
            SD_Website.SD_Checkout_Page.ContinueShopping();
            Thread.Sleep(3000);
        }


        [Then(@"I land on the correct page (.*)")]
        public void ThenILandOnTheCorrectPage(string url)
        {
            Assert.That(SD_Website.SD_Checkout_Page.GetPageUrl(), Is.EqualTo(url));
        }

        [AfterScenario]
        public void DisposableWebDriver()
        {
            SD_Website.SeleniumDriver.Quit();
            SD_Website.SeleniumDriver.Dispose();
        }
    }
}
