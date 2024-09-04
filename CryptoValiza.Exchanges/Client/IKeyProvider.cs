namespace CryptoValiza.Exchanges.Client;

using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Models.Infrastructure;

public interface IKeyProvider
{
	public ApiKey GetKey(CryptoExchange cryptoExchange, string userId);
}
