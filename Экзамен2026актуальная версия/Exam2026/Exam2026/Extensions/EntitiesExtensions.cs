using Exam2026.Dto;
using System.Windows.Media;

namespace Exam2026.Extensions
{
    public static class EntitiesExtensions
    {
        public static TovarDto ToDto(this Tovars tovar)
        {
            var result = new TovarDto()
            {
                Id = tovar.Id,
                Артикул = tovar.Артикул,
                Наименование_товара = tovar.Наименование_товара,
                Единица_измерения = "Единица измерения: " + tovar.Единица_измерения,
                Цена = tovar.Цена.ToString(),
                Поставщик = "Поставщик: " + tovar.Поставщик,
                Производитель = "Производитель: " + tovar.Производитель,
                Категория_товара = tovar.Категория_товара,
                Действующая_скидка = "Скидка: "+ tovar.Действующая_скидка.ToString() + "%",
                Кол_во_на_складе = "Кол_во_на_складе: " + tovar.Кол_во_на_складе,
                Описание_товара = "Описание товара: " + tovar.Описание_товара,
            };
            // Смена фона, если большая скидка
            if (tovar.Действующая_скидка >= 15)
            {
                result.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2E8B57"));
            }
            // Стоимость товара со скидкой
            if (tovar.Действующая_скидка > 0)
            {// Eстановка флага, что текст для этого объекта должен быть перечёркнут
                result.IsStrikeThrough = true;
                result.СкидочнаяЦена = "\t" + (tovar.Цена * (1 - (tovar.Действующая_скидка / 100))).ToString();
            }
            else
            {
                result.IsStrikeThrough = false;
            }
            //
            if (string.IsNullOrWhiteSpace(tovar.Фото))
                // Если `tovar.Фото` пустое или содержит только пробелы,
                // поставить заглушку:
                result.Фото = "pack://application:,,,/Exam2026;component/Resources/picture.png";
            else
                result.Фото = "pack://application:,,,/Exam2026;component/Resources/" + tovar.Фото;

            return result;
        }

        public static OrderDto ToDto(this Orders order, PickUpPoints pickUpPoint)
        {
            return new OrderDto()
            {
                Id = order.Id,
                Адрес_пункта_выдачи = "Адрес пункта выдачи: " + pickUpPoint.Адрес,
                Номер_заказа = "Номер заказа: " + order.Номер_заказа.ToString(),
                Артикул_заказа = "Артикул заказа: " + order.Артикул_заказа,
                Дата_заказа = "Дата заказа: " + order.Дата_заказа.ToString(),
                Дата_доставки = "Дата доставки: " + order.Дата_доставки.ToString(),
                ФИО_авторизированного_клиента = "ФИО авторизированного клиента: " + order.ФИО_авторизированного_клиента,
                Код_для_получения = "Код для получения: " + order.Код_для_получения.ToString(),
                Статус_заказа = "Статус заказа: " + order.Статус_заказа,
            };
        }

        // static Tovars ToEntity(this TovarDto tovar)
        //{
        //    return new Tovars()
        //    {
        //        Id = tovar.Id,
        //        Артикул = tovar.Артикул,
        //        Наименование_товара = tovar.Наименование_товара,
        //        Единица_измерения = tovar.Единица_измерения,
        //        Цена = tovar.Цена,
        //        Поставщик = tovar.Поставщик,
        //        Производитель = tovar.Производитель,
        //        Категория_товара = tovar.Категория_товара,
        //        Действующая_скидка = tovar.Действующая_скидка,
        //        Кол_во_на_складе = tovar.Кол_во_на_складе,
        //        Описание_товара = tovar.Описание_товара,
        //        Фото = tovar.Фото,
        //    };
        //}
    }
}
