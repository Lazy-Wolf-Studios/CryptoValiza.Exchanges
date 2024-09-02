using CryptoValiza.Exchanges.Common.Utils;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace CryptoValiza.Exchanges.Common.Tests;

[Trait("Category", "Unit")]
public class SignRequestExtensionsTests
{
	[Fact]
	public void When_DataIsProvided_ComputeSignature_Returns_ExpectedHash()
	{
		var testData = new
		{
			nonce = 1639085261210,
			apiPath = "/v3/auth/r/orders/ethuah/hist",
			body = new Dictionary<string, object>
			{
				{"start", 1638991409000 }
			},
			// Don't try to use this key. The key is from documentation.
			secretKey = "vPNvF9ArqV4HqMzpAIyaLvToJJ1x1rfRZP5jNrQf",
			expected = "fd9a265567e5f07cb2362134edd1c358899e72f6239ff57fb186d19d497279fcc7360edbfcaecaad7b405a6b9e1f6ab6"
		};

		var signatureString = $"{testData.apiPath}{testData.nonce}{JsonSerializer.Serialize(testData.body)}";

		var actual = HttpRequestExtensions.ComputeSignatureSHA384(signatureString, testData.secretKey)
			.ToLowerHexits();
		Assert.Equal(testData.expected, actual);
	}
}
