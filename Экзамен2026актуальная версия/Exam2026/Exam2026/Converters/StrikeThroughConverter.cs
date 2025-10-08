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
            //  Если значение true, возвращаем TextDecoration для перечёркивани
            if (value is bool isStrikethrough && isStrikethrough)
                return TextDecorations.Strikethrough;
            return null; // Иначе возвращаем null (нет перечёркивания)
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // Обратимое преобразование не требуется
        }
    }
}
