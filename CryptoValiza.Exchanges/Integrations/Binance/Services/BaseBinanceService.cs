using CryptoValiza.Exchanges.Models.Enums;

namespace CryptoValiza.Exchanges.Binance.Services;

internal abstract class BaseBinanceService(IHttpClientFactory httpClientFactory)
{
    private const string exchange = nameof(CryptoExchange.Binance);

    protected HttpClient _httpClient = httpClientFactory.CreateClient(exchange);
}
