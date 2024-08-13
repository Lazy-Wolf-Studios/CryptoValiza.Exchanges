namespace CryptoValiza.Exchanges.Binance.Models;

internal class Ticker24Statistics
{
	public string Symbol { get; set; }                  // "BNBBTC"
	public string PriceChange { get; set; }			    // "-94.99999800
	public string PriceChangePercent { get; set; }	    // "-95.960
	public string WeightedAvgPrice { get; set; }	    // "0.29628482
	public string PrevClosePrice { get; set; }		    // "0.10002000
	public string LastPrice { get; set; }			    // "4.00000200
	public string LastQty { get; set; }				    // "200.00000000
	public string BidPrice { get; set; }			    // "4.00000000
	public string BidQty { get; set; }				    // "100.00000000
	public string AskPrice { get; set; }			    // "4.00000200
	public string AskQty { get; set; }				    // "100.00000000
	public string OpenPrice { get; set; }			    // "99.00000000
	public string HighPrice { get; set; }			    // "100.00000000
	public string LowPrice { get; set; }			    // "0.10000000
	public string Volume { get; set; }				    // "8913.30000000
	public string QuoteVolume { get; set; }			    // "15.30000000
	public long OpenTime { get; set; }					// 1499783499040
	public long CloseTime { get; set; }					// 1499869899040
	public long FirstId { get; set; }					// 28385 - First tradeId
	public long LastId { get; set; }					// 28460 - Last tradeId
	public long Count { get; set; }						// 76 - Trade count
}
