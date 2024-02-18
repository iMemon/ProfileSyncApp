using ProfileSyncApp.ViewModels;

namespace ProfileSyncApp.Pages;

public partial class LoginPage : ContentPage
{
    LoginViewModel vm => BindingContext as LoginViewModel;
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.InitializeAsync();
    }
    
    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }
}