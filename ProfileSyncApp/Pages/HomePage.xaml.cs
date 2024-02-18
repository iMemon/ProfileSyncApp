namespace ProfileSyncApp.Pages;

public partial class HomePage : ContentPage
{
    IConnectivity connectivity;
    public HomePage(IConnectivity connectivity)
    {
        InitializeComponent();
        this.connectivity = connectivity;
    }
}
