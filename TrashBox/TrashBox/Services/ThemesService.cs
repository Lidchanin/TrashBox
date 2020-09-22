using System;
using TrashBox.DependencyServices;
using TrashBox.Helpers;
using TrashBox.Themes;
using Xamarin.Forms;

namespace TrashBox.Services
{
    public class ThemesService : IThemeService
    {
        #region Instance

        private static IThemeService _instance;

        public static IThemeService Instance => _instance ??= new ThemesService();

        #endregion Instance

        private static Enums.Themes CurrentTheme
        {
            get =>
                string.IsNullOrWhiteSpace(PreferencesHelper.CurrentTheme) ||
                !(Enum.TryParse(PreferencesHelper.CurrentTheme, out Enums.Themes theme))
                    ? Enums.Themes.Light
                    : theme;
            set => PreferencesHelper.CurrentTheme = value.ToString();
        }

        public void Init() => SetTheme(CurrentTheme);

        public void SetTheme(Enums.Themes theme)
        {
            CurrentTheme = theme;

            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            if (mergedDictionaries == null)
            {
                return;
            }

            mergedDictionaries.Clear();

            var statusBarService = DependencyService.Get<IStatusBarService>();

            switch (theme)
            {
                case Enums.Themes.Dark:
                {
                    mergedDictionaries.Add(new DarkTheme());

                    statusBarService.SetStatusBarColor(Color.DarkSlateGray);

                    break;
                }
                case Enums.Themes.Light:
                {
                    mergedDictionaries.Add(new LightTheme());

                    statusBarService.SetStatusBarColor(Color.SlateGray);

                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(theme), theme, null);
            }
        }
    }
}