
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
﻿using CommunityToolkit.Maui.Core;
using ProfileSyncApp.Pages;
using ProfileSyncApp.ViewModels;
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
                .ConfigureServices()
                .ConfigurePages()
                .ConfigureViewModels()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

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
        builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddSingleton<LoginPage>();

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
        builder.Services.AddSingleton<LoginViewModel>();
        return builder;
    }
}
