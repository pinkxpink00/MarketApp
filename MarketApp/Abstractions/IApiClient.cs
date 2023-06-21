using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCurrency.Abstractions
{
	public interface IApiClient
	{
		Task<T> GetAsync<T>(string url);
	}
}
