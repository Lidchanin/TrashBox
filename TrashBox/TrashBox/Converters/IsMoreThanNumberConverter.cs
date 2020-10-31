using System;
using System.Globalization;
using Xamarin.Forms;

namespace TrashBox.Converters
{
    public class IsMoreThanNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var number = GetParameter(parameter);

            return value switch
            {
                double doubleValue => (doubleValue > number),
                float floatValue => (floatValue > number),
                int intValue => (intValue > number),
                long longValue => (longValue > number),
                short shortValue => (shortValue > number),
                string stringValue => double.Parse(stringValue),
                _ => throw new ArgumentException("Converter value")
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static double GetParameter(object parameter) =>
            parameter switch
            {
                double doubleParameter => doubleParameter,
                float floatParameter => floatParameter,
                int intParameter => intParameter,
                long longParameter => longParameter,
                short shortParameter => shortParameter,
                string stringParameter => double.Parse(stringParameter),
                _ => throw new ArgumentException("Converter parameter")
            };
    }
}