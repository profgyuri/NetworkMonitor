namespace NetworkMonitor.Lib.ViewModels;

using NetworkMonitor.Lib.Networking;
using System.Timers;

public class MainWindowViewModel : ViewModelBase
{
    private readonly DataPresenter _dataPresenter;
    private readonly Timer _timer;

    public string DownSpeedText { get; set; }

    public string UpSpeedText { get; set; }

    public string TotalDownText { get; set; }

    public string TotalUpText { get; set; }

    private void UpdateData()
    {
        DownSpeedText = _dataPresenter.GetDownSpeedText();
        OnPropertyChanged(DownSpeedText);
        UpSpeedText = _dataPresenter.GetUpSpeedText();
        OnPropertyChanged(UpSpeedText);
        TotalDownText = _dataPresenter.GetTotalDownText();
        OnPropertyChanged(TotalDownText);
        TotalUpText = _dataPresenter.GetTotalUpText();
        OnPropertyChanged(TotalUpText);
    }

    public MainWindowViewModel()
    {
        _dataPresenter = new();

        UpdateData();

        _timer = new();
        _timer.Interval = 1000;
        _timer.AutoReset = true;
        _timer.Enabled = true;
        _timer.Elapsed += (o, e) => UpdateData();
        _timer.Start();
    }
}