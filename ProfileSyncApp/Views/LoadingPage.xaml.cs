namespace ProfileSyncApp.Views;

public partial class LoadingPage : ContentPage
{
    IConnectivity connectivity;
    public LoadingPage(IConnectivity connectivity)
    {
        InitializeComponent();
        this.connectivity = connectivity;
        Console.WriteLine("test");
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (await isAuthenticated())
        {
            await Shell.Current.GoToAsync("///home");
        }
        else
        {
            await Shell.Current.GoToAsync("///login");
        }
        base.OnNavigatedTo(args);
    }

    async Task<bool> isAuthenticated()
    {
        await Task.Delay(2000);
        var hasAuth = await SecureStorage.GetAsync("hasAuth");
        return !(hasAuth == null);
    }
}