using CryptoValiza.Exchanges.Services.Implementations.HealthCheck;
using CryptoValiza.Exchanges.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoValiza.Exchanges.Services.RegisterServiceExtensions;
public static class HealthCheckService
{
	public static void Register(this IServiceCollection services)
	{
		services.AddTransient<KunaHealthCheckService>();
		services.AddTransient<BinanceHealthCheckService>();

		services.AddSingleton<Func<string, IHealthCheckService>>(serviceProvider => (key) =>
		{
			switch (key)
			{
				case "Kuna":
					return serviceProvider.GetService<KunaHealthCheckService>();
				case "Binance":
					return serviceProvider.GetService<BinanceHealthCheckService>();
				default:
					throw new KeyNotFoundException();
			}
		});
	}
}
