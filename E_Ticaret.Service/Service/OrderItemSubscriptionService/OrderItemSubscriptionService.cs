using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.OrderItemSubscriptionService
{
    public class OrderItemSubscriptionService : BaseService<OrderItemSubscription> , IOrderItemSubscriptionService
    {
        public OrderItemSubscriptionService(DataContext db)
              : base(db)
        {
        }
    }
}
