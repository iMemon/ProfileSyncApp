using ProfileSyncApp.Pages;

namespace ProfileSyncApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        this.BindingContext = new AppShellViewModel();

        //Register all routes
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
    }
}