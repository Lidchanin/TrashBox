using System;
using System.Globalization;
using Xamarin.Forms;

namespace TrashBox.Converters
{
    public class IsStringNotEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value is string stringValue && !string.IsNullOrWhiteSpace(stringValue);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}