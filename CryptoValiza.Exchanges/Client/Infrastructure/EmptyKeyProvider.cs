using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Models.Infrastructure;

namespace CryptoValiza.Exchanges.Client.Infrastructure;

internal class EmptyKeyProvider : IKeyProvider
{
	public ApiKey GetKey(CryptoExchange cryptoExchange, string userId)
	{
		return ApiKey.EmptyKey;
	}
}
