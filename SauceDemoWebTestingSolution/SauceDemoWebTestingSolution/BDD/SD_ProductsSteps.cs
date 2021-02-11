using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SauceDemoWebTestingSolution.BDD
{
    [Binding]
    public class SD_ProductsSteps
    {
        public SD_Website SD_Website { get; } = new SD_Website("chrome");

        [Given(@"I am on the products page")]
        public void GivenIAmOnTheProductsPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on the following social media widget (.*)")]
        public void WhenIClickOnTheFollowingSocialMediaWidget(string media)
        {
            SD_Website.SD_Products_Page.ClickSocialMedia(media);
        }
        
        [Then(@"I land on the given social media page (.*)")]
        public void ThenILandOnTheGivenSocialMediaPage(string url)
        {
            // Assert.That(, Does.Contain(url));
        }
    }
}
