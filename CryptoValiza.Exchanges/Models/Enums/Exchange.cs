namespace CryptoValiza.Exchanges.Models.Enums;

public enum CryptoExchange
{
	Binance,
	Bitfinex,
	BitGet,
	BitMex,
	ByBit,
	CexIo,
	Ftx,
	GateIo,
	Huobi,
	Kraken,
	KuCoin,
	Kuna,
	OKX,
	Poloniex,
	WhiteBit,

}

public static class CryptoExchangeExtensions
{
	public static string GetExchangeName(this CryptoExchange exchange)
	{
		return Enum.GetName(exchange) ?? exchange.ToString();
	}
}