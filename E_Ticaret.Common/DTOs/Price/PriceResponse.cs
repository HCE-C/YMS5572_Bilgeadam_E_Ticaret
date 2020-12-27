using E_Ticaret.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.Price
{
    public class PriceResponse : BaseDto
    {
        public decimal Value { get; set; }
        public int Type { get; set; }
        public int ProductId { get; set; }
    }
}
