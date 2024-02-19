using ProfileSyncApp;
using ProfileSyncApp.ViewModels;

namespace ProfileSyncApp.Pages;

public partial class LoadingPage : ContentPage
{
    IConnectivity connectivity;
    public LoadingPage(LoadingViewModel vm, IConnectivity connectivity)
    {
        InitializeComponent();
        this.connectivity = connectivity;
        BindingContext = vm;
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (await isAuthenticated())
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        else
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        base.OnNavigatedTo(args);
    }

    async Task<bool> isAuthenticated()
    {
        await Task.Delay(2000);
        var hasAuth = Preferences.Default.Get("hasAuth", false);
        return hasAuth;
    }
}