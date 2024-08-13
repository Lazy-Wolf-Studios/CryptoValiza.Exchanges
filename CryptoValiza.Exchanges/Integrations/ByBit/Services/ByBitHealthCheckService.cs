using CryptoValiza.Exchanges.ByBit.Models;
using CryptoValiza.Exchanges.Common.Interfaces;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Models.Infrastructure;
using Newtonsoft.Json;

namespace CryptoValiza.Exchanges.ByBit.Services;

internal class ByBitHealthCheckService : IHealthCheckService
{
	// curl https://api-testnet.bybit.com/v3/public/time
	/*
     
    GET & DELETE methods (shared):
        50 requests per second for 2 consecutive minutes
        70 requests per second for 5 consecutive seconds
    POST method:
        20 requests per second for 2 consecutive minutes
        50 requests per second for 5 consecutive seconds

     
     */
	/*
	 
	 {
    "retCode": 0,
    "retMsg": "OK",
    "result": {
        "timeSecond": "1664267152",
        "timeNano": "1664267152228343045"
    },
    "retExtInfo": {},
    "time": 1664267152228
}
	 
	 
	 */
	private const string exchange = nameof(CryptoExchange.ByBit);
	private readonly Endpoint GetServerTimeEndpoint = new Endpoint(HttpMethod.Get, "/v3/public/time");
	private readonly IHttpClientFactory _httpClientFactory;

	public ByBitHealthCheckService(IHttpClientFactory httpClientFactory)
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
		var result = jsonSerializer.Deserialize<BaseResponse<TimeResponse>>(jsonTextReader);

		var resultR = result.Result;

		return new ServerTime(resultR.TimeSecond, ServerTime.Size.Seconds);
	}

}
