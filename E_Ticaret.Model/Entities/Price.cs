using E_Ticaret.Core.Entity;

namespace E_Ticaret.Model.Entities
{
    //Ürün Fiyatı
    public class Price : CoreEntity
    {
        public decimal Value { get; set; }
        public int Type { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public Member CreatedMemberPrice { get; set; }
        public Member ModifiedMemberPrice { get; set; }
    }
}