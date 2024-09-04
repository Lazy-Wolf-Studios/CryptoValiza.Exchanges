namespace CryptoValiza.Exchanges.Kuna.Models;

internal class Ticker
{
    public string Pair { get; set; }
    public string PercentagePriceChange { get; set; }
    public string Price { get; set; }
    public string EquivalentPrice { get; set; }
    public string High { get; set; }
    public string Low { get; set; }
    public string BaseVolume { get; set; }
    public string QuoteVolume { get; set; }
    public string BestBidPrice { get; set; }
    public string BestAskPrice { get; set; }
    public string PriceChange { get; set; }
}
