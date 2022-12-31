using CryptoValiza.Exchanges.Common.Interfaces;
using CryptoValiza.Exchanges.Kuna.Models;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Infrastructure;
using Newtonsoft.Json;

namespace CryptoValiza.Exchanges.Kuna.Services;
internal class KunaTickersService : ITickersService
{
	private const string exchange = nameof(Exchanges.Models.Enums.CryptoExchange.Kuna);
	private readonly Endpoint GetServerTimeEndpoint = new Endpoint(HttpMethod.Get, "/v3/timestamp");
	private readonly IHttpClientFactory _httpClientFactory;

	public KunaTickersService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}


	public async Task<CurrencyTicker> GetTicker(string currencyTag)
	{
		var httpClient = _httpClientFactory.CreateClient(exchange);

		var cancellationToken = CancellationToken.None;

		var request = new HttpRequestMessage(GetServerTimeEndpoint.Method, GetServerTimeEndpoint.Url);

		using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
		var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
		response.EnsureSuccessStatusCode(); // check code

		using var streamReader = new StreamReader(stream);
		using var jsonTextReader = new JsonTextReader(streamReader);

		var jsonSerializer = new JsonSerializer();
		var result = jsonSerializer.Deserialize<IEnumerable<object[]>>(jsonTextReader);

		var resultTyped = result.Select(x => new Ticker
		{
			Symbol = x[0].ToString(),
			PriceBid = decimal.Parse(x[1].ToString()),
			OrderbookVolumeBid = decimal.Parse(x[2].ToString()),
			PriceAsk = decimal.Parse(x[3].ToString()),
			OrderbookVolumeAsk = decimal.Parse(x[4].ToString()),
			PriceChangeTarget = decimal.Parse(x[5].ToString()),
			PriceChangePercent = decimal.Parse(x[6].ToString()),
			LastPrice = decimal.Parse(x[7].ToString()),
			TradingVolume = decimal.Parse(x[8].ToString()),
			MaxPrice = decimal.Parse(x[9].ToString()),
			MinPrice = decimal.Parse(x[10].ToString()),
		}).First();

		return new CurrencyTicker
		{
			Symbol = resultTyped.Symbol,
			PriceChange = resultTyped.PriceChangeTarget,
			PriceChangePercent = resultTyped.PriceChangePercent,
			TradingVolume = resultTyped.TradingVolume,
			LastPrice = resultTyped.LastPrice,
			MaxPrice = resultTyped.MaxPrice,
			MinPrice = resultTyped.MinPrice
		};
	}
}
