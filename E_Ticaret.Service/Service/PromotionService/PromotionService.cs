using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.PromotionService
{
    public class PromotionService : BaseService<Promotion>, IPromotionService
    {
        public PromotionService(DataContext db)
              : base(db)
        {
        }
    }
}
