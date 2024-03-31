using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RichillCapital.Okx.DesktopExample;

public sealed partial class MainWindowViewModel(
    OkxClient _okxClient) : 
    ObservableRecipient
{
    [RelayCommand]
    private async Task GetServerTimeAsync()
    {
        throw new NotImplementedException();
    }
}
