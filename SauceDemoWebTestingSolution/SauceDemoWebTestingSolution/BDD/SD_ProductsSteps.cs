using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace SauceDemoWebTestingSolution
{
    [Binding]
    public class SD_ProductsSteps
    {
        public SD_Website SD_Website { get; } = new SD_Website("chrome");

        [Given(@"I am on the products page")]
        public void GivenIAmOnTheProductsPage()
        {
            SD_Website.SD_Products_Page.VisitProductsPage();
        }

        [When(@"I click on the following social media widget (.*)")]
        public void WhenIClickOnTheFollowingSocialMediaWidget(string media)
        {
            SD_Website.SD_Products_Page.ClickSocialMedia(media);
        }


        [When(@"I select to sort by (.*) from the dropdown menue")]
        public void WhenISelectToSortByFromTheDropdownMenue(string option)
        {
             SD_Website.SD_Products_Page.SelectDropDownOption(option);
        }

        [Then(@"I land on the given social media page (.*)")]
        public void ThenILandOnTheGivenSocialMediaPage(string url)
        {
            Assert.That(SD_Website.SD_Products_Page.GetPageUrl(), Does.Contain(url));
        }

        [Then(@"The products sort alphabetically from A to Z")]
        public void ThenTheProductsSortAlphabeticallyFromAToZ()
        {
            Assert.That(SD_Website.SD_Products_Page.AlphabeticalListOfProducts(), Is.Ordered.Ascending);
        }

        [Then(@"The products sort alphabetically from Z to A")]
        public void ThenTheProductsSortAlphabeticallyFromZToA()
        {
            Assert.That(SD_Website.SD_Products_Page.AlphabeticalListOfProducts(), Is.Ordered.Descending);
        }

        [Then(@"The products sort by price from low to high")]
        public void ThenTheProductsSortByPriceFromLowToHigh()
        {
            Assert.That(SD_Website.SD_Products_Page.SortedListOfProductsByPrice(), Is.Ordered.Ascending);
        }

        [Then(@"The products sort by price from high to low")]
        public void ThenTheProductsSortByPriceFromHighToLow()
        {
            Assert.That(SD_Website.SD_Products_Page.SortedListOfProductsByPrice(), Is.Ordered.Descending);
        }



        [When(@"I click on a product name (.*)")]
        public void WhenIClickOnAProductName(string productName)
        {
            SD_Website.SD_Products_Page.ClickProductItem(productName);
        }

        [When(@"I click the back button")]
        public void WhenIClickTheBackButton()
        {
            SD_Website.SD_Products_Page.ClickBackButton();
            Thread.Sleep(3000);
        }


        [Then(@"I should see a page with information of that product (.*)")]
        public void ThenIShouldSeeAPageWithInformationOfThatProduct(string expected)
        {
            Thread.Sleep(3000);
            Assert.That(SD_Website.SD_Products_Page.GetProductPageName, Is.EqualTo(expected));
        }

        [Then(@"I should land on the products page again (.*)")]
        public void ThenIShouldLandOnTheProductsPageAgain(string name)
        {
            Assert.That(SD_Website.SD_Products_Page.GetPageLabel(), Does.Contain(name));
        }

        [AfterScenario]
        public void DisposableWebDriver()
        {
            SD_Website.SeleniumDriver.Quit();
            SD_Website.SeleniumDriver.Dispose();
        }


    }
}
