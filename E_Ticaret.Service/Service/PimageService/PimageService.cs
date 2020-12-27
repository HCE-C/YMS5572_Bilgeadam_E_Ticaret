using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.PimageService
{
    public class PimageService : BaseService<Pimage> , IPimageService
    {
        public PimageService(DataContext db)
              : base(db)
        {
        }
    }
}
