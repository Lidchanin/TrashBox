using Android.Graphics;
using SkiaSharp;
using SkiaSharp.Views.Android;
using TrashBox.DependencyServices;
using TrashBox.Droid.Services;
using TrashBox.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(SKBitmapService))]

namespace TrashBox.Droid.Services
{
    public class SKBitmapService : ISKBitmapService
    {
        public SKBitmap GetSKBitmap(string filename)
        {
            int id;

            try
            {
                id = (int) typeof(Resource.Drawable).GetField(filename.Replace(".png", "")).GetValue(null);
            }
            catch
            {
                id = (int) typeof(Resource.Drawable).GetField(Constants.Filenames.BrokenFile.Replace(".png", ""))
                    .GetValue(null);
            }

            return BitmapFactory.DecodeResource(Android.App.Application.Context.Resources, id).ToSKBitmap();
        }
    }
}