using SkiaSharp;

namespace TrashBox.DependencyServices
{
    public interface ISKBitmapService
    {
        SKBitmap GetSKBitmap(string filename);
    }
}