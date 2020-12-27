using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Model;

namespace E_Ticaret.Common.DTOs.Cart
{
    public class CartRequest : BaseDto
    {
        public string SessionId { get; set; }
        public Locked Locked { get; set; }
        public int PromotionId { get; set; }
        public int MemberId { get; set; }
        public int ShopTokenId { get; set; }
    }
}
