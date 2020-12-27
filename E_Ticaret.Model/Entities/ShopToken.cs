using E_Ticaret.Core.Entity;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    public class ShopToken : CoreEntity
    {
        //Hediye Çeki
        public ShopToken()
        {
            Carts = new HashSet<Cart>();
        }
        public string Code { get; set; }
        public ICollection<Cart> Carts { get; set; }

        public Member CreatedMemberShopToken  { get; set; }
        public Member ModifiedMemberShopToken { get; set; }
    }
}