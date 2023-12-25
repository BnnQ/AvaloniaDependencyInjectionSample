﻿using Avalonia;
using System;
using Avalonia.Logging;
using LauncherDesktop.Services;
using LauncherDesktop.ViewModels;
using LauncherDesktop.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReactiveUI.Avalonia.Splat;
using Splat.Microsoft.Extensions.Logging;

namespace LauncherDesktop;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUIWithMicrosoftDependencyResolver(services =>
            {
                services.AddTransient<MainWindowViewModel>();
                services.AddTransient<MainWindow>();
                services.AddLogging(builder =>
                {
                    builder.AddSplat();
                    builder.AddConsole();
                    
                });
                services.AddSingleton<ILogSink, MicrosoftLogSink>(serviceProvider =>
                {
                    var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                    return new MicrosoftLogSink(loggerFactory, minimumAvaloniaLogLevel: LogLevel.Warning);
                });
            }, serviceProvider =>
            {
                ArgumentNullException.ThrowIfNull(serviceProvider);

                Logger.Sink = serviceProvider.GetRequiredService<ILogSink>();
            });
}