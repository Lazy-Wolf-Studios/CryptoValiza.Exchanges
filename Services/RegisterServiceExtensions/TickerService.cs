using CryptoValiza.Exchanges.Services.Implementations.Tickers;
using CryptoValiza.Exchanges.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoValiza.Exchanges.Services.RegisterServiceExtensions;
public static class TickerService
{
	public static void Register(this IServiceCollection services)
	{
		services.AddTransient<KunaTickerService>();
		services.AddTransient<BinanceTickerService>();

		services.AddSingleton<Func<string, ITickerService>>(serviceProvider => (key) =>
		{
			switch (key)
			{
				case "Kuna":
					return serviceProvider.GetService<KunaTickerService>();
				case "Binance":
					return serviceProvider.GetService<BinanceTickerService>();
				default:
					throw new KeyNotFoundException();
			}
		});
	}
}