using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;

namespace RichillCapital.Okx.DesktopExample;

public partial class App : Application
{
    public new static App Current => (App)Application.Current;
    public IServiceProvider Services { get; private set; }
    public App() => Services = ConfigureServices();

    protected override void OnStartup(StartupEventArgs e)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        base.OnStartup(e);
        var window = Services.GetRequiredService<MainWindow>();
        window.Show();
    }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddDesktop();

        services.AddSingleton<OkxClient>(provider => new OkxClient(string.Empty, string.Empty, string.Empty));

        return services.BuildServiceProvider();
    }

}
