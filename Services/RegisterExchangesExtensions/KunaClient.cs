using CryptoValiza.Exchanges.Kuna;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace CryptoValiza.Exchanges.Services.RegisterExchangesExtensions;
public static class KunaClient
{
	public static void Register(this IServiceCollection services)
	{
		services.AddHttpClient(nameof(IKunaPublicClient), c =>
		{
			c.BaseAddress = new Uri("https://api.kuna.io");
		})
		.AddTypedClient(c => RestService.For<IKunaPublicClient>(c));

		//services.AddScoped<KunaHeadersHttpMessageHandler>();

		//services.AddRefitClient<IKunaPrivateClient>()
		//   .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.kuna.io:443/"))
		//   .AddHttpMessageHandler<KunaHeadersHttpMessageHandler>();		
	}
}

