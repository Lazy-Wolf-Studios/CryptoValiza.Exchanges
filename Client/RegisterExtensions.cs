using CryptoValiza.Exchanges.Models.Enums;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace CryptoValiza.Exchanges.Client;

public static class RegisterExtensions
{
	public static void RegisterServices(IServiceCollection services)
	{
		//services.AddScoped<IKeyProvider, KeyProvider>();
	}

	public static IServiceCollection AddCryptoValiza(this IServiceCollection services, CryptoValizaSettings? settings = null)
	{
		if (settings == null)
		{
			settings = new CryptoValizaSettings
			{
				ConnectedExchanges = Enum.GetValues<CryptoExchange>()
			};
		}

		RegisterClients(services, settings);

		services.AddScoped<IExchangesClient, ExchangesClient>();

		return services;
	}

	private static void RegisterClients(this IServiceCollection services, CryptoValizaSettings settings)
	{
		foreach (var cex in settings.ConnectedExchanges)
		{
			services.RegisterClient(cex);
		}
	}

	private static void RegisterClient(this IServiceCollection services, CryptoExchange exchange)
	{
		if (apiAddresses.TryGetValue(exchange, out var address))
		{


			services.AddHttpClient(exchange.GetExchangeName(), (client) =>
			{
				client.BaseAddress = new Uri(address);
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			});
		}
		else
		{
			// TODO: log error for unsupported CEX
		}
	}

	private static readonly Dictionary<CryptoExchange, string> apiAddresses = new()
	{
		{ CryptoExchange.Binance , "https://api.binance.com" },
		{ CryptoExchange.ByBit , "https://api.bybit.com"},
		{ CryptoExchange.Kuna , "https://api.kuna.io" },
		{ CryptoExchange.WhiteBit , "https://whitebit.com"},

	};
}
