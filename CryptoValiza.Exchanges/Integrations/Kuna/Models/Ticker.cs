namespace CryptoValiza.Exchanges.Kuna.Models;

internal class Ticker
{
	public string Symbol { get; set; }
	public decimal PriceBid { get; set; }
	public decimal OrderbookVolumeBid { get; set; }
	public decimal PriceAsk { get; set; }
	public decimal OrderbookVolumeAsk { get; set; }
	public decimal PriceChangeTarget { get; set; }
	public decimal PriceChangePercent { get; set; }
	public decimal LastPrice { get; set; }
	public decimal TradingVolume { get; set; }
	public decimal MaxPrice { get; set; }
	public decimal MinPrice { get; set; }
}
