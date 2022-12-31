namespace CryptoValiza.Exchanges.Models.Infrastructure;

internal class Endpoint
{
	internal Endpoint(HttpMethod method, string url)
	{
		this.Method = method;
		this.Url = url;
	}
	internal HttpMethod Method { get; }
	internal string Url { get; }
}
