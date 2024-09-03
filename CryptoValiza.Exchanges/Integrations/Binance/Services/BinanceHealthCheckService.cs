using CryptoValiza.Exchanges.Binance.Models;
using CryptoValiza.Exchanges.Common.Interfaces;
using CryptoValiza.Exchanges.Common.Models;
using CryptoValiza.Exchanges.Common.Utils;
using CryptoValiza.Exchanges.Models;

namespace CryptoValiza.Exchanges.Binance.Services;

internal class BinanceHealthCheckService(IHttpClientFactory httpClientFactory)
    : BaseBinanceService(httpClientFactory), IHealthCheckService
{
    private readonly Endpoint GetServerTimeEndpoint = new Endpoint(HttpMethod.Get, "api/v3/time");

    public async Task<ServerTime> GetServerTime(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.SendAsync<TimeResponse>(GetServerTimeEndpoint, cancellationToken);

        var result = new ServerTime(response.ServerTime, ServerTime.Size.MilliSeconds);

        return result;
    }
}
