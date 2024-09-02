using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Common.Interfaces;
using CryptoValiza.Exchanges.Models.Infrastructure;

namespace CryptoValiza.Exchanges.Services;

internal interface IExchangesServiceFactory
{
	IHealthCheckService GetHealthCheckService(CryptoExchange exchangeCode);
	ITickersService GetTickersService(CryptoExchange exchangeCode);
	ITransfersService GetTransfersService(CryptoExchange exchangeCode);
	IBalancesService GetBalancesService(CryptoExchange exchangeCode, ApiKey apiKey);
}
