namespace CryptoValiza.Exchanges.Services;

using CryptoValiza.Exchanges.Kuna;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Services.Interfaces;
using System.Threading.Tasks;

public class KunaHealthCheckService : IHealthCheckService
{
	private readonly IKunaPublicClient _kunaClient;

	public KunaHealthCheckService(IKunaPublicClient kunaClient)
	{
		_kunaClient = kunaClient;
	}

	public async Task<ServerTime> GetServerTime()
	{
		var response = await _kunaClient.GetTimeStamp();
		return new ServerTime(response.Timestamp_miliseconds);
	}
}
