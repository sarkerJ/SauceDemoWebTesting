using OpenQA.Selenium;

namespace SauceDemoWebTestingSolution
{
	public class SD_Website
	{
		public IWebDriver SeleniumDriver { get; internal set; }
		public SD_Login_Page SD_Login_Page { get; internal set; }
		public SD_Products_Page SD_Products_Page { get; internal set; }

		public SD_Website(string driverName, int pageLoadWaitInSecs = 10, int implicitWaitInSecs = 10) 
		{
			SeleniumDriver = new SeleniumDriverConfig(driverName, pageLoadWaitInSecs, implicitWaitInSecs).Driver;

			SD_Login_Page = new SD_Login_Page(SeleniumDriver);
			SD_Products_Page = new SD_Products_Page(SeleniumDriver);
		}

		public void DeleteCookies()
		{
			SeleniumDriver.Manage().Cookies.DeleteAllCookies();
		}
	}
}
