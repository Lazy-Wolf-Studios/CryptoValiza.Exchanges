namespace CryptoValiza.Exchanges.Models;
public class ServerTime
{
	public ServerTime(long unixTime)
	{
		UnixTime = unixTime;
		DateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
			+ TimeSpan.FromMilliseconds(unixTime);
	}

	public long UnixTime { get; set; }
	public DateTime DateTime { get; set; }
}
