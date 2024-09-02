using CryptoValiza.Exchanges.Binance.Models;
using CryptoValiza.Exchanges.Common.Interfaces;
using CryptoValiza.Exchanges.Common.Models;
using CryptoValiza.Exchanges.Common.Utils;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;

namespace CryptoValiza.Exchanges.Binance.Services;
internal class BinanceHealthCheckService(IHttpClientFactory httpClientFactory) : IHealthCheckService
{
	private const string exchange = nameof(CryptoExchange.Binance);
	private readonly Endpoint GetServerTimeEndpoint = new Endpoint(HttpMethod.Get, "api/v3/time");
	private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    //public async Task<ServerTime> GetServerTime()
    //{
    //    var httpClient = _httpClientFactory.CreateClient(exchange);
    //    var response = await httpClient.GetFromJsonAsync<TimeResponse>(GetServerTimeEndpoint.Url);
    //    return new ServerTime(response.ServerTime);
    //}


    public async Task<ServerTime> GetServerTime(CancellationToken cancellationToken = default)
	{
		var httpClient = _httpClientFactory.CreateClient(exchange);

		var result = await httpClient.SendAsync<TimeResponse>(GetServerTimeEndpoint, cancellationToken);

		return new ServerTime(result.ServerTime, ServerTime.Size.MilliSeconds);
	}
}
