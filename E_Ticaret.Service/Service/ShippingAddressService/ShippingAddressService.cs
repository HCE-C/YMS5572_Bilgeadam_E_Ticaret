using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.ShippingAddressService
{
    public class ShippingAddressService : BaseService<ShippingAddress>, IShippingAddressService
    {
        public ShippingAddressService(DataContext db)
             : base(db)
        {
        }
    }
}
