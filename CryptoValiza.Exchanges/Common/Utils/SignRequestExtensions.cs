namespace CryptoValiza.Exchanges.Common.Utils;

using System.Security.Cryptography;
using System.Text;

internal static class SignRequestExtensions
{
	internal static string ComputeSignature(string stringToSign, string privateKey)
	{
		var keyBytes = Encoding.UTF8.GetBytes(privateKey);

		using var hmac = new HMACSHA384(keyBytes);

		var messageBytes = Encoding.UTF8.GetBytes(stringToSign); // ASCII ??

		var hashedBytes = hmac.ComputeHash(messageBytes);

		// to lowercase hexits
		return string.Concat(Array.ConvertAll(hashedBytes, x => x.ToString("x2")));

		// to base64
		// return Convert.ToBase64String(hashedBytes);
	}
}