using System.ComponentModel;

namespace EnumsLib;

public enum ResponseStatus
{
    [Description("Ошибка")]
    Error = 0,

    [Description("Успешно")]
    Success = 1
}