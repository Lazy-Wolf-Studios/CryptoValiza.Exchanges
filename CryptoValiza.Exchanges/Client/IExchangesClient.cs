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

    /// <summary>
    /// Some general info about CryptoCurrency.
    /// TODO: will be modified, need to realize what info to get as "General". BTCUSDT - is not the best parameter
    /// TODO: understand which data to return, CExes return very different data
    /// </summary>
    /// <param name="exchangeCode"></param>
    /// <param name="currencyCode"></param>
    /// <returns></returns>
    Task<CurrencyTicker> GetTicker(CryptoExchange exchangeCode, string currencyCode);


	Task<IReadOnlyCollection<Deposit>> GetDeposits(CryptoExchange exchangeCode,
		DateTime startDate, DateTime endDate);


	Task<IReadOnlyCollection<Withdrawal>> GetWithdrawals(CryptoExchange exchangeCode,
		DateTime startDate, DateTime endDate);
}
