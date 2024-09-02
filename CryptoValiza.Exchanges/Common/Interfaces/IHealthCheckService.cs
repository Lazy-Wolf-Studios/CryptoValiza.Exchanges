using CryptoValiza.Exchanges.Models;

namespace CryptoValiza.Exchanges.Common.Interfaces;

internal interface IHealthCheckService
{
	Task<ServerTime> GetServerTime(CancellationToken cancellationToken = default);
}
