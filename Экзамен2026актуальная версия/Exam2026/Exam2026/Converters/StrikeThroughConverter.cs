using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Exam2026.Converters
{
    public class StrikeThroughConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isStrikethrough && isStrikethrough)
                return TextDecorations.Strikethrough;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
