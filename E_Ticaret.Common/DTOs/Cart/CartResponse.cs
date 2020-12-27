using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Common.DTOs.CartItem;
using E_Ticaret.Common.DTOs.Promotion;
using E_Ticaret.Common.DTOs.ShopToken;
using E_Ticaret.Model;
using System.Collections.Generic;

namespace E_Ticaret.Common.DTOs.Cart
{
    public class CartResponse : BaseDto
    {
        public string SessionId { get; set; }
        public Locked Locked { get; set; }
        public int PromotionId { get; set; }
        public PromotionResponse ChosenPromotion { get; set; }
        public int MemberId { get; set; }
        public int ShopTokenId { get; set; }
        public ShopTokenResponse ChoosenToken { get; set; }
        public List<CartItemResponse> CartItems { get; set; }
    }
}
