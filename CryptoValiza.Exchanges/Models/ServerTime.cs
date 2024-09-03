namespace CryptoValiza.Exchanges.Models;
public class ServerTime
{
    public enum Size { Seconds, MilliSeconds, MicroSeconds, NanoSeconds }

    public ServerTime(long unixTime, Size size)
    {
        switch (size)
        {
            case Size.Seconds:
                DateTime = DateTime.UnixEpoch.AddSeconds(unixTime);
                break;
            case Size.MilliSeconds:
                DateTime = DateTime.UnixEpoch.AddMilliseconds(unixTime);
                break;
            case Size.MicroSeconds:
                throw new NotImplementedException("why microseconds?");
            case Size.NanoSeconds:
                DateTime = DateTime.UnixEpoch.AddTicks(unixTime);
                break;
        }

        UnixTime = ((DateTimeOffset)DateTime).ToUnixTimeMilliseconds();
    }

    public long UnixTime { get; set; }
    public DateTime DateTime { get; set; }
}
