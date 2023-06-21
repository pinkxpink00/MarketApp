using CryptoCurrency.Abstractions;
using CryptoCurrency.Core;
using CryptoCurrency.MVVM.ViewModel;
using CryptoCurrency.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoCurrency
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly ServiceProvider _servicesProvider;

		public App()
		{
			IServiceCollection services = new ServiceCollection();

			services.AddSingleton<MainWindow>(ServiceProvider => new MainWindow
			{
				DataContext = ServiceProvider.GetRequiredService<MainViewModel>()
			});
			services.AddSingleton<MainViewModel>();
			services.AddSingleton<HomeViewModel>();
			services.AddSingleton<DetailsViewModel>();
			services.AddSingleton<INavigationService, NavigationServices>();

			services.AddSingleton<Func<Type, ViewModel>>(ServiceProvider => viewModelType => (ViewModel)ServiceProvider.GetRequiredService(viewModelType));
			services.AddSingleton<IApiClient, ApiClient>();

			_servicesProvider = services.BuildServiceProvider();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			var mainWindow = _servicesProvider.GetRequiredService<MainWindow>();
			mainWindow.Show();
			base.OnStartup(e);
		}
	}
}
