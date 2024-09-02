using CryptoValiza.Exchanges.Binance.Services;
using CryptoValiza.Exchanges.ByBit.Services;
using CryptoValiza.Exchanges.Common.Interfaces;
using CryptoValiza.Exchanges.Kuna.Services;
using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Models.Infrastructure;
using CryptoValiza.Exchanges.WhiteBit.Services;

namespace CryptoValiza.Exchanges.Services;

internal class ExchangesServiceFactory : IExchangesServiceFactory
{
	private readonly IHttpClientFactory _httpClientFactory;

	internal ExchangesServiceFactory(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public IHealthCheckService GetHealthCheckService(CryptoExchange exchangeCode)
	{
		switch (exchangeCode)
		{
			case CryptoExchange.Binance:
			case CryptoExchange.BinanceUs:
				return new BinanceHealthCheckService(_httpClientFactory);
			case CryptoExchange.ByBit:
				return new ByBitHealthCheckService(_httpClientFactory);
			case CryptoExchange.CexIo:
				break;
			case CryptoExchange.Ftx:
				break;
			case CryptoExchange.GateIo:
				break;
			case CryptoExchange.Huobi:
				break;
			case CryptoExchange.Kraken:
				break;
			case CryptoExchange.KuCoin:
				break;
			case CryptoExchange.Kuna:
				return new KunaHealthCheckService(_httpClientFactory);
			case CryptoExchange.Poloniex:
				break;
			case CryptoExchange.WhiteBit:
				return new WhiteBitHealthCheckService(_httpClientFactory);
		}
		throw new KeyNotFoundException();
	}

	public ITickersService GetTickersService(CryptoExchange exchangeCode)
	{
		switch (exchangeCode)
		{
			case CryptoExchange.Binance:
				return new BinanceTickersService(_httpClientFactory);
			case CryptoExchange.ByBit:
				break;
			case CryptoExchange.CexIo:
				break;
			case CryptoExchange.Ftx:
				break;
			case CryptoExchange.GateIo:
				break;
			case CryptoExchange.Huobi:
				break;
			case CryptoExchange.Kraken:
				break;
			case CryptoExchange.KuCoin:
				break;
			case CryptoExchange.Kuna:
				return new KunaTickersService(_httpClientFactory);
			case CryptoExchange.Poloniex:
				break;
		}
		throw new KeyNotFoundException();
	}

	public ITransfersService GetTransfersService(CryptoExchange exchangeCode)
	{
		switch (exchangeCode)
		{
			case CryptoExchange.Binance:
				return new BinanceTransfersService(_httpClientFactory);
		}
		throw new KeyNotFoundException();
	}

	public IBalancesService GetBalancesService(CryptoExchange exchangeCode, ApiKey apiKey)
	{
		switch (exchangeCode)
		{
			case CryptoExchange.WhiteBit:
				return new WhiteBitBalancesService(_httpClientFactory, apiKey);
		}
		throw new KeyNotFoundException();
	}
}
