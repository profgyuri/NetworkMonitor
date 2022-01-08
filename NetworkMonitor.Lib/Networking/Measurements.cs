namespace NetworkMonitor.Lib.Networking;

using System.Net.NetworkInformation;

internal class Measurements
{
    private readonly NetworkInterface[] _interfaces = NetworkInterface.GetAllNetworkInterfaces();

    internal long GetReceivedBytes()
    {
        long received = 0;

        for (int i = 0; i < _interfaces.Length; i++)
        {
            received += _interfaces[i]?.GetIPv4Statistics()?.BytesReceived ?? 0;
        }

        return received;
    }

    internal long GetSentBytes()
    {
        long sent = 0;

        for (int i = 0; i < _interfaces.Length; i++)
        {
            sent += _interfaces[i]?.GetIPv4Statistics()?.BytesSent ?? 0;
        }

        return sent;
    }
}
