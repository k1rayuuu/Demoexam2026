using System;

namespace Exam2026.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Номер_заказа { get; set; }
        public string Артикул_заказа { get; set; }
        public string Дата_заказа { get; set; }
        public string Дата_доставки { get; set; }
        public string Адрес_пункта_выдачи { get; set; }
        public string ФИО_авторизированного_клиента { get; set; }
        public string Код_для_получения { get; set; }
        public string Статус_заказа { get; set; }
    }
}
