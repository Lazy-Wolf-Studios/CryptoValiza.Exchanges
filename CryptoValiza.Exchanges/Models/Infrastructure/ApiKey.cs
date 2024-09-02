namespace CryptoValiza.Exchanges.Models.Infrastructure;

public record ApiKey
{
	public string PublicKey { get; init; } = string.Empty;
	public string SecretKey { get; init; } = string.Empty;

	internal static readonly ApiKey EmptyKey = new ApiKey();
}
