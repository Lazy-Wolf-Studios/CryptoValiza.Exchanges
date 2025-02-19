using CryptoValiza.Exchanges.Common.Utils;
using CryptoValiza.Exchanges.Models.Infrastructure;
using System.Text;

namespace CryptoValiza.Exchanges.Kuna.Services;

internal abstract class KunaBaseService
{
	private readonly ApiKey _apiKey;

	protected KunaBaseService(ApiKey apiKey)
	{
		_apiKey = apiKey;
	}

	protected StringContent GetContent(string dataJsonStr)
	{
		var content = new StringContent(dataJsonStr, Encoding.UTF8, "application/json");
		return content;
	}

	protected Dictionary<string, string> GetHeaders(string apiPath, string dataJsonStr)
	{
		var headers = new Dictionary<string, string>();
		var nonce = HttpRequestExtensions.GetNonce();

		var signatureString = $"{apiPath}{nonce}{dataJsonStr}";

		var signature = HttpRequestExtensions.ComputeSignatureSHA384(signatureString, _apiKey.SecretKey)
			.ToLowerHexits();

		headers.Add("kun-nonce", nonce);
		headers.Add("kun-apikey", _apiKey.PublicKey);
		headers.Add("kun-signature", signature);

		return headers;
	}
}
