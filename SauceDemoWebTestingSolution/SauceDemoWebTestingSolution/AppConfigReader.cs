using System.Configuration;

namespace SauceDemoWebTestingSolution
{
	public static class AppConfigReader
	{
		public static readonly string BaseUrl =
			ConfigurationManager.AppSettings["base_url"];
		public static readonly string ProductsUrl =
			ConfigurationManager.AppSettings["login_page_url"];
	}
}