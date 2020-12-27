using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.RegionService
{
    public class RegionService : BaseService<Region> , IRegionService
    {
        public RegionService(DataContext db)
              : base(db)
        {
        }
    }
}
