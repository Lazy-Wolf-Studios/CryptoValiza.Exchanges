using CryptoValiza.Exchanges.Models;

namespace CryptoValiza.Exchanges.Services.Interfaces;

internal interface IHealthCheckService
{
    Task<ServerTime> GetServerTime(CancellationToken cancellationToken = default);
}
