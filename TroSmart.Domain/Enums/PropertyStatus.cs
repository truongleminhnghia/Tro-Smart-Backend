namespace TroSmart.Domain.Enums
{
    public enum PropertyStatus
    {
        PEDDING_APPROVE,
        APPROVED,
        REJECT,
        AVAILABLE, // đang trống, ch được ai thuê
        BOOKED, // đã đặt lịch
        RENTED, // đã thuê
        ARCHIVED
    }
}