namespace CryptoValiza.Exchanges.Common.Utils;

using System.Security.Cryptography;
using System.Text;

internal static class HttpRequestExtensions
{
	// used by Kuna
	internal static byte[] ComputeSignatureSHA384(string stringToSign, string privateKey)
	{
		var keyBytes = Encoding.UTF8.GetBytes(privateKey);
		using var hmac = new HMACSHA384(keyBytes);
		var messageBytes = Encoding.UTF8.GetBytes(stringToSign);
		var hashedBytes = hmac.ComputeHash(messageBytes);

		return hashedBytes;
	}

	// used by WhiteBit
	internal static byte[] ComputeSignatureSHA512(string stringToSign, string privateKey)
	{
		var keyBytes = Encoding.UTF8.GetBytes(privateKey);
		using var hmac = new HMACSHA512(keyBytes);
		var messageBytes = Encoding.UTF8.GetBytes(stringToSign);
		var hashedBytes = hmac.ComputeHash(messageBytes);

		return hashedBytes;
	}

	internal static string ToLowerHexits(this byte[] bytes)
	{
		return string.Concat(Array.ConvertAll(bytes, x => x.ToString("x2")));
	}

	internal static string ToLowerHexits2(this byte[] bytes)
	{
		return BitConverter.ToString(bytes).Replace("-", string.Empty).ToLower();
	}

	internal static string Base64Encode(string plainText)
	{
		var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
		return Base64Encode(plainTextBytes);
	}

	internal static string Base64Encode(byte[] plainTextBytes)
	{
		return Convert.ToBase64String(plainTextBytes);
	}

	internal static string GetNonce()
	{
		return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
	}
}