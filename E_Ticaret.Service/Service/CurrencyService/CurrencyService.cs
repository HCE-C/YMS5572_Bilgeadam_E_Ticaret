using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.CurrencyService
{
    public class CurrencyService : BaseService<Currency>, ICurrencyService
    {
        public CurrencyService(DataContext db)
           : base(db)
        {
        }
    }
}
