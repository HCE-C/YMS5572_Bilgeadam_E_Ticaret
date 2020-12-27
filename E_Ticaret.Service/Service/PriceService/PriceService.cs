using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.PriceService
{
    public class PriceService : BaseService<Price> , IPriceService
    {
        public PriceService(DataContext db)
              : base(db)
        {
        }
    }
}
