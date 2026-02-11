using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Infrastructure;

namespace CryptoValiza.Exchanges.Services.Interfaces;

internal interface IBalancesService
{
    Task<IReadOnlyCollection<Balance>> GetBalances(ApiKey apiKey, CancellationToken cancellationToken = default);
}
