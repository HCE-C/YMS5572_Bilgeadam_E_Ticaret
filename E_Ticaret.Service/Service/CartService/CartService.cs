using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.CartService
{
   public class CartService : BaseService<Cart>, ICartService
    {
        public CartService(DataContext db)
            : base(db)
        {
        }
    }
}
