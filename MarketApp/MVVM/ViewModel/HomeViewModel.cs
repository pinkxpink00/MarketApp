using CryptoCurrency.Abstractions;
using CryptoCurrency.MVVM.DTO;
using CryptoCurrency.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CryptoCurrency.MVVM.ViewModel
{
	public class HomeViewModel : Core.ViewModel
	{
		private readonly IApiClient _apiClient;

		public IApiClient ApiClient { get; set; }

		private ObservableCollection<CurrencyData> _topCurrencies = new ObservableCollection<CurrencyData>();

		public ObservableCollection<CurrencyData> TopCurrencies
		{
			get { return _topCurrencies; }
			set
			{
				if (_topCurrencies != value)
				{
					_topCurrencies = value;
					OnPropertyChanged(); 
				}
			}
		}

		public HomeViewModel()
		{
			_apiClient = null;
		}

		public HomeViewModel(IApiClient apiClient)
		{
			_apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));

			LoadTopCurrencies();
		}

		private async void LoadTopCurrencies()
		{
			var parameters = new Dictionary<string, string>
			{
				{ "limit", "10" }
			};

			try
			{
				CoinCapResponse response = await _apiClient.GetAsync<CoinCapResponse>("https://api.coincap.io/v2/assets?limit=10");

				TopCurrencies.Clear();
				foreach (var currency in response.Data)
				{
					_topCurrencies.Add(currency);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error loading top currencies: {ex.Message}");
			}
		}
	}
}
