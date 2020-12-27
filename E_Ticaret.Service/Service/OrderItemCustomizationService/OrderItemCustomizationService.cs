using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.OrderItemCustomizationService
{
    public class OrderItemCustomizationService : BaseService<OrderItemCustomization> , IOrderItemCustomizationService
    {
        public OrderItemCustomizationService(DataContext db)
              : base(db)
        {
        }
    }
}
