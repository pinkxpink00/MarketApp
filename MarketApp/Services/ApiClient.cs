using CryptoCurrency.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency.Services
{
	public class ApiClient : IApiClient
	{
		private readonly HttpClient httpClient;

		public ApiClient()
		{
			httpClient = new HttpClient();
		}

		public async Task<T> GetAsync<T>(string url)
		{
			try
			{
				HttpResponseMessage response = await httpClient.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					string responseContent = await response.Content.ReadAsStringAsync();
					T result = JsonConvert.DeserializeObject<T>(responseContent);
					return result;
				}
				else
				{
				
					throw new Exception($"Request failed with status code {response.StatusCode}");
				}
			}
			catch (Exception ex)
			{
			
				throw new Exception("An error occurred while executing the request", ex);
			}
		}


	}

}
