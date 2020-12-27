using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Common.DTOs.CartItemAttribute;
using E_Ticaret.Common.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.CartItem
{
    public class CartItemResponse : BaseDto
    {
        public decimal Quantity { get; set; }
        public int CategoryId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public ProductResponse Product { get; set; }
        public List<CartItemAttributeResponse> CartItemAttributeResponses { get; set; }
    }
}
