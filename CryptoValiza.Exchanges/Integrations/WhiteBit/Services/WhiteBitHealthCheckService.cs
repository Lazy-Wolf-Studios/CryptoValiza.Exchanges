using CryptoValiza.Exchanges.Common.Interfaces;
using CryptoValiza.Exchanges.Common.Models;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.WhiteBit.Models;
using Newtonsoft.Json;

namespace CryptoValiza.Exchanges.WhiteBit.Services;

internal class WhiteBitHealthCheckService : IHealthCheckService
{
	private const string exchange = nameof(CryptoExchange.WhiteBit);
	private readonly Endpoint GetServerTimeEndpoint = new Endpoint(HttpMethod.Get, "/api/v4/public/time");
	private readonly IHttpClientFactory _httpClientFactory;

	public WhiteBitHealthCheckService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}



	public async Task<ServerTime> GetServerTime(CancellationToken cancellationToken = default)
	{
		var httpClient = _httpClientFactory.CreateClient(exchange);

		var request = new HttpRequestMessage(GetServerTimeEndpoint.Method, GetServerTimeEndpoint.Url);

		using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
		var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
		response.EnsureSuccessStatusCode(); // check code



		using var streamReader = new StreamReader(stream);
		using var jsonTextReader = new JsonTextReader(streamReader);

		var jsonSerializer = new JsonSerializer();
		var result = jsonSerializer.Deserialize<TimeResponse>(jsonTextReader);

		return new ServerTime(result.Time, ServerTime.Size.Seconds);

	}
}
