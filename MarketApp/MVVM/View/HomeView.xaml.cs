using CryptoCurrency.Abstractions;
using CryptoCurrency.MVVM.ViewModel;
using CryptoCurrency.Services;
using System.Windows.Controls;

namespace CryptoCurrency.MVVM.View
{
	public partial class HomeView : UserControl
	{
		public HomeView()
		{
			InitializeComponent();

			IApiClient apiClient = new ApiClient();

			DataContext = new HomeViewModel(apiClient);

			if (DataContext is HomeViewModel homeViewModel)
			{
				homeViewModel.ApiClient = apiClient;
			}
		}
	}
}
