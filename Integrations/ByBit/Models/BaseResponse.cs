namespace CryptoValiza.Exchanges.ByBit.Models;

internal class BaseResponse<T> where T : new()
{

	/*
	{
		"retCode": 0,
		"retMsg": "OK",
		"result": {},
		"retExtInfo": null,
		"time": 1665997272757
	}		 
	 */
	public int RetCode { get; set; }
	public string RetMsg { get; set; }
	public T Result { get; set; }
	public object RetExtInfo { get; set; }
	public long Time { get; set; }
}
