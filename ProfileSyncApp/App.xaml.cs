using ProfileSyncApp.Pages;
using ProfileSyncApp.ViewModels;
using ProfileSyncApp.Helpers;
namespace ProfileSyncApp;

public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var connectivity = ServiceHelper.GetService<IConnectivity>();
            // MainPage = new AppShell();
            var page = new NavigationPage(root: new LoadingPage(vm: new LoadingViewModel(), connectivity: connectivity));
            MainPage = page;
        }
    }
