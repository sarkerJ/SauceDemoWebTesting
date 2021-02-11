using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace SauceDemoWebTestingSolution
{
	public class SeleniumDriverConfig
	{
		public IWebDriver Driver { get; set; }

		public SeleniumDriverConfig(string driver, int pageLoadInSecs, int implicitWaitInSecs)
		{
			DriverSetUp(driver, pageLoadInSecs, implicitWaitInSecs);
		}

		public void DriverSetUp(string driverName, int pageLoadInSecs, int implicitWaitInSecs)
		{
			if (driverName.ToLower() == "chrome")
			{
				SetChromeDriver();
				SetDriverConfig(pageLoadInSecs, implicitWaitInSecs);
			}
			else
			{
				throw new Exception("Please use chrome");
			}
		}

		public void SetChromeDriver()
		{
			Driver = new ChromeDriver();
		}

		private void SetDriverConfig(int pageLoadInSecs, int implicitWaitInSecs)
		{
			// this is the time the driver will wait for the page to load
			Driver.Manage().Timeouts().PageLoad =
				TimeSpan.FromSeconds(pageLoadInSecs);
			// this is the time the driver waits for the element before the tests fails
			Driver.Manage().Timeouts().ImplicitWait =
				TimeSpan.FromSeconds(implicitWaitInSecs);
		}
	}
}
