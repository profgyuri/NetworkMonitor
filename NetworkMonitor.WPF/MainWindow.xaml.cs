namespace NetworkMonitor.WPF;
using System.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        //Place the window to the bottom right of the screen
        Left = SystemParameters.PrimaryScreenWidth - Width - 20;
        Top = SystemParameters.PrimaryScreenHeight - Height - 70;
    }
}
