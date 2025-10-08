using System;
using System.Windows.Media;

namespace Exam2026.Dto
{
    public class TovarDto
    {
        public string Артикул { get; set; }
        public string Наименование_товара { get; set; }
        public string Единица_измерения { get; set; }
        public string Цена { get; set; }
        public string СкидочнаяЦена { get; set; }
        public string Поставщик { get; set; }
        public string Производитель { get; set; }
        public string Категория_товара { get; set; }
        public string Действующая_скидка { get; set; }
        public string Кол_во_на_складе { get; set; }
        public string Описание_товара { get; set; }
        //
        public string Фото { get; set; }
        public int Id { get; set; }
        //
        public SolidColorBrush BackgroundColor { get; set; }
        //
        public bool IsStrikeThrough { get; set; }
    }
}
