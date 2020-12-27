using E_Ticaret.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.CartItemAttribute
{
    public class CartItemAttributeResponse : BaseDto
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int CartItemId { get; set; }
    }
}
