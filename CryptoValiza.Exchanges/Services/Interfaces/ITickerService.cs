using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;

namespace CryptoValiza.Exchanges.Services.Interfaces;

internal interface ITickersService
{
    Task<CurrencyTicker> GetTicker(string tradePair);
    // Task<CurrencyTicker> GetTicker(FiatCurrencies fiatCurrencyTag ,CryptoCurrencies cryptoCurrencyTag);
}
