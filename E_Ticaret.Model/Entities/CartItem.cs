using E_Ticaret.Core.Entity;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Sepet Kalemi
    public class CartItem : CoreEntity
    {
        public CartItem()
        {
            Attributes = new HashSet<CartItemAttribute>();
        }
       
        public decimal Quantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<CartItemAttribute> Attributes { get; set; }

        public Member CreatedMemberCartItem { get; set; }
        public Member ModifiedMemberCartItem { get; set; }
    }
}