using NUnit.Framework;
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

        [When(@"I select one of the possible sort alphabetically dropdown options (.*)")]
        public void WhenISelectOneOfThePossibleSortAlphabeticallyDropdownOptions(string option)
        {
            SD_Website.SD_Products_Page.SelectDropDownOption(option);
        }

        [Then(@"I land on the given social media page (.*)")]
        public void ThenILandOnTheGivenSocialMediaPage(string url)
        {
            Assert.That(SD_Website.SD_Products_Page.GetPageUrl(), Does.Contain(url));
        }

        [Then(@"The products sort by the given alphabetical option")]
        public void ThenTheProductsSortByTheGivenAlphabeticalOption()
        {
            Assert.That(SD_Website.SD_Products_Page.ListOfProducts(), Is.Ordered.Ascending);
        }

        [AfterScenario]
        public void DisposableWebDriver()
        {
            SD_Website.SeleniumDriver.Quit();
            SD_Website.SeleniumDriver.Dispose();
        }
    }
}
