using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Models.Infrastructure;

namespace CryptoValiza.Exchanges.Client;

public class CryptoValizaSettings
{
    public CryptoValizaSettings()
    {
        ConnectedExchanges = new List<CryptoExchange>();
    }

    public IEnumerable<CryptoExchange> ConnectedExchanges { get; set; }

    public IEnumerable<KeyRecord> KeyRecords { get; set; }
}
