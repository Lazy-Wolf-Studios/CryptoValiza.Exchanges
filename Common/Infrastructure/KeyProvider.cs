namespace CryptoValiza.Exchanges.Common.Infrastructure;

using CryptoValiza.Exchanges.Common.Models;

internal class KeyProvider : IKeyProvider
{
	public bool AddKey(string serviceName, ApiKey apiKey, int userId)
	{
		throw new NotImplementedException();
	}

	public ApiKey GetKey(string serviceName, int userId)
	{
		throw new NotImplementedException();
	}
}
