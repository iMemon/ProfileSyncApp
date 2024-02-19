using ProfileSyncApp.ViewModels;
using ProfileSyncApp.Helpers;
namespace ProfileSyncApp.Pages;

public partial class LoginPage : ContentPage
{
    LoginViewModel vm => BindingContext as LoginViewModel;

    public LoginPage(): base()
    {
        InitializeComponent();
        BindingContext = ServiceHelper.Current.GetService<LoginViewModel>();
    }

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