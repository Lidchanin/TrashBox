using Android.OS;
using Plugin.CurrentActivity;
using TrashBox.DependencyServices;
using TrashBox.Droid.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(StatusBarService))]

namespace TrashBox.Droid.Services
{
    public class StatusBarService : IStatusBarService
    {
        public void SetStatusBarColor(Color color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var androidColor = color.AddLuminosity(-0.1).ToAndroid();

                CrossCurrentActivity.Current.Activity.Window.SetStatusBarColor(androidColor);
            }
        }
    }
}