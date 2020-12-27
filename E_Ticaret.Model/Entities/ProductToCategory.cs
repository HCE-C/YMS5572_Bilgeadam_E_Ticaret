using E_Ticaret.Core.Entity;

namespace E_Ticaret.Model.Entities
{
    //Ürün Kategori Bağı
    public class ProductToCategory : CoreEntity
    {
        public int SortOrder { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Member CreatedMemberProductToCategory { get; set; }
        public Member ModifiedMemberProductToCategory { get; set; }
    }
}