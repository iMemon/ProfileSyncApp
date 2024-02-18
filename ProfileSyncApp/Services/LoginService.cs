namespace ProfileSyncApp;

public class LoginService
{
    private readonly HttpClient httpClient;
    private bool firstLoad = true;

    public LoginService()
    {
        this.httpClient = new HttpClient() { BaseAddress = new Uri(Config.APIUrl) };
        // httpClient.DefaultRequestHeaders.Add("api-version", "1.0");
    }
}
