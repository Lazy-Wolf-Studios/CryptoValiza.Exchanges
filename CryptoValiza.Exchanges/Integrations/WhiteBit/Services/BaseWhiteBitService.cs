using CryptoValiza.Exchanges.Models.Enums;

namespace CryptoValiza.Exchanges.WhiteBit.Services;

internal abstract class BaseWhiteBitService(IHttpClientFactory httpClientFactory)
{
    private const string exchange = nameof(CryptoExchange.WhiteBit);

    protected HttpClient _httpClient = httpClientFactory.CreateClient(exchange);
}
