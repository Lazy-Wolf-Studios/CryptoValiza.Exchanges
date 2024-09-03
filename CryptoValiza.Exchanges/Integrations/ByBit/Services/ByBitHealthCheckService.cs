using CryptoValiza.Exchanges.ByBit.Models;
using CryptoValiza.Exchanges.Common.Interfaces;
using CryptoValiza.Exchanges.Common.Models;
using CryptoValiza.Exchanges.Common.Utils;
using CryptoValiza.Exchanges.Models;

namespace CryptoValiza.Exchanges.ByBit.Services;

internal class ByBitHealthCheckService(IHttpClientFactory httpClientFactory)
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
