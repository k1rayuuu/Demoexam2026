using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Exam2026.Converters
{
    public class SalePriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Если товар со скидкой, возвращаем красный цвет (например, для зачёркнутой цены)
            if (value is bool isStrikethrough && isStrikethrough)
                return new SolidColorBrush(Colors.Red);
            return new SolidColorBrush(Colors.Black); // Иначе возвращаем чёрный цвет
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();  // Обратимое преобразование не требуется
        }
    }
}
