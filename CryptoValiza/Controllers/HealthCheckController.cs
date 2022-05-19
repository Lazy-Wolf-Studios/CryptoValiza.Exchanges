using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CryptoValiza.Exchanges.Controllers;
[ApiController]
[Route("api/{exchangeCode}/[controller]")]
public class HealthCheckController : ControllerBase
{
	private readonly Func<string, IHealthCheckService> _healthCheckServiceFactory;
	public HealthCheckController(Func<string, IHealthCheckService> healthCheckServiceFactory)
	{
		_healthCheckServiceFactory = healthCheckServiceFactory;
	}

	[HttpGet("serverTime")]
	public async Task<ServerTime> GetServerTime([FromRoute] string exchangeCode)
	{
		var service = _healthCheckServiceFactory(exchangeCode);
		var serverTime = await service.GetServerTime();
		return serverTime;
	}


}
