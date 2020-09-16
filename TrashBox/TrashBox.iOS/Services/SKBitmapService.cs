using SkiaSharp;
using SkiaSharp.Views.iOS;
using TrashBox.DependencyServices;
using TrashBox.Helpers;
using TrashBox.iOS.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SKBitmapService))]

namespace TrashBox.iOS.Services
{
    public class SKBitmapService : ISKBitmapService
    {
        public SKBitmap GetSKBitmap(string filename)
        {
            try
            {
                return UIImage.FromBundle(filename).ToSKBitmap();
            }
            catch
            {
                return UIImage.FromBundle(Constants.Filenames.BrokenFile).ToSKBitmap();
            }
        }
    }
}