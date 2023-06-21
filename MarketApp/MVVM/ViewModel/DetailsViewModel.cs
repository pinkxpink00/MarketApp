using CryptoCurrency.Abstractions;
using CryptoCurrency.MVVM.Model;
using CryptoCurrency.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency.MVVM.ViewModel
{


	public class DetailsViewModel : INotifyPropertyChanged
	{

		private string searchText;
		private ObservableCollection<DetailsModel> searchResults;
		private ApiClient apiClient; // Добавлен экземпляр класса ApiClient

		public string SearchText
		{
			get { return searchText; }
			set
			{
				if (searchText != value)
				{
					searchText = value;
					OnPropertyChanged(nameof(SearchText));
					PerformSearch();
				}
			}
		}

		public ObservableCollection<DetailsModel> SearchResults
		{
			get { return searchResults; }
			set
			{
				if (searchResults != value)
				{
					searchResults = value;
					OnPropertyChanged(nameof(SearchResults));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public DetailsViewModel()
		{

			apiClient = new ApiClient();

		}

		private async void PerformSearch()
		{
			try
			{
				
				Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "searchQuery", searchText }
			};

				
			}
			catch (Exception ex)
			{
				
			}
		}
	}
}
