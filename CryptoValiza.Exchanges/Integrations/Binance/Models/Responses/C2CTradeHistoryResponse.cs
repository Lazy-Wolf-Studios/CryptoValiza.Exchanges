using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;
using System.Globalization;

namespace CryptoValiza.Exchanges.Binance.Models.Responses;

internal class C2CTradeHistoryResponse
{
    public string OrderNumber { get; set; }
    public string AdvNo { get; set; }
    public string TradeType { get; set; }
    public string Asset { get; set; }
    public string Fiat { get; set; }
    public string FiatSymbol { get; set; }
    public string Amount { get; set; }
    public string TotalPrice { get; set; }
    public string UnitPrice { get; set; }
    public string OrderStatus { get; set; }
    public long CreateTime { get; set; }
    public string Commission { get; set; }
    public string CounterPartNickName { get; set; }
    public string AdvertisementRole { get; set; }

    /*
    "orderNumber": "20219644646554779648",
    "advNo": "11218246497340923904",
    "tradeType": "SELL",
    "asset": "BUSD",
    "fiat": "CNY",
    "fiatSymbol": "￥",
    "amount": "5000.00000000",
    "totalPrice": "33400.00000000",
    "unitPrice": "6.68",
    "orderStatus": "COMPLETED",
    "createTime": 1619361369000,
    "commission": "0",
    "counterPartNickName": "ab***",
    "advertisementRole": "TAKER"
    */

    internal FiatDeposit ToFiatDeposit()
    {
        return new FiatDeposit
        {
            Id = OrderNumber,
            CreateDate = DateTimeOffset.FromUnixTimeMilliseconds(CreateTime).UtcDateTime,
            Currency = FiatCurrency.USD, //Fiat,
            Asset = CryptoCurrency.BTC, // Asset,
            
            Amount = decimal.Parse(Amount, CultureInfo.InvariantCulture),
            Value = decimal.Parse(TotalPrice, CultureInfo.InvariantCulture),
            Fee = decimal.Parse(Commission, CultureInfo.InvariantCulture)            
        };
    }
}

