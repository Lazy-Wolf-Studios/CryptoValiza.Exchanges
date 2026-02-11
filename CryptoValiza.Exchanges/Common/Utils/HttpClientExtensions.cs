using CryptoValiza.Exchanges.Models.Infrastructure;

namespace CryptoValiza.Exchanges.Common.Utils;

internal static class HttpClientExtensions
{
    public static async Task<T> SendAsync<T>(this HttpClient client,
        Endpoint endpoint,
        CancellationToken cancellationToken) where T : new()
    {
        var request = new HttpRequestMessage(endpoint.Method, endpoint.Url);

        using var response = await client.SendAsync(request,
            HttpCompletionOption.ResponseHeadersRead,
            cancellationToken);
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

        response.EnsureSuccessStatusCode(); // check response code?? 

        var result = stream.ReadAndDeserializeFromJson<T>();

        return result ?? new T();
    }

    public static async Task<T> Get<T>(this HttpClient client,
        Endpoint endpoint,
        string queryParamsString,
        Dictionary<string, string> headers,
        CancellationToken cancellationToken) where T : new()
    {
        var requestUrl = queryParamsString.Length > 0 ? $"{endpoint.Url}?{queryParamsString}" : endpoint.Url;

        var requestMessage = new HttpRequestMessage(endpoint.Method, requestUrl);

        var result = await client.SendAsync<T>(requestMessage, headers, cancellationToken);

        return result;
    }

    public static async Task<T> Post<T>(this HttpClient client,
        Endpoint endpoint,
        StringContent content,
        Dictionary<string, string> headers,
        CancellationToken cancellationToken) where T : new()
    {
        var requestMessage = new HttpRequestMessage(endpoint.Method, endpoint.Url)
        {
            Content = content
        };

        var result = await client.SendAsync<T>(requestMessage, headers, cancellationToken);

        return result;
    }

    private static async Task<T> SendAsync<T>(this HttpClient client,
        HttpRequestMessage requestMessage,
        Dictionary<string, string> headers,
        CancellationToken cancellationToken) where T : new()
    {
        foreach (var header in headers)
        {
            requestMessage.Headers.Add(header.Key, header.Value);
        }

        using var response = await client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

        response.EnsureSuccessStatusCode(); // check response code?? 

        var result = stream.ReadAndDeserializeFromJson<T>(); // error handling ??

        return result ?? new T();
    }
}
