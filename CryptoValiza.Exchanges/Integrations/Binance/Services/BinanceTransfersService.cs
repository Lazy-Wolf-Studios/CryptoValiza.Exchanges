using CryptoValiza.Exchanges.Models;
using CryptoValiza.Exchanges.Models.Enums;
using CryptoValiza.Exchanges.Models.Infrastructure;
using CryptoValiza.Exchanges.Services.Interfaces;

namespace CryptoValiza.Exchanges.Binance.Services;

internal class BinanceTransfersService : ITransfersService
{
    private const string exchange = nameof(CryptoExchange.Binance);
    private readonly Endpoint GetDepositsEndpoint = new Endpoint(HttpMethod.Get, "sapi/v1/capital/deposit/hisrec");
    private readonly Endpoint GetWithdrawalsEndpoint = new Endpoint(HttpMethod.Get, "sapi/v1/capital/withdraw/history");
    private readonly Endpoint GetC2CTradeHistoryEndpoint = new Endpoint(HttpMethod.Get, "");

    private readonly Endpoint GetFiatOrdersEndpoint = new Endpoint(HttpMethod.Get, "sapi/v1/fiat/orders");
    private readonly Endpoint GetFiatPaymentsEndpoint = new Endpoint(HttpMethod.Get, "");

    private readonly IHttpClientFactory _httpClientFactory;

    public BinanceTransfersService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }



    /*
    Please notice the default startTime and endTime to make sure that time interval is within 0-90 days.
    If both startTime and endTime are sent, time between startTime and endTime must be less than 90 days.

	coin 			STRING 	NO 	
	status 			INT 	NO 	0(0:pending,6: credited but cannot withdraw, 1:success)
	startTime		LONG 	NO 	Default: 90 days from current timestamp
	endTime 		LONG 	NO 	Default: present timestamp
	offset			INT 	NO 	Default:0
	limit 			INT 	NO 	Default:1000, Max:1000
	recvWindow		LONG 	NO 	
	timestamp 		LONG 	YES 	
	txId 			STRING 	NO


	{
        "id": "769800519366885376",
        "amount": "0.001",
        "coin": "BNB",
        "network": "BNB",
        "status": 0,
        "address": "bnb136ns6lfw4zs5hg4n85vdthaad7hq5m4gtkgf23",
        "addressTag": "101764890",
        "txId": "98A3EA560C6B3336D348B6C83F0F95ECE4F1F5919E94BD006E5BF3BF264FACFC",
        "insertTime": 1661493146000,
        "transferType": 0,
        "confirmTimes": "1/1",
        "unlockConfirm": 0,
        "walletType": 0
    }
	 */
    public async Task<IReadOnlyCollection<Deposit>> GetDeposits()
    {
        var deposits = new List<Deposit>();

        return deposits;
    }





    /*
	 
	coin 	STRING 	NO 	
	withdrawOrderId 	STRING 	NO 	
	status 	INT 	NO 	0(0:Email Sent,1:Cancelled 2:Awaiting Approval 3:Rejected 4:Processing 5:Failure 6:Completed)
	offset 	INT 	NO 	
	limit 	INT 	NO 	Default: 1000, Max: 1000
	startTime 	LONG 	NO 	Default: 90 days from current timestamp
	endTime 	LONG 	NO 	Default: present timestamp
	recvWindow 	LONG 	NO 	
	timestamp 	LONG 	YES
	
    network may not be in the response for old withdraw.
    Please notice the default startTime and endTime to make sure that time interval is within 0-90 days.
    If both startTime and endTimeare sent, time between startTimeand endTimemust be less than 90 days.
    If withdrawOrderId is sent, time between startTime and endTime must be less than 7 days.
    If withdrawOrderId is sent, startTime and endTime are not sent, will return last 7 days records by default.

	 */

    public Task<IReadOnlyCollection<Withdrawal>> GetWithdrawals()
    {
        throw new NotImplementedException();
    }
}
