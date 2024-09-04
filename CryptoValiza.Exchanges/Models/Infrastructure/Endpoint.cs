namespace CryptoValiza.Exchanges.Models.Infrastructure;

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
