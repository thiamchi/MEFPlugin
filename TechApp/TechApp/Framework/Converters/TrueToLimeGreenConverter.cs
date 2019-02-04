using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TechApp.Framework.Converters
{
    public class TrueToLimeGreenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value == true ? new SolidColorBrush(Colors.LimeGreen) : new SolidColorBrush(Colors.LightGray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
