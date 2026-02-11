using CryptoValiza.Exchanges.Models.Enums;
using System.Text;

namespace CryptoValiza.Exchanges.Binance.Services;

internal abstract class BaseBinanceService(IHttpClientFactory httpClientFactory)
{
    protected const string exchange = nameof(CryptoExchange.Binance);

    protected HttpClient _httpClient = httpClientFactory.CreateClient(exchange);

    protected StringContent GetContent(string dataJsonStr)
    {
        var content = new StringContent(dataJsonStr, Encoding.UTF8, "application/json");
        return content;
    }
}
