
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
﻿using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.Logging;
using ProfileSyncApp.Views;

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

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddSingleton<IConnectivity>((e) => Connectivity.Current);
            //builder.Services.AddSingleton<IToast>((e) => new Toaster());

            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddTransient<LoadingPage>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
