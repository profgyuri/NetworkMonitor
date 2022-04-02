using System.Globalization;

namespace NetworkMonitor.Lib.Networking;

internal class DataPresenter
{
    private readonly Measurements _measurements;

    private long _previousDown;
    private long _previousUp;

    public DataPresenter()
    {
        _measurements = new Measurements();

        _previousDown = _measurements.GetReceivedBytes();
        _previousUp = _measurements.GetSentBytes();
    }

    private long GetDownSpeedInBytes()
    {
        var currentDown = _measurements.GetReceivedBytes();

        var speed = currentDown - _previousDown;
        _previousDown = currentDown;

        return speed;
    }

    private long GetUpSpeedInBytes()
    {
        var currentUp = _measurements.GetSentBytes();

        var speed = currentUp - _previousUp;
        _previousUp = currentUp;

        return speed;
    }

    internal string GetTotalDownText()
    {
        return $"{FormatFromBytesToString(_previousDown)}";
    }

    internal string GetTotalUpText()
    {
        return $"{FormatFromBytesToString(_previousUp)}";
    }

    internal string GetDownSpeedText()
    {
        var speed = GetDownSpeedInBytes();
        return $"{FormatFromBytesToString(speed)}/s";
    }

    internal string GetUpSpeedText()
    {
        var speed = GetUpSpeedInBytes();
        return $"{FormatFromBytesToString(speed)}/s";
    }

    private static string FormatFromBytesToString(double bytes)
    {
        System.Text.StringBuilder builder = new();
        var divisions = 0;

        while (bytes >= 1024)
        {
            bytes /= 1024;
            divisions++;
        }

        builder.Append(bytes.ToString("F1", CultureInfo.InvariantCulture));

        switch (divisions)
        {
            case 0:
                builder.Append(" B");
                break;
            case 1:
                builder.Append(" KB");
                break;
            case 2:
                builder.Append(" MB");
                break;
            case 3:
                builder.Append(" GB");
                break;
        }

        return builder.ToString();
    }
}