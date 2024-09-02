namespace CryptoValiza.Exchanges.Kuna.Models;

internal class BaseResponse<T> where T : new()
{
    /* v4 has response wrapped like this:
    {
      "data": {

      },
      "errors": [
        {
          "code": "string",
          "message": "string"
        }
      ]
    }
    */

    public T? Data { get; set; }
    public List<ErrorModel> Errors { get; set; } = [];
}
