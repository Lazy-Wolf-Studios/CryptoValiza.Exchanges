using CryptoValiza.Exchanges.Binance.Models;
using Refit;

namespace CryptoValiza.Exchanges.Binance;
[Headers("accept: application/json")]
public interface IBinancePublicClient
{
	//https://binance-docs.github.io/apidocs/spot/en/#test-connectivity


	[Get("/v3/ping")]
	Task<string> GetPing();

	[Get("/v3/time")]
	Task<TimeResponse> GetTime();


}
