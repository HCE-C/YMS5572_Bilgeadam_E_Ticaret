using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.CartItemAttributeService
{
    public class CartItemAttributeService : BaseService<CartItemAttribute>, ICartItemAttributeService
    {
        public CartItemAttributeService(DataContext db)
            : base(db)
        {
        }
    }
}
