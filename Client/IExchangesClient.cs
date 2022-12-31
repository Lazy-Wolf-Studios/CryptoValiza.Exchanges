using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;

namespace CryptoValiza.Exchanges.Client;

public interface IExchangesClient
{
	Task<ServerTime> GetServerTime(CryptoExchange exchangeCode);
	Task<CurrencyTicker> GetTicker(CryptoExchange exchangeCode, string currencyCode);
}
