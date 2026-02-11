namespace CryptoValiza.Exchanges.Binance.Models;

internal class BaseResponseV1<T> where T : new()
{
    /* v1 has response wrapped like this:
    {
        "code": "000000",
        "message": "success",
        "data": {},
        "total": 1,
        "success": true
    }
    */

    public string Code { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
    public int Total { get; set; }
    public bool Success { get; set; }
}
