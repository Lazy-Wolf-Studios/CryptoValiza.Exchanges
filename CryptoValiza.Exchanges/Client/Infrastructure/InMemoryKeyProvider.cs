using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Models.Infrastructure;

namespace CryptoValiza.Exchanges.Client.Infrastructure;

internal class InMemoryKeyProvider : IKeyProvider
{
	private readonly Dictionary<string, ApiKey> _apiKeys;

	public InMemoryKeyProvider(CryptoValizaSettings settings)
	{
		_apiKeys = new Dictionary<string, ApiKey>();
		var keysAreUnique = true;
		foreach (var apiKey in settings.KeyRecords)
		{
			keysAreUnique = _apiKeys.TryAdd(ConstructKey(apiKey.Service, apiKey.UserId), new ApiKey
			{
				PublicKey = apiKey.PublicKey,
				SecretKey = apiKey.SecretKey,
			}) & keysAreUnique;
		}

        // TODO: what if failed to ?? throw if keysAreUnique=false 
    }

    public ApiKey GetKey(CryptoExchange cryptoExchange, string userId)
	{
		var key = ConstructKey(cryptoExchange.ToString(), userId);
		return _apiKeys.TryGetValue(key, out var apiKey) ? apiKey : ApiKey.EmptyKey;
	}

	private static string ConstructKey(string service, string userId) => service + ";" + userId;
}
