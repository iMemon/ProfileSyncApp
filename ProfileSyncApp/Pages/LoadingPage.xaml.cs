using ProfileSyncApp;
using ProfileSyncApp.ViewModels;
using ProfileSyncApp.Pages;

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
            // await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            Application.Current.MainPage = new AppShell();
        }
        else
        {
            // await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            Application.Current.MainPage = new NavigationPage(root: new LoginPage(vm: new LoginViewModel()));
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