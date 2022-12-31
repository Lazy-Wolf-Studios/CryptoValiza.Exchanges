using CryptoValiza.Exchanges.Common.Interfaces;
using CryptoValiza.Exchanges.Kuna.Models;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Models.Infrastructure;
using Newtonsoft.Json;

namespace CryptoValiza.Exchanges.Kuna.Services;

internal class KunaHealthCheckService : IHealthCheckService
{
	private const string exchange = nameof(CryptoExchange.Kuna);
	private readonly Endpoint GetServerTimeEndpoint = new Endpoint(HttpMethod.Get, "/v3/timestamp");
	private readonly IHttpClientFactory _httpClientFactory;

	public KunaHealthCheckService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<ServerTime> GetServerTime()
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
		var result = jsonSerializer.Deserialize<TimeStampResponse>(jsonTextReader);

		return new ServerTime(result.Timestamp_miliseconds, ServerTime.Size.MilliSeconds);
	}
}
