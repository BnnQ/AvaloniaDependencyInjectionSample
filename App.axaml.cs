using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using LauncherDesktop.ViewModels;
using LauncherDesktop.Views;
using Microsoft.Extensions.DependencyInjection;
using Splat;

namespace LauncherDesktop;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = Locator.Current.GetService<MainWindow>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}