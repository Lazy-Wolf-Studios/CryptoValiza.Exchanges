using CryptoValiza.Exchanges.Binance.Models;
using CryptoValiza.Exchanges.Common.Utils;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Infrastructure;
using CryptoValiza.Exchanges.Services.Interfaces;

namespace CryptoValiza.Exchanges.Binance.Services;
internal class BinanceTickersService(IHttpClientFactory httpClientFactory) : BaseBinanceService(httpClientFactory), ITickersService
{
    private readonly Endpoint GetTickerEndpoint = new Endpoint(HttpMethod.Get, "api/v3/ticker/24hr?symbol={symbol}");

    public async Task<CurrencyTicker> GetTicker(string currencyTag, CancellationToken cancellationToken = default)
    {
        currencyTag = "BTCUSDT";
        var endPoint = new Endpoint(GetTickerEndpoint.Method, GetTickerEndpoint.Url.Replace("{symbol}", currencyTag));
        var response = await _httpClient.SendAsync<Ticker24Statistics>(endPoint, cancellationToken);

        var result = new CurrencyTicker
        {
            Symbol = response.Symbol,
            PriceChange = decimal.Parse(response.PriceChange),
            PriceChangePercent = decimal.Parse(response.PriceChangePercent),
            TradingVolume = decimal.Parse(response.Volume),
            LastPrice = decimal.Parse(response.LastPrice),
            MaxPrice = decimal.Parse(response.HighPrice),
            MinPrice = decimal.Parse(response.LowPrice)
        };

        return result;
    }
}