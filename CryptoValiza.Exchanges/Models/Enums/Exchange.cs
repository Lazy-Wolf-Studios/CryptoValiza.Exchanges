namespace CryptoValiza.Exchanges.Models.Enums;

public enum CryptoExchange
{
	Binance,
	Bitfinex,
	Bitget,
	Bybit,
	CEX_IO,
	Gate,
	[Obsolete("Rebranded to HTX")]
	Huobi,
    HTX,
    Kraken,
	KuCoin,
	OKX,
	WhiteBit,
}

public static class CryptoExchangeExtensions
{
    public static readonly string Kraken = GetExchangeName(CryptoExchange.Kraken);
    public static readonly string WhiteBit = GetExchangeName(CryptoExchange.WhiteBit);

    public static string GetExchangeName(this CryptoExchange exchange)
	{
		return Enum.GetName(exchange) ?? exchange.ToString();
	}
}