using CryptoValiza.Exchanges.Models.Enums;

namespace CryptoValiza.Exchanges.ByBit.Services;

internal abstract class BaseBybitService(IHttpClientFactory httpClientFactory)
{
    private const string exchange = nameof(CryptoExchange.ByBit);

    protected HttpClient _httpClient = httpClientFactory.CreateClient(exchange);
}
