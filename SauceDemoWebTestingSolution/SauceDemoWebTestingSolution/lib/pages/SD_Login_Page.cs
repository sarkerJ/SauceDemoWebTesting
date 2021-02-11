using OpenQA.Selenium;

namespace SauceDemoWebTestingSolution
{
	public class SD_Login_Page
	{
		private IWebDriver _seleniumDriver;
		private string _loginPageURL = AppConfigReader.BaseUrl;

		private IWebElement _loginButton => _seleniumDriver.FindElement(By.Id("login-button"));
		private IWebElement _usernameField => _seleniumDriver.FindElement(By.Id("user-name"));
		private IWebElement _passwordField => _seleniumDriver.FindElement(By.Id("password"));
		private IWebElement _errorMessage => _seleniumDriver.FindElement(By.Id(""));

		public SD_Login_Page(IWebDriver seleniumDriver)
		{
			_seleniumDriver = seleniumDriver;
		}

		public void VisitLoginPage()
		{
			_seleniumDriver.Navigate().GoToUrl(_loginPageURL);
		}

		public void EnterCredentials(LoginCredentials credentials)
		{
			_usernameField.SendKeys(credentials.Username);
			_passwordField.SendKeys(credentials.Password);
		}

		public void ClickLogin()
		{
			_loginButton.Click();
		}

		public string ErrorMessage()
		{
			return _errorMessage.Text;
		}

		public string GetPageTitle()
		{
			return _seleniumDriver.Title;
		}
	}
}
