using CryptoValiza.Exchanges.Binance;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace CryptoValiza.Exchanges.Services.RegisterExchangesExtensions;
public static class BinanceClient
{
	public static void Register(this IServiceCollection services)
	{
		services.AddHttpClient(nameof(IBinancePublicClient), c =>
		{
			c.BaseAddress = new Uri("https://api.binance.com/api");
		})
		.AddTypedClient(c => RestService.For<IBinancePublicClient>(c));
	}
}
