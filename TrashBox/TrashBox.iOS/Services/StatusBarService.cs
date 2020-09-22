using Foundation;
using ObjCRuntime;
using TrashBox.DependencyServices;
using TrashBox.iOS.Services;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(StatusBarService))]

namespace TrashBox.iOS.Services
{
    public class StatusBarService : IStatusBarService
    {
        public void SetStatusBarColor(Color color)
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                foreach (var window in UIApplication.SharedApplication.Windows)
                {
                    var statusBar = new UIView(UIApplication.SharedApplication.StatusBarFrame)
                    {
                        Tag = 38482,
                        BackgroundColor = color.ToUIColor()
                    };

                    window.AddSubview(statusBar);
                }
            }
            else
            {
                if (UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) is UIView statusBar &&
                    statusBar.RespondsToSelector(new Selector("setBackgroundColor:")))
                {
                    statusBar.BackgroundColor = color.ToUIColor();
                }
            }
        }
    }
}