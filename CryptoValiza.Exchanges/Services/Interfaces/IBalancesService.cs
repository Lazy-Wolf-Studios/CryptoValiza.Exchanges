using CryptoValiza.Exchanges.Models;

namespace CryptoValiza.Exchanges.Services.Interfaces;

internal interface IBalancesService
{
    Task<IReadOnlyCollection<Balance>> GetBalances();
}
