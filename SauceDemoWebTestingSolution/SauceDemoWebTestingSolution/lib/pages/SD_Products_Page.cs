using OpenQA.Selenium;

namespace SauceDemoWebTestingSolution
{
	public class SD_Products_Page
	{
		private IWebDriver _seleniumDriver;

		public SD_Products_Page(IWebDriver seleniumDriver)
		{
			_seleniumDriver = seleniumDriver;
		}

		public string GetPageTitle()
		{
			return _seleniumDriver.Title;
		}
	}
}
