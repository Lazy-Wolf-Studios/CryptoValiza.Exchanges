using CryptoValiza.Exchanges.Client;
using CryptoValiza.Exchanges.Models.Enums;
using Xunit;

namespace Client.Tests.IntergrationTests;

[Trait("Category", "Integration")]
public class HealthCheckTests
{
	private readonly ExchangesClient _client;
	private const int ServiceResponseAllowedDelay = 1; // seconds

	public HealthCheckTests()
	{
		IServiceCollection services = new ServiceCollection();
		services.AddCryptoValiza();

		IHttpClientFactory factory = services
			.BuildServiceProvider()
			.GetRequiredService<IHttpClientFactory>();

		_client = new ExchangesClient(factory);
	}

	[Theory]
	[InlineData(CryptoExchange.Binance)]
	[InlineData(CryptoExchange.ByBit)]
	[InlineData(CryptoExchange.Kuna)]
	[InlineData(CryptoExchange.WhiteBit)]
	public async Task GetServerTime_Returns_CurrentTime(CryptoExchange cryptoExchange)
	{
		// Arrange
		var dateTimeNowUtc = DateTime.UtcNow.Ticks;

		// Act
		var response = await _client.GetServerTime(cryptoExchange);

		// Assert
		var differenceInSeconds = TimeSpan.FromTicks(response.DateTime.Ticks - dateTimeNowUtc).TotalSeconds;

		Assert.True(Math.Abs(differenceInSeconds) < ServiceResponseAllowedDelay);
		Assert.Equal(response.DateTime, DateTime.UnixEpoch.AddMilliseconds(response.UnixTime));
	}
}
