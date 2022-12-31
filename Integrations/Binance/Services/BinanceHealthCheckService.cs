using CryptoValiza.Exchanges.Binance.Models;
using CryptoValiza.Exchanges.Common.Interfaces;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Models.Infrastructure;
using Newtonsoft.Json;

namespace CryptoValiza.Exchanges.Binance.Services;
internal class BinanceHealthCheckService : IHealthCheckService
{
    private const string exchange = nameof(CryptoExchange.Binance);
    private readonly Endpoint GetServerTimeEndpoint = new Endpoint(HttpMethod.Get, "api/v3/time");
    private readonly IHttpClientFactory _httpClientFactory;

    public BinanceHealthCheckService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    //public async Task<ServerTime> GetServerTime()
    //{
    //    var httpClient = _httpClientFactory.CreateClient(exchange);
    //    var response = await httpClient.GetFromJsonAsync<TimeResponse>(GetServerTimeEndpoint.Url);
    //    return new ServerTime(response.ServerTime);
    //}


    public async Task<ServerTime> GetServerTime()
    {
        var httpClient = _httpClientFactory.CreateClient(exchange);

        var cancellationToken = CancellationToken.None;

        var request = new HttpRequestMessage(GetServerTimeEndpoint.Method, GetServerTimeEndpoint.Url);

        using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        response.EnsureSuccessStatusCode(); // check code

        using var streamReader = new StreamReader(stream);
        using var jsonTextReader = new JsonTextReader(streamReader);

        var jsonSerializer = new JsonSerializer();
        var result = jsonSerializer.Deserialize<TimeResponse>(jsonTextReader);

        return new ServerTime(result.ServerTime, ServerTime.Size.MilliSeconds);
    }
}
