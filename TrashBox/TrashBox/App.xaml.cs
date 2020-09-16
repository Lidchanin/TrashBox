using TrashBox.Helpers;
using Xamarin.Essentials;

namespace TrashBox
{
    public partial class App
    {
        public static double ScreenWidth;
        public static double ScreenHeight;

        public App()
        {
            InitializeComponent();

            ScreenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            ScreenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;

            MainPage = ShellLifecycleHelper.CreateShell<AppShell>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}