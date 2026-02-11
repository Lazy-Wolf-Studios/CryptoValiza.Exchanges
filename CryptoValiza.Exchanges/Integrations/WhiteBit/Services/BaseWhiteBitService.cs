using CryptoValiza.Exchanges.Common.Utils;
using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Models.Infrastructure;
using System.Text;

namespace CryptoValiza.Exchanges.WhiteBit.Services;

internal abstract class BaseWhiteBitService(IHttpClientFactory httpClientFactory)
{
    private const string exchange = nameof(CryptoExchange.WhiteBit);

    protected HttpClient _httpClient = httpClientFactory.CreateClient(exchange);

    protected StringContent GetContent(string dataJsonStr)
    {
        var content = new StringContent(dataJsonStr, Encoding.UTF8, "application/json");
        return content;
    }

    protected Dictionary<string, string> GetHeaders(string dataJsonStr, ApiKey apiKey)
    {
        var payload = HttpRequestExtensions.Base64Encode(dataJsonStr);
        var signature = HttpRequestExtensions.ComputeSignatureSHA512(payload, apiKey.SecretKey)
            .ToLowerHexitsWithReplace();

        var headers = new Dictionary<string, string>
        {
            { "X-TXC-APIKEY", apiKey.PublicKey },
            { "X-TXC-PAYLOAD", payload },
            { "X-TXC-SIGNATURE", signature }
        };

        return headers;
    }
}
