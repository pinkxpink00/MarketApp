using CryptoCurrency.Abstractions;
using CryptoCurrency.Core;
using CryptoCurrency.Services;
using System.Windows.Navigation;

namespace CryptoCurrency.MVVM.ViewModel
{

	public class MainViewModel : Core.ViewModel
	{
		private INavigationService _navigation;

		private IApiClient _apiClient;

		public INavigationService Navigation
		{
			get => _navigation;

			set
			{
				_navigation = value;
				OnPropertyChanged();
			}
		}

		public IApiClient ApiClient
		{
			get => _apiClient;

			set
			{
				_apiClient = value;
				OnPropertyChanged();
			}
		}

		public RelayCommand NavigateToHomeCommand { get; set; }


		public MainViewModel(INavigationService navService, IApiClient apiClient)
		{
			Navigation = navService;
			ApiClient = apiClient;

			NavigateToHomeCommand = new RelayCommand(execute: (o) => { Navigation.NavigateTo<HomeViewModel>(); }, canExecute: (o) => true);

		}

		public HomeViewModel HomeViewModel { get; set; }

		private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set { _currentView = value; OnPropertyChanged(); }
		}

	}


}