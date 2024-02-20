namespace ProfileSyncApp;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;
using ProfileSyncApp.Models;

public class LoginService
{
    private readonly HttpClient httpClient;
    private bool firstLoad = true;

    public LoginService()
    {
        this.httpClient = new HttpClient() { BaseAddress = new Uri(Config.APIUrl) };
        // httpClient.DefaultRequestHeaders.Add("api-version", "1.0");
    }

    public async Task<User> Login(string email, string password)
    {
        var path = $"/Login?email={email}&password={password}";
        var currentUser = await TryGetAsync<User>(path);
        return currentUser;
    }

    private Task<T> TryGetAsync<T>(string path)
    {
        if (firstLoad)
        {
            firstLoad = false;

            // On first load, it takes a significant amount of time to initialize
            // the ShowsService. For example, Connectivity.NetworkAccess, Barrel.Current.Get,
            // and HttpClient all take time to initialize.
            //
            // Don't block the UI thread while doing this initialization, so the app starts faster.
            // Instead, run the first TryGet in a background thread to unblock the UI during startup.
            return Task.Run(() => TryGetImplementationAsync<T>(path));
        }
        return TryGetImplementationAsync<T>(path);
    }

    private async Task<T> TryGetImplementationAsync<T>(string path)
    {
        var json = string.Empty;

        // TODO: Handling offline case (Get data from LocalDb when there is no internet)
// #if !MACCATALYST
//         if (Connectivity.NetworkAccess == NetworkAccess.None)
//             json = Barrel.Current.Get<string>(path);
// #endif
//         if (!Barrel.Current.IsExpired(path))
//             json = Barrel.Current.Get<string>(path);

        T responseData = default;
        try
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                var response = await httpClient.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    responseData = await response.Content.ReadFromJsonAsync<T>();
                }
            }
            else
            {
                responseData = JsonSerializer.Deserialize<T>(json);
            }

            // TODO: Save new data to LocalDb -- Test commit after pull request creation
            // if (responseData != null)
            //     Barrel.Current.Add(path, responseData, TimeSpan.FromMinutes(10));
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }

        return responseData;
    }
}
