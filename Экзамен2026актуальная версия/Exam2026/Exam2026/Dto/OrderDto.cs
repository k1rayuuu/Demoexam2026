using System;

namespace Exam2026.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public Nullable<double> Номер_заказа { get; set; }
        public string Артикул_заказа { get; set; }
        public Nullable<System.DateTime> Дата_заказа { get; set; }
        public Nullable<System.DateTime> Дата_доставки { get; set; }
        public Nullable<double> Адрес_пункта_выдачи { get; set; }
        public string ФИО_авторизированного_клиента { get; set; }
        public Nullable<double> Код_для_получения { get; set; }
        public string Статус_заказа { get; set; }
    }
}
