using CryptoValiza.Exchanges.Common.Utils;
using CryptoValiza.Exchanges.Models.Infrastructure;
using System.Globalization;
using System.Text;
using System.Web;

namespace CryptoValiza.Exchanges.Binance.Services;

internal abstract class BaseBinancePrivateService(IHttpClientFactory httpClientFactory) : BaseBinanceService(httpClientFactory)
{
    protected string GetQueryParamsWithSignature(ApiKey apiKey, Dictionary<string, string> parameters)
    {
        var queryStringBuilder = new StringBuilder();

        if (parameters.Count > 0)
        {
            foreach (var queryParameter in parameters)
            {
                string queryParameterValue = Convert.ToString(queryParameter.Value, CultureInfo.InvariantCulture);
                if (!string.IsNullOrWhiteSpace(queryParameterValue))
                {
                    if (queryStringBuilder.Length > 0)
                    {
                        queryStringBuilder.Append('&');
                    }

                    queryStringBuilder
                        .Append(queryParameter.Key)
                        .Append('=')
                        .Append(HttpUtility.UrlEncode(queryParameterValue));
                }
            }
        }

        // TODO: check memory usage against this
        //var stringToSign = string.Join("&", parameters.Select(x => $"{x.Key}={HttpUtility.UrlEncode(x.Value)}"));

        var stringToSign = queryStringBuilder.ToString();
        var signature = HttpRequestExtensions.ComputeSignatureSHA256(stringToSign, apiKey.SecretKey)
            .ToLowerHexitsWithReplace();

        if (queryStringBuilder.Length > 0)
        {
            queryStringBuilder.Append('&');
        }

        queryStringBuilder.Append($"signature={HttpUtility.UrlEncode(signature)}");

        return queryStringBuilder.ToString();
    }

    protected Dictionary<string, string> GetHeaders(ApiKey apiKey)
    {
        var headers = new Dictionary<string, string>
        {
            { "X-MBX-APIKEY", apiKey.PublicKey }
        };

        return headers;
    }
}
