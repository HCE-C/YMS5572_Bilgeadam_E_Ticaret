namespace E_Ticaret.Model
{
    public enum OrderStatus
    {
        deleted = 0,
        waiting_for_approval = 1,
        approved = 2,
        fulfilled = 3,
        cancelled = 4,
        delivered = 5,
        on_accumulation = 6,
        waiting_for_payment = 7,
        being_prepared = 8,
        refunded = 9,
        personal_status_1 = 10,
        personal_status_2 = 11,
        personal_status_3 = 12
    }
}