using CryptoValiza.Exchanges.Models;

namespace CryptoValiza.Exchanges.Common.Interfaces;

internal interface IBalancesService
{
	Task<IReadOnlyCollection<Balance>> GetBalances();
}
