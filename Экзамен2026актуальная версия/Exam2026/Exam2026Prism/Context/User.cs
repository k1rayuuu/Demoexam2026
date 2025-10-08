using System;
using System.Collections.Generic;

namespace Exam2026Prism.Context;

public partial class User
{
    public int Id { get; set; }

    public string? РольСотрудника { get; set; }

    public string? Фио { get; set; }

    public string? Логин { get; set; }

    public string? Пароль { get; set; }
}
