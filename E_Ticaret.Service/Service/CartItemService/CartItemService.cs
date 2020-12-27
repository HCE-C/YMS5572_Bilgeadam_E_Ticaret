using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.CartItemService
{
    public class CartItemService : BaseService<CartItem> , ICartItemService
    {
        public CartItemService(DataContext db)
            : base(db)
        {
        }
    }
}
