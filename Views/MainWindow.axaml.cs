using Avalonia;
using Avalonia.Controls;
using LauncherDesktop.Extensions;
using LauncherDesktop.ViewModels;
using Microsoft.Extensions.Logging;
using Splat;

namespace LauncherDesktop.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        if (Design.IsDesignMode)
        {
            DataContext = new MainWindowViewModel(Locator.Current.GetRequiredService<ILoggerFactory>());
        }
        else
        {
            DataContext = Locator.Current.GetRequiredService<MainWindowViewModel>();
        }
        
#if DEBUG
        this.AttachDevTools();
#endif
        
    }
}