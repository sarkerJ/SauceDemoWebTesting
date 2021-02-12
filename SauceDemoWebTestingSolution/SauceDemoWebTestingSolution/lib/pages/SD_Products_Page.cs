using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
		private IWebElement _dropDown => _seleniumDriver.FindElement(By.ClassName("product_sort_container"));
		private ReadOnlyCollection<IWebElement> _productsList => _seleniumDriver.FindElements(By.ClassName("inventory_item_name"));
		private ReadOnlyCollection<IWebElement> _productsByPriceList => _seleniumDriver.FindElements(By.ClassName("inventory_item_price"));

		private List<string> _sortedList;
		private List<decimal> _pricesSortedList;

		private IWebElement _productPageName => _seleniumDriver.FindElement(By.ClassName("inventory_details_name"));
		private IWebElement _productPageBackButton => _seleniumDriver.FindElement(By.ClassName("inventory_details_back_button"));
		private IWebElement _burgerMenuButton => _seleniumDriver.FindElement(By.ClassName("bm-burger-button"));
		private IWebElement _logoutButton => _seleniumDriver.FindElement(By.Id("logout_sidebar_link"));
		private IWebElement _basketButton => _seleniumDriver.FindElement(By.ClassName("shopping_cart_link"));


		private IReadOnlyCollection<IWebElement> productItemsAddToCart => _seleniumDriver.FindElements(By.ClassName("btn_inventory"));
		private IWebElement cartItemCount => _seleniumDriver.FindElement(By.ClassName("shopping_cart_badge"));

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
		public void SelectDropDownOption(string option)
		{
			_dropDown.SendKeys(option);
		}

		public List<string> AlphabeticalListOfProducts()
		{
			_sortedList = new List<string>();
			foreach (var item in _productsList) _sortedList.Add(item.Text);
			return _sortedList;
		}

		public List<decimal> SortedListOfProductsByPrice()
		{
			_pricesSortedList = new List<decimal>();
			foreach (var item in _productsByPriceList) _pricesSortedList.Add(decimal.Parse(item.Text.Remove(0,1)));
			return _pricesSortedList;
		}
		public string GetPageUrl()
		{
			return _seleniumDriver.Url;
		}

		public string GetPageLabel()
		{
			return _productLabel.Text; ;
		}
    
		public void ClickProductItem(string productid)
        {
			_seleniumDriver.FindElement(By.Id(productid)).Click();
		}

		public string GetProductPageName()
        {
			return _productPageName.Text;
		}

		public void ClickBackButton()
        {
			_productPageBackButton.Click();
        }

		public void ClickBurgerMenuButton()
		{
			_burgerMenuButton.Click();
		}

		public void ClickLogoutButton()
		{
			_logoutButton.Click();
		}

		public void ClickBasketButton()
		{
			_basketButton.Click();
		}
		public void AddMultipleItemsToCart(int items)
		{
			for(int i = 0; i < items; i++)
			{
				productItemsAddToCart.ToArray()[i].Click();
			}
		}
		public void AddProductToCart(int productIndex)
		{
			 productItemsAddToCart.ToArray()[productIndex].Click();
		}
		public string AddProductToCartButtonState(int index) => productItemsAddToCart.ToArray()[index].Text;

		public string GetCartCount()
		{
			try { return cartItemCount.Text; } catch (Exception) { return "0"; }
		}

	}
}
