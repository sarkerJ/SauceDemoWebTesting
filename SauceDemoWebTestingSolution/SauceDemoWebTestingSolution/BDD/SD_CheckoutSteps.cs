using System.Threading;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace SauceDemoWebTestingSolution.BDD
{
    [Binding]
    public class SD_CheckoutSteps
    {
        //public _shared_SD_Website.SD_Website<ChromeDriver> _shared_SD_Website.SD_Website { get; } = new _shared_SD_Website.SD_Website<ChromeDriver>();
        private Shared_SD_Website _shared_SD_Website;

        public SD_CheckoutSteps(Shared_SD_Website shared_SD_Website)
        {
            _shared_SD_Website = shared_SD_Website;
        }

        [Given(@"I have the following amount of items in my basket (.*)")]
        public void GivenIHaveTheFollowingAmountOfItemsInMyBasket(int items)
        {
            _shared_SD_Website.SD_Website.SD_Products_Page.AddMultipleItemsToCart(items);
        }
        
        [When(@"I go to My Basket page")]
        public void WhenIGoToMyBasketPage()
        {
            _shared_SD_Website.SD_Website.SD_Products_Page.ClickBasketButton();
        }

		[When(@"I click Checkout")]
		public void WhenIClickCheckout()
		{
            _shared_SD_Website.SD_Website.SD_Checkout_Page.ClickCheckout();
            Thread.Sleep(3000);
		}

        [When(@"I click continue shopping")]
        public void WhenIClickContinueShopping()
        {
            _shared_SD_Website.SD_Website.SD_Checkout_Page.ContinueShopping();
            Thread.Sleep(3000);
        }


        [Then(@"I land on the correct page (.*)")]
        public void ThenILandOnTheCorrectPage(string url)
        {
            Assert.That(_shared_SD_Website.SD_Website.SD_Checkout_Page.GetPageUrl(), Is.EqualTo(url));
        }

    }
}
