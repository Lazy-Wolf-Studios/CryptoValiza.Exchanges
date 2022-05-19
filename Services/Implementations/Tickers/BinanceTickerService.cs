using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Services.Interfaces;

namespace CryptoValiza.Exchanges.Services.Implementations.Tickers;
public class BinanceTickerService : ITickerService
{
	public async Task<Ticker> GetTicker(string currencyTag)
	{
		throw new NotImplementedException();
	}

}