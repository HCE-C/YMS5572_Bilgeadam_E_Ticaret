using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.BrandService
{
    public class BrandService : BaseService<Brand>, IBrandService
    {
        public BrandService(DataContext db)
            : base(db)
        {
        }
    }
}
