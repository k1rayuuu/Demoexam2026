using System;
using System.Collections.Generic;

namespace Exam2026Prism.Context;

public partial class Order
{
    public double? НомерЗаказа { get; set; }

    public string? АртикулЗаказа { get; set; }

    public DateTime? ДатаЗаказа { get; set; }

    public DateTime? ДатаДоставки { get; set; }

    public double АдресПунктаВыдачи { get; set; }

    public string? ФиоАвторизированногоКлиента { get; set; }

    public double? КодДляПолучения { get; set; }

    public string? СтатусЗаказа { get; set; }

    public int Id { get; set; }
}
