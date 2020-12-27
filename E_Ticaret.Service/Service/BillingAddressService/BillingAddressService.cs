using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;
using E_Ticaret.Service.Service.BillingAddressService;

namespace E_Ticaret.Service.BillingAddressService
{
    public class BillingAddressService : BaseService<BillingAddress> , IBillingAddressService
    {
        public BillingAddressService(DataContext db)
            :base(db)
        {
        }
    }
}
