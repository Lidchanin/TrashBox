using TrashBox.Helpers;
using TrashBox.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TrashBox
{
    public partial class App
    {
        public delegate void OnSleepDelegate();

        public delegate void OnResumeDelegate();

        public static OnSleepDelegate AdditionalOnSleep { get; set; }
        public static OnResumeDelegate AdditionalOnResumeDelegate { get; set; }

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

        protected override void OnSleep() => AdditionalOnSleep();

        protected override void OnResume() => AdditionalOnResumeDelegate();
    }
}