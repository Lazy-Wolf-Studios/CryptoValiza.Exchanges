using CryptoValiza.Exchanges.Common.Utils;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Models.Infrastructure;
using CryptoValiza.Exchanges.Services.Interfaces;
using Newtonsoft.Json;

namespace CryptoValiza.Exchanges.WhiteBit.Services;

internal class WhiteBitBalancesService : WhiteBitBaseService, IBalancesService
{
    private const string exchange = nameof(CryptoExchange.WhiteBit);
    private readonly Endpoint GetBalanceEndpoint = new Endpoint(HttpMethod.Post, "/api/v4/trade-account/balance");
    private readonly IHttpClientFactory _httpClientFactory;

    public WhiteBitBalancesService(IHttpClientFactory httpClientFactory, ApiKey apiKey) : base(apiKey)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IReadOnlyCollection<Balance>> GetBalances()
    {
        var httpClient = _httpClientFactory.CreateClient(exchange);
        var cancellationToken = CancellationToken.None;

        var data = new
        {
            Request = GetBalanceEndpoint.Url,
            Nonce = HttpRequestExtensions.GetNonce(),
            NonceWindow = true // boolean, enable nonce validation in time range of current time +/- 5s,
                               // also check if nonce value is unique

        };

        var dataJsonStr = JsonConvert.SerializeObject(data);

        var content = GetContent(dataJsonStr);
        var headers = GetHeaders(dataJsonStr);

        var result = await httpClient.SendAsync<List<Balance>>(GetBalanceEndpoint, content, headers, cancellationToken);

        return result.ToList();
    }
}
