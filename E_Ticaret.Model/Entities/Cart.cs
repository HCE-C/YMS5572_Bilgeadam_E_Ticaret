using E_Ticaret.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Model.Entities
{
    //Sepet
    public class Cart : CoreEntity
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }
        public string SessionId { get; set; }
        public Locked Locked { get; set; }

        public int PromotionId { get; set; }
        public Promotion ChosenPromotion { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int ShopTokenId { get; set; }
        public ShopToken ChoosenToken { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public Member CreatedMemberCart { get; set; }
        public Member ModifiedMemberCart { get; set; }
    }
}
