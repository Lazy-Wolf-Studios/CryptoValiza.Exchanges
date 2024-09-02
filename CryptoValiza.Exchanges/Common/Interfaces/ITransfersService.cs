using CryptoValiza.Exchanges.Models;

namespace CryptoValiza.Exchanges.Common.Interfaces;

internal interface ITransfersService
{
	Task<IReadOnlyCollection<Deposit>> GetDeposits();

	Task<IReadOnlyCollection<Withdrawal>> GetWithdrawals();
}
