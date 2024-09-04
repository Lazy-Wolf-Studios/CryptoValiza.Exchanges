using CryptoValiza.Exchanges.Common.Utils;
using CryptoValiza.Exchanges.Kuna.Models;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Infrastructure;
using CryptoValiza.Exchanges.Services.Interfaces;

namespace CryptoValiza.Exchanges.Kuna.Services;

internal class KunaHealthCheckService(IHttpClientFactory httpClientFactory)
    : BaseKunaService(httpClientFactory), IHealthCheckService
{
    private readonly Endpoint GetServerTimeEndpoint = new Endpoint(HttpMethod.Get, "/v4/public/timestamp");

    public async Task<ServerTime> GetServerTime(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.SendAsync<BaseResponse<TimeResponse>>(GetServerTimeEndpoint, cancellationToken);

        var result = new ServerTime(response.Data?.Timestamp_miliseconds ?? 0, ServerTime.Size.MilliSeconds);

        return result;
    }
}
