using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Infrastructure;

namespace CryptoValiza.Exchanges.Services.Interfaces;

internal interface ITransfersService
{
    Task<IReadOnlyCollection<FiatDeposit>> GetFiatDeposits(ApiKey apiKey, DateTimeOffset startDate, DateTimeOffset endDate, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<FiatWithdrawal>> GetFiatWithdrawals(ApiKey apiKey, DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<CryptoDeposit>> GetCryptoDeposits(ApiKey apiKey, DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<CryptoWithdrawal>> GetCryptoWithdrawals(ApiKey apiKey, DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
}
