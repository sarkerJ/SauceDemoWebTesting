using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace SauceDemoWebTestingSolution
{
	//Making a generic website which takes in a driver type (e.g. ChromeDriver) , the type passed must also inherit from IWebDriver and have a default constructor
	public class SeleniumDriverConfig<driverType> where driverType : IWebDriver, new()
	{
		public IWebDriver Driver { get; set; }

		public SeleniumDriverConfig(int pageLoadInSecs, int implicitWaitInSecs)
		{
			Driver = new driverType(); // make a default instance of the typeDriver (using the default constructor)
			DriverSetUp(pageLoadInSecs, implicitWaitInSecs);
		}

		public void DriverSetUp(int pageLoadInSecs, int implicitWaitInSecs)
		{
			SetDriverConfig(pageLoadInSecs, implicitWaitInSecs);
		}

		private void SetDriverConfig(int pageLoadInSecs, int implicitWaitInSecs)
		{
			// this is the time the driver will wait for the page to load
			Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSecs);
			// this is the time the driver waits for the element before the tests fails
			Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSecs);
		}

	}
}
