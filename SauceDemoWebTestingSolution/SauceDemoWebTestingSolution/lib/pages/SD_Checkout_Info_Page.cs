using System;
using OpenQA.Selenium;

namespace SauceDemoWebTestingSolution
{
	public class SD_Checkout_Info_Page
	{
		private IWebDriver _seleniumDriver;
		private string _checkoutInfoPageURL = AppConfigReader.CheckoutInfoUrl;

		private IWebElement _firstName => _seleniumDriver.FindElement(By.Id("first-name"));
		private IWebElement _lastName => _seleniumDriver.FindElement(By.Id("last-name"));
		private IWebElement _zip => _seleniumDriver.FindElement(By.Id("postal-code"));
		private IWebElement _errorMessage => _seleniumDriver.FindElement(By.CssSelector("*[data-test=\"error\"]"));
		private IWebElement _continueButton => _seleniumDriver.FindElement(By.ClassName("cart_button"));
		private IWebElement _cancelButton => _seleniumDriver.FindElement(By.LinkText("CANCEL"));
	

		public SD_Checkout_Info_Page(IWebDriver seleniumDriver)
		{
			_seleniumDriver = seleniumDriver;
		}

		public void VisitCheckoutInfoPage()
		{
			_seleniumDriver.Navigate().GoToUrl(_checkoutInfoPageURL);
		}

		public string GetPageUrl()
		{
			return _seleniumDriver.Url;
		}

		public string GetErrorMessage()
		{
			return _errorMessage.Text;
		}

		public void FillCredentialFields(CheckoutCredentials credentials)
		{
			_firstName.SendKeys(credentials.FirstName);
			_lastName.SendKeys(credentials.LastName);
			_zip.SendKeys(credentials.Zip);
		}

		public void ClickContinue()
		{
			_continueButton.Click();
		}

		public void ClickCancel()
		{
			_cancelButton.Click();
		}
	}
}
