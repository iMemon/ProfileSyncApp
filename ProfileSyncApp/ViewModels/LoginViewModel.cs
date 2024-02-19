namespace ProfileSyncApp.ViewModels;
using ProfileSyncApp.Pages;
using ProfileSyncApp.Models;

public partial class LoginViewModel: ViewModelBase
{
    private readonly LoginService loginService;
    private readonly IConnectivity connectivity;

    public LoginViewModel(IConnectivity connectivity, LoginService loginService)
    {
        this.loginService = loginService;
        this.connectivity = connectivity;
    }

    public async Task InitializeAsync()
    {   
        
    }

    [ObservableProperty]
    string email;

    [ObservableProperty]
    string password;

    // [RelayCommand]
    // Task Signup()
    // {
    //     Console.WriteLine(""); 
    // }

    [RelayCommand]
    async Task Login()
    {
        if (this.connectivity.NetworkAccess != NetworkAccess.Internet) 
        {
            await Application.Current.MainPage.DisplayAlert("Error", "No Internet Access", "Ok");
            return;
        }

        // TODO: Text Validation

        User user = await loginService.Login(Email, Password);
        if (user == null)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Invalid Credentials", "OK");
            return;
        }

        Preferences.Default.Set("hasAuth", true);
        Application.Current.MainPage = new AppShell();
    }

    [RelayCommand]
    async Task SignUp()
    {

    }

    bool IsCredentialCorrect(string username, string password)
    {
        return Email == "admin" && Password == "1234";
    }
}
