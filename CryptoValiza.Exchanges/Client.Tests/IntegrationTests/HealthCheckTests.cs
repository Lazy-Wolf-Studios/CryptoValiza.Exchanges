using CryptoValiza.Exchanges.Models.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoValiza.Exchanges.Client.Tests.IntegrationTests;

[Trait("Category", "Integration")]
public class HealthCheckTests
{
    private readonly IExchangesClient _client;
    private const int ServiceResponseAllowedDelay = 1; // seconds

    public HealthCheckTests()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddCryptoValiza();

        _client = services
            .BuildServiceProvider()
            .GetRequiredService<IExchangesClient>();
    }

    // TODO: should we use something like test urls?
    // https://api-testnet.bybit.com

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
