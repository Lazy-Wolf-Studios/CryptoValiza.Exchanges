namespace CryptoValiza.Exchanges.Models;
public class CurrencyTicker
{
	public string Symbol { get; set; }
	public decimal PriceChange { get; set; }
	public decimal PriceChangePercent { get; set; }
	public decimal TradingVolume { get; set; }
	public decimal LastPrice { get; set; }
	public decimal MaxPrice { get; set; }
	public decimal MinPrice { get; set; }
}
