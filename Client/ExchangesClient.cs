using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Services;
using Microsoft.Extensions.Options;

namespace CryptoValiza.Exchanges.Client;

public class ExchangesClient : IExchangesClient
{
	private readonly IExchangesServiceFactory _exchangeServiceFactory;
	private readonly CryptoValizaSettings _settings;

	public ExchangesClient(IHttpClientFactory httpClientFactory)//, IOptions<CryptoValizaSettings> settings)
	{
		_exchangeServiceFactory = new ExchangesServiceFactory(httpClientFactory);
		// _settings = settings.Value ?? throw new NullReferenceException(nameof(settings));
	}

	/// <summary>
	/// Best way to know that server is still here.
	/// </summary>
	/// <param name="exchangeCode"></param>
	/// <returns></returns>
	public async Task<ServerTime> GetServerTime(CryptoExchange exchangeCode)
	{
		var service = _exchangeServiceFactory.GetHealthCheckService(exchangeCode);
		var serverTime = await service.GetServerTime();
		return serverTime;
	}

	/// <summary>
	/// Some general info about CryptoCurrency.
	/// </summary>
	/// <param name="exchangeCode"></param>
	/// <param name="currencyCode"></param>
	/// <returns></returns>
	// TODO: will be modified, need to realize what info to get as "General". BTCUSDT - is not the best parameter
	public async Task<CurrencyTicker> GetTicker(CryptoExchange exchangeCode, string currencyCode)
	{
		var service = _exchangeServiceFactory.GetTickersService(exchangeCode);
		var currencyTicker = await service.GetTicker(currencyCode);
		return currencyTicker;
	}



}