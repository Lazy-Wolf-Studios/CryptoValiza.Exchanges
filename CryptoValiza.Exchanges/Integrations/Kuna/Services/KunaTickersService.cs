using CryptoValiza.Exchanges.Common.Utils;
using CryptoValiza.Exchanges.Kuna.Models;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Infrastructure;
using CryptoValiza.Exchanges.Services.Interfaces;

namespace CryptoValiza.Exchanges.Kuna.Services;
internal class KunaTickersService(IHttpClientFactory httpClientFactory) : BaseKunaService(httpClientFactory), ITickersService
{
    private readonly Endpoint GetTickerEndpoint = new Endpoint(HttpMethod.Get, "/v4/markets/public/tickers?pairs={symbol}");

    public async Task<CurrencyTicker> GetTicker(string currencyTag, CancellationToken cancellationToken = default)
    {
        currencyTag = "BTC_USDT";
        var endPoint = new Endpoint(GetTickerEndpoint.Method, GetTickerEndpoint.Url.Replace("{symbol}", currencyTag));

        var response = await _httpClient.SendAsync<BaseResponse<List<Ticker>>>(endPoint, cancellationToken);

        var result = response?.Data?.Select(x => new CurrencyTicker
        {
            Symbol = x.Pair,
            PriceChange = decimal.Parse(x.PriceChange),
            PriceChangePercent = decimal.Parse(x.PercentagePriceChange),
            TradingVolume = decimal.Parse(x.BaseVolume),
            LastPrice = decimal.Parse(x.Price),
            MaxPrice = decimal.Parse(x.High),
            MinPrice = decimal.Parse(x.Low)
        }).FirstOrDefault(new CurrencyTicker());

        return result ?? new CurrencyTicker();
    }
}
