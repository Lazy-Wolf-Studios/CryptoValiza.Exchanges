namespace CryptoValiza.Exchanges.Common.Infrastructure;

using CryptoValiza.Exchanges.Common.Models;

internal interface IKeyProvider
{
	public ApiKey GetKey(string serviceName, int userId);
	public bool AddKey(string serviceName, ApiKey apiKey, int userId);
}
