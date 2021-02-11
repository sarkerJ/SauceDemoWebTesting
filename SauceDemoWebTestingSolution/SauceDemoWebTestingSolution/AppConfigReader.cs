using System.Configuration;

namespace SauceDemoWebTestingSolution
{
	public static class AppConfigReader
	{
		public static readonly string BaseUrl =
			ConfigurationManager.AppSettings["base_url"];
	}
}