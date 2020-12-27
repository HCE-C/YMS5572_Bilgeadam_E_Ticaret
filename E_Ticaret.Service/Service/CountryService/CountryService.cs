using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.CountryService
{
    public class CountryService : BaseService<Country> , ICountryService
    {
        public CountryService(DataContext db)
           : base(db)
        {
        }
    }
}
