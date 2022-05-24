using System.ComponentModel;

namespace BaseEntityLib;

public enum ResponseStatus
{
    [Description("Ошибка")]
    Error = 0,

    [Description("Успешно")]
    Success = 1
}