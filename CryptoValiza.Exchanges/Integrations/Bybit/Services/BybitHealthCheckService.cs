using CryptoValiza.Exchanges.Bybit.Models;
using CryptoValiza.Exchanges.Common.Utils;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Infrastructure;
using CryptoValiza.Exchanges.Services.Interfaces;

namespace CryptoValiza.Exchanges.Bybit.Services;

internal class BybitHealthCheckService(IHttpClientFactory httpClientFactory)
    : BaseBybitService(httpClientFactory), IHealthCheckService
{
    private readonly Endpoint GetServerTimeEndpoint = new Endpoint(HttpMethod.Get, "/v3/public/time");

    public async Task<ServerTime> GetServerTime(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.SendAsync<BaseResponse<TimeResponse>>(GetServerTimeEndpoint, cancellationToken);

        var result = new ServerTime(response.Result.TimeSecond, ServerTime.Size.Seconds);

        return result;
    }
}
