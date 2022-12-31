using CryptoValiza.Exchanges.Models.Enums;

namespace CryptoValiza.Exchanges.Client
{
	public class CryptoValizaSettings
	{
		public CryptoValizaSettings()
		{
			ConnectedExchanges = new List<CryptoExchange>();
		}

		public IEnumerable<CryptoExchange> ConnectedExchanges { get; set; }
	}
}
