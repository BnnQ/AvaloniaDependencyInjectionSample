using System.Reactive;
using Microsoft.Extensions.Logging;
using ReactiveUI;

namespace LauncherDesktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static

    #region Properties

    private string greeting = "Welcome to Avalonia!";
    public string Greeting
    {
        get => greeting;
        set => this.RaiseAndSetIfChanged(ref greeting, value);
    }

    #endregion
    
    private readonly ILogger<MainWindowViewModel> logger;
    public MainWindowViewModel(ILoggerFactory loggerFactory)
    {
        CheckBindingCommand = ReactiveCommand.Create(CheckBinding);
        logger = loggerFactory.CreateLogger<MainWindowViewModel>();
    }

    #region Commands

    public ReactiveCommand<Unit, Unit> CheckBindingCommand { get; }
    private void CheckBinding()
    {
        logger.LogInformation("Greeting: {Greeting}", Greeting);
    }

    #endregion
#pragma warning restore CA1822 // Mark members as static
}