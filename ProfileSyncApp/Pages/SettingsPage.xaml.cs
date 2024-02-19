namespace ProfileSyncApp.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

	private async void LogoutButton_Clicked(object sender, EventArgs e)
	{
		if (await DisplayAlert("Are you sure?", "You will be logged out.", "Yes", "No"))
		{
			Preferences.Default.Clear();
			await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
		}
	}
}