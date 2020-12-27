using E_Ticaret.Core.Entity;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Promosyon(ShopCampaigns)
    public class Promotion : CoreEntity
    {
        public Promotion()
        {
            Carts = new HashSet<Cart>();
        }
        public string Label { get; set; }
        public ICollection<Cart> Carts { get; set; }

        public Member CreatedMemberPromotion { get; set; }
        public Member ModifiedMemberPromotion { get; set; }
    }
}