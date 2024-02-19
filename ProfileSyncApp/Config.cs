namespace ProfileSyncApp;

public static class Config
{
    public static bool Desktop
    {
        get
        {
#if WINDOWS || MACCATALYST
            return true;
#else
            return false;
#endif
        }
    }
    // public static string Base = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2" : "http://localhost";
    public static string Base = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.100.15" : "http://192.168.100.15";
    public static string APIUrl = $"{Base}:7007/";
}
