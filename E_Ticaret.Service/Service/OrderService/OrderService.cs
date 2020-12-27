using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.OrderService
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService(DataContext db)
              : base(db)
        {
        }
    }
}
