using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace RichillCapital.Okx.DesktopExample;

internal static class DependencyInjection
{
    internal static IServiceCollection AddDesktop(this IServiceCollection services)
    {
        services.AddWindows();

        services.AddViewModels();

        services.AddMessengers();

        services.AddSingleton(_ => Application.Current.Dispatcher);

        return services;
    }

    private static IServiceCollection AddWindows(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();

        return services;
    }

    private static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainWindowViewModel>();

        return services;
    }

    private static IServiceCollection AddMessengers(this IServiceCollection services)
    {
        services.AddSingleton<WeakReferenceMessenger>();
        services.AddSingleton<IMessenger, WeakReferenceMessenger>(provider =>
            provider.GetRequiredService<WeakReferenceMessenger>());

        return services;
    }
}
