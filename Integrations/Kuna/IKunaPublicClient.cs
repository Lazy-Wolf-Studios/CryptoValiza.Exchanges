using CryptoValiza.Exchanges.Kuna.Models;
using Refit;

namespace CryptoValiza.Exchanges.Kuna;
[Headers("accept: application/json")]
public interface IKunaPublicClient
{
	[Get("/v3/timestamp")]
	Task<TimeStampResponse> GetTimeStamp();

	[Get("/v3/currencies")]
	Task<IEnumerable<Currency>> GetCurrencies();

	[Get("/v3/markets")]
	Task<IEnumerable<Market>> GetMarkets();

	/// <summary>
	/// # Returns info for btcuah, kunbtc и ethuah
	/// curl https://api.kuna.io/v3/tickers?symbols=btcuah,kunbtc,ethuah
	/// # Returns info only for btcuah
	/// curl https://api.kuna.io/v3/tickers?symbols=btcuah
	/// # Returns info for all active markets
	/// curl https://api.kuna.io/v3/tickers?symbols=ALL
	/// </summary>
	[Get("/v3/tickers?symbols={symbols}")]
	Task<IEnumerable<object[]>> GetTickers(string symbols);
}
