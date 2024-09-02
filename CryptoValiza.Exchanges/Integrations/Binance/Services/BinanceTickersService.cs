using CryptoValiza.Exchanges.Binance.Models;
using CryptoValiza.Exchanges.Common.Interfaces;
using CryptoValiza.Exchanges.Common.Models;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;
using Newtonsoft.Json;

namespace CryptoValiza.Exchanges.Binance.Services;
internal class BinanceTickersService : ITickersService
{
	private const string exchange = nameof(CryptoExchange.Binance);
	private readonly Endpoint GetTickerEndpoint = new Endpoint(HttpMethod.Get, "api/v3/ticker/24hr?symbol={symbol}");
	private readonly IHttpClientFactory _httpClientFactory;

	public BinanceTickersService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<CurrencyTicker> GetTicker(string currencyTag)
	{
		var httpClient = _httpClientFactory.CreateClient(exchange);


		var cancellationToken = CancellationToken.None;
		var request = new HttpRequestMessage(GetTickerEndpoint.Method, GetTickerEndpoint.Url.Replace("{symbol}", currencyTag));

		using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
		var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
		response.EnsureSuccessStatusCode(); // check code

		using var streamReader = new StreamReader(stream);
		using var jsonTextReader = new JsonTextReader(streamReader);

		var jsonSerializer = new JsonSerializer();
		var result = jsonSerializer.Deserialize<Ticker24Statistics>(jsonTextReader);

		return new CurrencyTicker
		{
			Symbol = result.Symbol,
			PriceChange = decimal.Parse(result.PriceChange),
			PriceChangePercent = decimal.Parse(result.PriceChangePercent),
			TradingVolume = decimal.Parse(result.Volume),
			LastPrice = decimal.Parse(result.LastPrice),
			MaxPrice = decimal.Parse(result.HighPrice),
			MinPrice = decimal.Parse(result.LowPrice)
		};
	}
}