using TrashBox.Helpers;
using TrashBox.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TrashBox
{
    public partial class App
    {
        public static double ScreenWidth;
        public static double ScreenHeight;

        public App()
        {
            Device.SetFlags(new[] {"Shapes_Experimental"});

            InitializeComponent();

            ScreenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            ScreenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;


            MainPage = ShellLifecycleHelper.CreateShell<AppShell>();
        }

        protected override void OnStart()
        {

            var themeService = ThemesService.Instance;
            themeService.Init();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}