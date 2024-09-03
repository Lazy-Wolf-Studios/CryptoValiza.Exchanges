using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Models.Errors;
using CryptoValiza.Exchanges.Models.Infrastructure;
using CryptoValiza.Exchanges.Services;

namespace CryptoValiza.Exchanges.Client;

public class ExchangesClient(CryptoValizaSettings settings,
    IKeyProvider keyProvider,
    IHttpClientFactory httpClientFactory) : IExchangesClient
{
    private readonly CryptoValizaSettings _settings = settings;
    private readonly IKeyProvider _keyProvider = keyProvider;
    private readonly IExchangesServiceFactory _exchangeServiceFactory = new ExchangesServiceFactory(httpClientFactory);

    public async Task<ServerTime> GetServerTime(CryptoExchange exchangeCode)
    {
        var service = _exchangeServiceFactory.GetHealthCheckService(exchangeCode);
        var serverTime = await service.GetServerTime();
        return serverTime;
    }

    public async Task<CurrencyTicker> GetTicker(CryptoExchange exchangeCode, string currencyCode)
    {
        var service = _exchangeServiceFactory.GetTickersService(exchangeCode);
        var currencyTicker = await service.GetTicker(currencyCode);
        return currencyTicker;
    }


    public async Task<IReadOnlyCollection<Deposit>> GetDeposits(CryptoExchange exchangeCode, DateTime startDate, DateTime endDate)
    {
        // TODO: what if exchange code is not among supported, but key was not provided? 
        if (!_settings.ConnectedExchanges.Contains(exchangeCode))
        {
            // TODO: how to provide userId? Multiuser client or single user client?
            // GetApiKey(exchangeCode, userId);

        }

        var service = _exchangeServiceFactory.GetTransfersService(exchangeCode);
        var deposits = await service.GetDeposits();
        return deposits;

    }

    public Task<IReadOnlyCollection<Withdrawal>> GetWithdrawals(CryptoExchange exchangeCode, DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyCollection<Balance>> GetBalances(CryptoExchange exchangeCode, string userId, DateTime date)
    {
        var apiKey = GetApiKey(exchangeCode, userId);
        var service = _exchangeServiceFactory.GetBalancesService(exchangeCode, apiKey);
        var balances = await service.GetBalances();
        return balances;
    }

    private ApiKey GetApiKey(CryptoExchange exchangeCode, string userId)
    {
        var apiKey = _keyProvider.GetKey(exchangeCode, userId);
        if (string.IsNullOrEmpty(apiKey.SecretKey))
        {
            throw new ApiKeyWasNotProvidedException();
        };
        return apiKey;
    }
}