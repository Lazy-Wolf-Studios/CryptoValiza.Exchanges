using CryptoValiza.Exchanges.Common.Utils;
using CryptoValiza.Exchanges.Models.Infrastructure;
using System.Text;

namespace CryptoValiza.Exchanges.WhiteBit.Services;

internal abstract class WhiteBitBaseService
{
	private readonly ApiKey _apiKey;

	protected WhiteBitBaseService(ApiKey apiKey)
	{
		_apiKey = apiKey;
	}

	protected StringContent GetContent(string dataJsonStr)
	{
		var content = new StringContent(dataJsonStr, Encoding.UTF8, "application/json");
		return content;
	}

	protected Dictionary<string, string> GetHeaders(string dataJsonStr)
	{
		var headers = new Dictionary<string, string>();

		var payload = HttpRequestExtensions.Base64Encode(dataJsonStr);
		var signature = HttpRequestExtensions.ComputeSignatureSHA512(payload, _apiKey.SecretKey)
			.ToLowerHexits2();

		headers.Add("X-TXC-APIKEY", _apiKey.PublicKey);
		headers.Add("X-TXC-PAYLOAD", payload);
		headers.Add("X-TXC-SIGNATURE", signature);

		return headers;
	}
}
