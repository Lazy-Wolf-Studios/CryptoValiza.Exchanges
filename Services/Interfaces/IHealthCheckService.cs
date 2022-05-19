using CryptoValiza.Exchanges.Models;

namespace CryptoValiza.Exchanges.Services.Interfaces;
public interface IHealthCheckService
{
	Task<ServerTime> GetServerTime();
}
