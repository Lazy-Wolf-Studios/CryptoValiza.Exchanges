using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Common.Interfaces;

namespace CryptoValiza.Exchanges.Services;

internal interface IExchangesServiceFactory
{
	IHealthCheckService GetHealthCheckService(CryptoExchange exchangeCode);
	ITickersService GetTickersService(CryptoExchange exchangeCode);
}
