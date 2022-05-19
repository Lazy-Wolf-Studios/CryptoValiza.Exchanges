using CryptoValiza.Exchanges.Common.Infrastructure;
using CryptoValiza.Exchanges.Services.RegisterExchangesExtensions;
using CryptoValiza.Exchanges.Services.RegisterServiceExtensions;

namespace CryptoValiza.Exchanges;
internal class RegisterExtensions
{
	internal static void RegisterInternalServices(IServiceCollection services)
	{
		services.AddScoped<IKeyProvider, KeyProvider>();

		HealthCheckService.Register(services);
		TickerService.Register(services);
	}

	internal static void RegisterExternalServices(IServiceCollection services)
	{
		BinanceClient.Register(services);
		HuobiClient.Register(services);
		KunaClient.Register(services);





	}
}
