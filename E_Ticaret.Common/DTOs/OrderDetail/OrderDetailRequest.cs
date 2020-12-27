using E_Ticaret.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.OrderDetail
{
   public class OrderDetailRequest : BaseDto
    {
        public string VarKey { get; set; }
        public string VarValue { get; set; }
        public int OrderId { get; set; }
    }
}
