using System;
using System.Collections.Generic;

namespace Exam2026Prism.Context;

public partial class Tovar
{
    public int Id { get; set; }

    public string? Артикул { get; set; }

    public string? НаименованиеТовара { get; set; }

    public string? ЕдиницаИзмерения { get; set; }

    public double? Цена { get; set; }

    public string? Поставщик { get; set; }

    public string? Производитель { get; set; }

    public string? КатегорияТовара { get; set; }

    public double? ДействующаяСкидка { get; set; }

    public double? КолВоНаСкладе { get; set; }

    public string? ОписаниеТовара { get; set; }

    public string? Фото { get; set; }
}
