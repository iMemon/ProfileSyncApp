using Android.Print;

namespace ProfileSyncApp.ViewModels;

public partial class LoginViewModel: ViewModelBase
{
    // private readonly ShowsService showsService;

    public LoginViewModel()
    {
        
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
        if (IsCredentialCorrect(Email, Password))
        {
            await SecureStorage.SetAsync("hasAuth", "true");
            await Shell.Current.GoToAsync("///home");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Login failed", "Username or password if invalid", "OK");
        }
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
