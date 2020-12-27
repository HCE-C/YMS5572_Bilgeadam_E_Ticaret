using E_Ticaret.Core.Entity;

namespace E_Ticaret.Model.Entities
{
    //Ürün Geri Sayım Bağı(Product To Countdown)
    public class ProductToCountDown : CoreEntity
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ExpireDate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public Member CreatedMemberProductToCountDown { get; set; }
        public Member ModifiedMemberProductToCountDown { get; set; }
    }
}