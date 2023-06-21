using CryptoCurrency.MVVM.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class YourApiService
{
	private const string ApiKey = "YOUR_API_KEY";
	private const string ApiUrl = ""; 

	public static async Task<List<CurrencyData>> GetTopCurrenciesAsync()
	{
		using (HttpClient client = new HttpClient())
		{
			client.DefaultRequestHeaders.Add("ApiKey", ApiKey);

			HttpResponseMessage response = await client.GetAsync(ApiUrl + "topcurrencies");
			response.EnsureSuccessStatusCode();

			string responseBody = await response.Content.ReadAsStringAsync();

			

			List<CurrencyData> topCurrencies = ParseResponse(responseBody);

			return topCurrencies;
		}
	}

	private static List<CurrencyData> ParseResponse(string responseBody)
	{
		
		List<CurrencyData> currencies = JsonConvert.DeserializeObject<List<CurrencyData>>(responseBody);

		return currencies;
	}
}