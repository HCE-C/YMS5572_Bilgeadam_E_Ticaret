using E_Ticaret.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.MemberGroup
{
    public class MemberGroupResponse : BaseDto
    {
        public string Name { get; set; }
        public int PriceIndex { get; set; }
        public string AllowedPaymentGateWays { get; set; }
    }
}
