using System;
using System.Globalization;
using Xamarin.Forms;

namespace TrashBox.Converters
{
    public class NumberSignChangingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                double doubleValue => (doubleValue * -1),
                float floatValue => (floatValue * -1),
                int intValue => (intValue * -1),
                long longValue => (longValue * -1),
                short shortValue => (shortValue * -1),
                _ => null
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}