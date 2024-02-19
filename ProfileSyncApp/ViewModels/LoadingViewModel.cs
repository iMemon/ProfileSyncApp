using ProfileSyncApp.Pages;
namespace ProfileSyncApp.ViewModels;

public class LoadingViewModel
{
    public LoadingViewModel()
    {
        // CheckUserLoginDetails();
    }
    
    // private async void CheckUserLoginDetails()
    // {
    //     if (await isAuthenticated())
    //     {
    //         // Goto Main Page
    //         if (DeviceInfo.Platform == DevicePlatform.WinUI)
    //         {
    //             AppShell.Current.Dispatcher.Dispatch(async() =>
    //             {
    //                 await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    //             });
    //         }
    //         else
    //         {
    //             await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    //         }
    //     }
    //     else
    //     {
    //         // navigate to Login Page
    //         if (DeviceInfo.Platform == DevicePlatform.WinUI)
    //         {
    //             AppShell.Current.Dispatcher.Dispatch(async() =>
    //             {
    //                 await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    //             });
    //         }
    //         else
    //         {
    //             await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    //         }
    //     }
    // }

    // async Task<bool> isAuthenticated()
    // {
    //     await Task.Delay(2000);
    //     var hasAuth = Preferences.Default.Get("hasAuth", false);
    //     return hasAuth;
    // }
}