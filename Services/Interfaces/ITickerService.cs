using CryptoValiza.Exchanges.Models;

namespace CryptoValiza.Exchanges.Services.Interfaces;
public interface ITickerService
{
	public Task<Ticker> GetTicker(string currencyTag);
}
