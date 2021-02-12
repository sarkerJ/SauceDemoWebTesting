using OpenQA.Selenium;

namespace SauceDemoWebTestingSolution
{
	public class SD_Checkout_Page
	{
		private IWebDriver _seleniumDriver;
		private string _checkoutPageURL = AppConfigReader.CheckoutUrl;

		private IWebElement _checkoutButton => _seleniumDriver.FindElement(By.ClassName("checkout_button"));
		private IWebElement _continueShopping => _seleniumDriver.FindElement(By.LinkText("CONTINUE SHOPPING"));
		
		public SD_Checkout_Page(IWebDriver seleniumDriver)
		{
			_seleniumDriver = seleniumDriver;
		}

		public void ContinueShopping()
		{
			_continueShopping.Click();
		}

		public void ClickCheckout()
		{
			_checkoutButton.Click();
		}

		public string GetPageUrl()
		{
			return _seleniumDriver.Url;
		}
	}
}
