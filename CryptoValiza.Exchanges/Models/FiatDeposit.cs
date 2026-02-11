using CryptoValiza.Exchanges.Models.Enums;

namespace CryptoValiza.Exchanges.Models;

public class FiatDeposit
{
    public string Id { get; set; } // order number
    public DateTimeOffset CreateDate { get; set; }
    public FiatCurrency Currency { get; set; }
    public decimal Amount { get; set; }
    public decimal Fee { get; set; }
    public CryptoCurrency Asset { get; set; }
    public decimal Value { get; set; }
}
