
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
﻿using CommunityToolkit.Maui.Core;
using ProfileSyncApp.Views;
// using Maui.FreakyControls.Extensions;


namespace ProfileSyncApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Register dependencies (Dependency Injection)
            builder.ConfigureServices();
            builder.ConfigurePages();
            builder.ConfigureViewModels();
            // builder.InitializeFreakyControls();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder ConfigurePages(this MauiAppBuilder builder)
    {
        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddTransient<LoadingPage>();

        return builder;
    }
    public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IConnectivity>((e) => Connectivity.Current);
        //builder.Services.AddSingleton<IToast>((e) => new Toaster());
        return builder;
    }
    public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
    {
        return builder;
    }
}
