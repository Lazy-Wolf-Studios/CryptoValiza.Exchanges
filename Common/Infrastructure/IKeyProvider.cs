namespace CryptoValiza.Exchanges.Common.Infrastructure;

using CryptoValiza.Exchanges.Common.Models;

internal interface IKeyProvider
{
	public ApiKey GetKey(string serviceName);
	public bool AddKey(string serviceName, ApiKey apiKey);
}
