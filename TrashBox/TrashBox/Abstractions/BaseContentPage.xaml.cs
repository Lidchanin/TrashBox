using System.Windows.Input;
using TrashBox.Services;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace TrashBox.Abstractions
{
    public partial class BaseContentPage
    {
        public ICommand ChangeThemeCommand { get; }

        public BaseContentPage()
        {
            ChangeThemeCommand = new Command(ChangeThemeAsync);

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            InitializeComponent();
        }

        private static void ChangeThemeAsync(object parameter)
        {
            if (!(parameter is Enums.Themes theme))
            {
                return;
            }

            ThemesService.Instance.SetTheme(theme);
        }
    }
}