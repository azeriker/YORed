using YORed.Domain.Infrastructure;

namespace YORed.Domain.Enums
{
    public enum ReportStatus
    {
        [EnumValue("Новая")]
        New,

        [EnumValue("В работе")]
        InProgress,

        [EnumValue("Выполнена")]
        Done,

        [EnumValue("Отклонена")]
        Rejected
    }
}
