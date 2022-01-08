namespace NetworkMonitor.Lib.Networking;

internal class DataPresenter
{
    private readonly Measurements _measurements;

    private long _previousDown;
    private long _previousUp;

    public DataPresenter()
    {
        _measurements = new();

        _previousDown = _measurements.GetReceivedBytes();
        _previousUp = _measurements.GetSentBytes();
    }

    private long GetDownSpeedInBytes()
    {
        var _currentDown = _measurements.GetReceivedBytes();

        var speed = _currentDown - _previousDown;
        _previousDown = _currentDown;

        return speed;
    }

    private long GetUpSpeedInBytes()
    {
        var _currentUp = _measurements.GetSentBytes();

        var speed = _currentUp - _previousUp;
        _previousUp = _currentUp;

        return speed;
    }

    internal string GetTotalDownText()
    {
        return string.Format("{0}/s", FormatFromBytesToString(_previousDown));
    }

    internal string GetTotalUpText()
    {
        return string.Format("{0}/s", FormatFromBytesToString(_previousUp));
    }

    internal string GetDownSpeedText()
    {
        var speed = GetDownSpeedInBytes();
        return string.Format("{0}/s", FormatFromBytesToString(speed));
    }

    internal string GetUpSpeedText()
    {
        var speed = GetUpSpeedInBytes();
        return string.Format("{0}/s", FormatFromBytesToString(speed));
    }

    private static string FormatFromBytesToString(long bytes)
    {
        System.Text.StringBuilder builder = new();
        var divisions = 0;

        while (bytes >= 1024)
        {
            bytes /= 1024;
            divisions++;
        }

        builder.Append(bytes);

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
            default:
                break;
        }

        return builder.ToString();
    }
}
