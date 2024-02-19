using ProfileSyncApp;
using ProfileSyncApp.ViewModels;
using ProfileSyncApp.Pages;
using ProfileSyncApp.Helpers;

namespace ProfileSyncApp.Pages;

public partial class LoadingPage : ContentPage
{
    IConnectivity connectivity;

    public LoadingPage(): base()
    {
        InitializeComponent();
        this.connectivity = ServiceHelper.Current.GetService<IConnectivity>();
        BindingContext = ServiceHelper.Current.GetService<LoadingViewModel>();;
    }

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
            Application.Current.MainPage = new NavigationPage(root: new LoginPage());
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