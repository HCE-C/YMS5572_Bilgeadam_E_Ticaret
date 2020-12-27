using E_Ticaret.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.ProductToCountDown
{
    public class ProductToCountDownResponse : BaseDto
    {
        public string ExpireDate { get; set; }
        public int ProductId { get; set; }
    }
}
