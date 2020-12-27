using E_Ticaret.Core.Entity;

namespace E_Ticaret.Model.Entities
{
    //Sepet Kalemi Özelliği
    public class CartItemAttribute : CoreEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public int CartItemId { get; set; }
        public CartItem CartItem { get; set; }

        public Member CreatedMemberCartItemAttribute { get; set; }
        public Member ModifiedMemberCartItemAttribute { get; set; }
    }
}