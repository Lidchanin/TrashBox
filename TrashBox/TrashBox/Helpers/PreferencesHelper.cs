using Xamarin.Essentials;

namespace TrashBox.Helpers
{
    public static class PreferencesHelper
    {
        public static string CurrentTheme
        {
            get => Preferences.Get(nameof(CurrentTheme), null);
            set
            {
                if (value != null)
                {
                    Preferences.Set(nameof(CurrentTheme), value);
                }
                else
                {
                    Preferences.Remove(nameof(CurrentTheme));
                }
            }
        }

        public static void Clear() => Preferences.Clear();
    }
}