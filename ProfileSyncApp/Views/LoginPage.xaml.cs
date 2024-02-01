namespace ProfileSyncApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (IsCredentialCorrect(Email.Text, Password.Text))
        {
            await SecureStorage.SetAsync("hasAuth", "true");
            await Shell.Current.GoToAsync("///home");
        }
        else
        {
            await DisplayAlert("Login failed", "Username or password if invalid", "OK");
        }
    }

    private async void SignupButton_Clicked(object sender, EventArgs e)
    {
        
    }


    bool IsCredentialCorrect(string username, string password)
    {
        return Email.Text == "admin" && Password.Text == "1234";
    }
}