namespace CryptoValiza.Exchanges.Models.Errors;

public class ApiKeyWasNotProvidedException : Exception
{
	private const string message = "Api Key was not provided for private API";
	public ApiKeyWasNotProvidedException() : base(message)
	{
	}
}
