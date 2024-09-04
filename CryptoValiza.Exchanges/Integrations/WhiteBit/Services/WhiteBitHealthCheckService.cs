using CryptoValiza.Exchanges.Common.Utils;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Infrastructure;
using CryptoValiza.Exchanges.Services.Interfaces;
using CryptoValiza.Exchanges.WhiteBit.Models;

namespace CryptoValiza.Exchanges.WhiteBit.Services;

internal class WhiteBitHealthCheckService(IHttpClientFactory httpClientFactory)
        : BaseWhiteBitService(httpClientFactory), IHealthCheckService
{
    private readonly Endpoint GetServerTimeEndpoint = new Endpoint(HttpMethod.Get, "/api/v4/public/time");

    public async Task<ServerTime> GetServerTime(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.SendAsync<TimeResponse>(GetServerTimeEndpoint, cancellationToken);

        var result = new ServerTime(response.Time, ServerTime.Size.Seconds);

        return result;
    }
}
