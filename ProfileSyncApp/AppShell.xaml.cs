using ProfileSyncApp.Views;

namespace ProfileSyncApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        //Register all routes
        Routing.RegisterRoute("login", typeof(LoginPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute("home", typeof(ProfilePage));
        Routing.RegisterRoute("settings", typeof(SettingsPage));
    }
}