using OpenQA.Selenium;

namespace SauceDemoWebTestingSolution
{
	public class SD_Products_Page
	{
		private IWebDriver _seleniumDriver;
		private IWebElement _productLabel => _seleniumDriver.FindElement(By.ClassName("product_label"));


		public SD_Products_Page(IWebDriver seleniumDriver)
		{
			_seleniumDriver = seleniumDriver;
		}

		public string GetPageLabel()
		{
			return _productLabel.Text; ;
		}
	}
}
