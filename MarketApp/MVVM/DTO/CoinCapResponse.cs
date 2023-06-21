using CryptoCurrency.MVVM.Model;
using Newtonsoft.Json;

namespace CryptoCurrency.MVVM.DTO
{
	public class CoinCapResponse
	{
		[JsonProperty("data")]
		public CurrencyData[] Data { get; set; }
	}
}
