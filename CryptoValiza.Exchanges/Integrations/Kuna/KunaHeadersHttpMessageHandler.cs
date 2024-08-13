using CryptoValiza.Exchanges.Common.Infrastructure;
using CryptoValiza.Exchanges.Common.Utils;
using System.Net.Http.Headers;

namespace CryptoValiza.Exchanges.Kuna;
internal class KunaHeadersHttpMessageHandler : DelegatingHandler
{
	private readonly IKeyProvider _keyProvider;

	public KunaHeadersHttpMessageHandler(IKeyProvider keyProvider)
	{
		_keyProvider = keyProvider;
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var apiKey = _keyProvider.GetKey("Kuna"); // To do read from request properties
		var nonce = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();

		var apiPath = request.RequestUri.LocalPath;

		string body = "{}"; // As there is a signature, Body should be at least an empty object
		if (request.Content != null)
		{
			body = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
		}
		else
		{
			request.Content = new StringContent(body);
		}

		var signatureString = $"{apiPath}{nonce}{body}";

		var signature = SignRequestExtensions.ComputeSignature(signatureString, apiKey.SecretKey);

		request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		request.Headers.Add("kun-nonce", nonce.ToString());
		request.Headers.Add("kun-apikey", apiKey.PublicKey);
		request.Headers.Add("kun-signature", signature);

		return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
	}
}