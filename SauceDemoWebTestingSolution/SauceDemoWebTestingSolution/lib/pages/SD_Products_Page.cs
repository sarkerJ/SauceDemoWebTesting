using OpenQA.Selenium;

namespace SauceDemoWebTestingSolution
{
	public class SD_Products_Page
	{
		private IWebDriver _seleniumDriver;
		private string _productsPageURL = AppConfigReader.ProductsUrl;
		private IWebElement _productLabel => _seleniumDriver.FindElement(By.ClassName("product_label"));
		private IWebElement _twitter => _seleniumDriver.FindElement(By.ClassName("social_twitter"));
		private IWebElement _facebook => _seleniumDriver.FindElement(By.ClassName("social_facebook"));
		private IWebElement _linkedin => _seleniumDriver.FindElement(By.ClassName("social_linkedin"));


		public SD_Products_Page(IWebDriver seleniumDriver)
		{
			_seleniumDriver = seleniumDriver;
		}

		public void VisitProductsPage()
		{
			_seleniumDriver.Navigate().GoToUrl(_productsPageURL);
		}

		public void ClickSocialMedia(string smedia)
		{
			if (smedia.ToLower() == "twitter") _twitter.Click();
			if (smedia.ToLower() == "facebook") _facebook.Click();
			if (smedia.ToLower() == "linkedin") _linkedin.Click();
		}

		public string GetPageLabel()
		{
			return _productLabel.Text; ;
		}
	}
}
