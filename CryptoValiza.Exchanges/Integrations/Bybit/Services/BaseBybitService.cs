using CryptoValiza.Exchanges.Models.Enums;

namespace CryptoValiza.Exchanges.Bybit.Services;

internal abstract class BaseBybitService(IHttpClientFactory httpClientFactory)
{
    private const string exchange = nameof(CryptoExchange.Bybit);

    protected HttpClient _httpClient = httpClientFactory.CreateClient(exchange);
}
