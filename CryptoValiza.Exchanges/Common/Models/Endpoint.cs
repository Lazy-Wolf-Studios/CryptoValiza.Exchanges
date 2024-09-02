namespace CryptoValiza.Exchanges.Common.Models;

internal record Endpoint
{
	internal Endpoint(HttpMethod method, string url)
	{
		Method = method;
		Url = url;
	}
	internal HttpMethod Method { get; }
	internal string Url { get; }
}
