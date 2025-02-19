using CryptoValiza.Exchanges.Models.Enums;

namespace CryptoValiza.Exchanges.Kuna.Services;

internal abstract class BaseKunaService(IHttpClientFactory httpClientFactory)
{
    private const string exchange = nameof(CryptoExchange.Kuna);

    protected HttpClient _httpClient = httpClientFactory.CreateClient(exchange);
}
