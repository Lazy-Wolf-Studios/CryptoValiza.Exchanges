using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CryptoValiza.Exchanges.Controllers;
[ApiController]
[Route("api/{exchangeCode}/[controller]")]
public class CurrencyController : ControllerBase
{
	private readonly Func<string, ITickerService> _tickerServiceFactory;
	public CurrencyController(Func<string, ITickerService> factory)
	{
		_tickerServiceFactory = factory;
	}

	[HttpGet("{currencyCode}")]
	public async Task<ActionResult<Ticker>> Get([FromRoute] string currencyCode, [FromRoute] string exchangeCode)
	{
		var service = _tickerServiceFactory(exchangeCode);
		var result = await service.GetTicker(currencyCode);
		return result;
	}

}
