using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;

namespace CryptoValiza.Exchanges.Client;

public interface IExchangesClient
{
    /// <summary>
    /// Best way to know that server is still here.
    /// </summary>
    /// <param name="exchangeCode"></param>
    /// <returns></returns>
    Task<ServerTime> GetServerTime(CryptoExchange exchangeCode);
	Task<CurrencyTicker> GetTicker(CryptoExchange exchangeCode, string currencyCode);


	Task<IReadOnlyCollection<Deposit>> GetDeposits(CryptoExchange exchangeCode,
		DateTime startDate, DateTime endDate);


	Task<IReadOnlyCollection<Withdrawal>> GetWithdrawals(CryptoExchange exchangeCode,
		DateTime startDate, DateTime endDate);
}
