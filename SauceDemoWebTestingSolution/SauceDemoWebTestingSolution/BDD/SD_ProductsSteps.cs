using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SauceDemoWebTestingSolution
{
    [Binding]
    public class SD_ProductsSteps
    {
        //public _shared_SD_Website.SD_Website<ChromeDriver> _shared_SD_Website.SD_Website { get; } = new _shared_SD_Website.SD_Website<ChromeDriver>();
        private Shared_SD_Website _shared_SD_Website;

        public SD_ProductsSteps(Shared_SD_Website shared_SD_Website)
        {
            _shared_SD_Website = shared_SD_Website;
        }

        [Given(@"I am on the products page")]
        public void GivenIAmOnTheProductsPage()
        {
            _shared_SD_Website.SD_Website.SD_Products_Page.VisitProductsPage();
        }

        [When(@"I click on the following social media widget (.*)")]
        public void WhenIClickOnTheFollowingSocialMediaWidget(string media)
        {
            _shared_SD_Website.SD_Website.SD_Products_Page.ClickSocialMedia(media);
        }


        [When(@"I select to sort by (.*) from the dropdown menue")]
        public void WhenISelectToSortByFromTheDropdownMenue(string option)
        {
             _shared_SD_Website.SD_Website.SD_Products_Page.SelectDropDownOption(option);
        }

        [Then(@"I land on the given social media page (.*)")]
        public void ThenILandOnTheGivenSocialMediaPage(string url)
        {
            Assert.That(_shared_SD_Website.SD_Website.SD_Products_Page.GetPageUrl(), Does.Contain(url));
        }

        [Then(@"The products sort alphabetically from A to Z")]
        public void ThenTheProductsSortAlphabeticallyFromAToZ()
        {
            Assert.That(_shared_SD_Website.SD_Website.SD_Products_Page.AlphabeticalListOfProducts(), Is.Ordered.Ascending);
        }

        [Then(@"The products sort alphabetically from Z to A")]
        public void ThenTheProductsSortAlphabeticallyFromZToA()
        {
            Assert.That(_shared_SD_Website.SD_Website.SD_Products_Page.AlphabeticalListOfProducts(), Is.Ordered.Descending);
        }

        [Then(@"The products sort by price from low to high")]
        public void ThenTheProductsSortByPriceFromLowToHigh()
        {
            Assert.That(_shared_SD_Website.SD_Website.SD_Products_Page.SortedListOfProductsByPrice(), Is.Ordered.Ascending);
        }

        [Then(@"The products sort by price from high to low")]
        public void ThenTheProductsSortByPriceFromHighToLow()
        {
            Assert.That(_shared_SD_Website.SD_Website.SD_Products_Page.SortedListOfProductsByPrice(), Is.Ordered.Descending);
        }


        [When(@"I click on a product name (.*)")]
        public void WhenIClickOnAProductName(string productName)
        {
            _shared_SD_Website.SD_Website.SD_Products_Page.ClickProductItem(productName);
        }

        [When(@"I click the back button")]
        public void WhenIClickTheBackButton()
        {
            _shared_SD_Website.SD_Website.SD_Products_Page.ClickBackButton();
            Thread.Sleep(3000);
        }

        [When(@"I add a product to cart (.*)")]
        public void WhenIAddAProductToCart(int productIndex)
        {
            _shared_SD_Website.SD_Website.SD_Products_Page.AddProductToCart(productIndex);
        }

        [When(@"I click the button again to remove the product (.*)")]
        public void WhenIClickTheButtonAgainToRemoveTheProduct(int productIndex)
        {
            _shared_SD_Website.SD_Website.SD_Products_Page.AddProductToCart(productIndex);
        }

        [Then(@"the cart count is (.*)")]
        public void ThenTheCartCountIs(string countValue)
        {
            Assert.That(_shared_SD_Website.SD_Website.SD_Products_Page.GetCartCount(), Is.EqualTo(countValue));
        }


        [Then(@"the button state (.*) changes to (.*)")]
        public void ThenTheButtonStateChangesTo( int productIndex, string state)
        {
            Assert.That(_shared_SD_Website.SD_Website.SD_Products_Page.AddProductToCartButtonState(productIndex), Is.EqualTo(state));
        }



        [Then(@"I should see a page with information of that product (.*)")]
        public void ThenIShouldSeeAPageWithInformationOfThatProduct(string expected)
        {
            Thread.Sleep(3000);
            Assert.That(_shared_SD_Website.SD_Website.SD_Products_Page.GetProductPageName, Is.EqualTo(expected));
        }

        [Then(@"I should land on the products page again (.*)")]
        public void ThenIShouldLandOnTheProductsPageAgain(string name)
        {
            Assert.That(_shared_SD_Website.SD_Website.SD_Products_Page.GetPageLabel(), Does.Contain(name));
        }

        //[AfterScenario]
        //public void DisposableWebDriver()
        //{
        //    _shared_SD_Website.SD_Website.SeleniumDriver.Quit();
        //    _shared_SD_Website.SD_Website.SeleniumDriver.Dispose();
        //}


    }
}
