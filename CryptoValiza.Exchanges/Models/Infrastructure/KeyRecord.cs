namespace CryptoValiza.Exchanges.Models.Infrastructure;

public record KeyRecord
{
	public string Service { get; init; } = string.Empty;
	public string UserId { get; init; } = string.Empty;
	public string PublicKey { get; init; } = string.Empty;
	public string SecretKey { get; init; } = string.Empty;
}
