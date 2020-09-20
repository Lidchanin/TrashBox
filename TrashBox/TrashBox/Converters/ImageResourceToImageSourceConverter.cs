using System;
using System.Globalization;
using Xamarin.Forms;

namespace TrashBox.Converters
{
    public class ImageResourceToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            !(value is string source) || string.IsNullOrWhiteSpace(source)
                ? null
                : ImageSource.FromResource(source);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}