using CryptoValiza.Exchanges.Common.Utils;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Infrastructure;
using CryptoValiza.Exchanges.Services.Interfaces;
using Newtonsoft.Json;

namespace CryptoValiza.Exchanges.WhiteBit.Services;

internal class WhiteBitBalancesService(IHttpClientFactory httpClientFactory)
    : BaseWhiteBitService(httpClientFactory), IBalancesService
{
    private readonly Endpoint GetMainBalanceEndpoint = new(HttpMethod.Post, "/api/v4/main-account/balance");
    private readonly Endpoint GetTradeBalanceEndpoint = new(HttpMethod.Post, "/api/v4/trade-account/balance");

    public async Task<IReadOnlyCollection<Balance>> GetBalances(ApiKey apiKey, CancellationToken cancellationToken = default)
    {
        var data = new
        {
            Request = GetMainBalanceEndpoint.Url,
            Nonce = HttpRequestExtensions.GetNonce(),
            NonceWindow = true // boolean, enable nonce validation in time range of current time +/- 5s,
                               // also check if nonce value is unique
        };

        var dataJsonStr = JsonConvert.SerializeObject(data);

        var content = GetContent(dataJsonStr);
        var headers = GetHeaders(dataJsonStr, apiKey);

        var result = await _httpClient.Post<List<Balance>>(GetMainBalanceEndpoint, content, headers, cancellationToken);

        return result.ToList();
    }
}
