using CryptoValiza.Exchanges.Common.Interfaces;
using CryptoValiza.Exchanges.Common.Models;
using CryptoValiza.Exchanges.Kuna.Models;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;
using Newtonsoft.Json;

namespace CryptoValiza.Exchanges.Kuna.Services;

internal class KunaHealthCheckService(IHttpClientFactory httpClientFactory) : IHealthCheckService
{
    private const string exchange = nameof(CryptoExchange.Kuna);
    private readonly Endpoint GetServerTimeEndpoint = new Endpoint(HttpMethod.Get, "/v4/public/timestamp");
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task<ServerTime> GetServerTime(CancellationToken cancellationToken = default)
    {
        var httpClient = _httpClientFactory.CreateClient(exchange);

        var request = new HttpRequestMessage(GetServerTimeEndpoint.Method, GetServerTimeEndpoint.Url);

        using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        response.EnsureSuccessStatusCode(); // check code

        using var streamReader = new StreamReader(stream);
        using var jsonTextReader = new JsonTextReader(streamReader);

        var jsonSerializer = new JsonSerializer();
        var result = jsonSerializer.Deserialize<BaseResponse<TimeStampResponse>>(jsonTextReader);

        var serverTime = new ServerTime(result?.Data?.Timestamp_miliseconds ?? 0, ServerTime.Size.MilliSeconds);
        return serverTime;
    }
}
