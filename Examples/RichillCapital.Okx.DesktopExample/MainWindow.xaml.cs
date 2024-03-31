using System.Windows;
using System.Windows.Input;

namespace RichillCapital.Okx.DesktopExample;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        DataContext = viewModel;

        InitializeComponent();

        CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, OnClose));
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        Application.Current.Shutdown();
    }

    private void OnClose(object sender, ExecutedRoutedEventArgs e) => Close();
}