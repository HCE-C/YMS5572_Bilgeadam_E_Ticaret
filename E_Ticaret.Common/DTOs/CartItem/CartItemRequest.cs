using E_Ticaret.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.CartItem
{
    public class CartItemRequest : BaseDto
    {
        public decimal Quantity { get; set; }
        public int CategoryId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }
}
