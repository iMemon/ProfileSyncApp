namespace ProfileSyncApp.ViewModels;
using ProfileSyncApp.Pages;
using ProfileSyncApp.Models;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class StringExtensions 
{
    public static bool IsValidEmail(this string str)
    { 
        string regex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(str, regex, RegexOptions.IgnoreCase);
    } 
}

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
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    string email;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    string password;

    private bool CanLogin() => !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password) && Email.IsValidEmail();

    [RelayCommand(CanExecute = nameof(CanLogin))]
    async Task Login()
    {
        if (this.connectivity.NetworkAccess != NetworkAccess.Internet) 
        {
            await Application.Current.MainPage.DisplayAlert("Error", "No Internet Access", "Ok");
            return;
        }

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
