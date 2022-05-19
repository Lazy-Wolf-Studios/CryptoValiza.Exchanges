using CryptoValiza.Exchanges.Kuna;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Services.Interfaces;

namespace CryptoValiza.Exchanges.Services.Implementations.Tickers;
public class KunaTickerService : ITickerService
{
	private readonly IKunaPublicClient _kunaClient;

	public KunaTickerService(IKunaPublicClient kunaClient)
	{
		_kunaClient = kunaClient;
	}
	public async Task<Ticker> GetTicker(string currencyTag)
	{
		var result = await _kunaClient.GetTickers(currencyTag);
		return new Ticker();
	}
}
