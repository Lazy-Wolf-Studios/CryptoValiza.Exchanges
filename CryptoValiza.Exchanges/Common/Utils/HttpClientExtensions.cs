using CryptoValiza.Exchanges.Common.Models;

namespace CryptoValiza.Exchanges.Common.Utils;

internal static class HttpClientExtensions
{
	public static async Task<T> SendAsync<T>(this HttpClient client, 
		Endpoint endpoint, 
		CancellationToken cancellationToken) where T : new()
    {
		var request = new HttpRequestMessage(endpoint.Method, endpoint.Url);

		using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
		var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

		response.EnsureSuccessStatusCode(); // check response code?? 

		var result = stream.ReadAndDeserializeFromJson<T>();

		return result ?? new T();
	}

	public static async Task<T> SendAsync<T>(this HttpClient client,
		Endpoint endpoint,
		StringContent content,
		Dictionary<string, string> headers,
		CancellationToken cancellationToken) where T : new()
	{
		var request = new HttpRequestMessage(endpoint.Method, endpoint.Url)
		{
			Content = content,
		};

		foreach (var header in headers)
		{
			request.Headers.Add(header.Key, header.Value);
		}

		using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
		var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

		response.EnsureSuccessStatusCode(); // check response code?? 

		var result = stream.ReadAndDeserializeFromJson<T>();

		return result ?? new T();
	}
}
