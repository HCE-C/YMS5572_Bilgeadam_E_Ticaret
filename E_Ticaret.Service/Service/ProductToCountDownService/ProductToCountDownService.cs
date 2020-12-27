using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.ProductToCountDownService
{
    public class ProductToCountDownService : BaseService<ProductToCountDown>, IProductToCountDownService
    {
        public ProductToCountDownService(DataContext db)
              : base(db)
        {
        }
    }
}
