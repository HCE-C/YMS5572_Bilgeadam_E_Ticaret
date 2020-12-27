using E_Ticaret.Core.Entity;

namespace E_Ticaret.Model.Entities
{
    //Sipariş Detayı
    public class OrderDetail : CoreEntity
    {
        public string VarKey { get; set; }
        public string VarValue { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public Member CreatedMemberOrderDetail { get; set; }
        public Member ModifiedMemberOrderDetail { get; set; }
    }
}