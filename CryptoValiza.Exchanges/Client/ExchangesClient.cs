using CryptoValiza.Exchanges.Common.Interfaces;
using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Models.Errors;
using CryptoValiza.Exchanges.Models.Infrastructure;
using CryptoValiza.Exchanges.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoValiza.Exchanges.Client;

public class ExchangesClient(IKeyProvider keyProvider,
    IServiceProvider serviceProvider) : IExchangesClient
{
    private readonly IKeyProvider _keyProvider = keyProvider;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task<ServerTime> GetServerTime(CryptoExchange exchangeCode)
    {
        var service = GetService<IHealthCheckService>(exchangeCode);
        var serverTime = await service.GetServerTime();
        return serverTime;
    }

    public async Task<CurrencyTicker> GetTicker(CryptoExchange exchangeCode, string currencyCode)
    {
        var service = GetService<ITickersService>(exchangeCode);
        var currencyTicker = await service.GetTicker(currencyCode);
        return currencyTicker;
    }






    public async Task<IReadOnlyCollection<FiatDeposit>> GetFiatDeposits(CryptoExchange exchangeCode, string userId, DateTime startDate, DateTime endDate)
    {
        var apiKey = GetApiKey(exchangeCode, userId);
        var service = GetService<ITransfersService>(exchangeCode);
        var start = new DateTimeOffset(startDate);
        var end = new DateTimeOffset(endDate);
        return await service.GetFiatDeposits(apiKey, start, end);
    }


    public async Task<IReadOnlyCollection<CryptoDeposit>> GetCryptoDeposits(CryptoExchange exchangeCode, string userId, DateTime startDate, DateTime endDate)
    {
        var apiKey = GetApiKey(exchangeCode, userId);
        var service = GetService<ITransfersService>(exchangeCode);
        return await service.GetCryptoDeposits(apiKey, startDate, endDate);
    }

    public Task<IReadOnlyCollection<FiatWithdrawal>> GetFiatWithdrawals(CryptoExchange exchangeCode, string userId, DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<CryptoWithdrawal>> GetCryptoWithdrawals(CryptoExchange exchangeCode, string userId, DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyCollection<Balance>> GetBalances(CryptoExchange exchangeCode, string userId, DateTime date)
    {
        var apiKey = GetApiKey(exchangeCode, userId);
        var service = GetService<IBalancesService>(exchangeCode);
        return await service.GetBalances(apiKey);
    }

    private T GetService<T>(CryptoExchange exchangeCode)
    {
        var key = exchangeCode.GetExchangeName();
        var service = _serviceProvider.GetKeyedService<T>(key);

        if (service == null)
        {
            throw new Exception();
        }

        return service;
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