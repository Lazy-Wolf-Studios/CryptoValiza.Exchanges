using CryptoValiza.Exchanges.Binance;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Services.Interfaces;

namespace CryptoValiza.Exchanges.Services.Implementations.HealthCheck;
public class BinanceHealthCheckService : IHealthCheckService
{
	private readonly IBinancePublicClient _binanceClient;

	public BinanceHealthCheckService(IBinancePublicClient binanceClient)
	{
		_binanceClient = binanceClient;
	}

	public async Task<ServerTime> GetServerTime()
	{
		var response = await _binanceClient.GetTime();
		return new ServerTime(response.ServerTime);
	}
}
