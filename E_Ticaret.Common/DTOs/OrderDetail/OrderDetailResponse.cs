using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Common.DTOs.Order;

namespace E_Ticaret.Common.DTOs.OrderDetail
{
    public class OrderDetailResponse : BaseDto
    {
        public string VarKey { get; set; }
        public string VarValue { get; set; }

        public int OrderId { get; set; }
        public OrderResponse Order { get; set; }
    }
}
