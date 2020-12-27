using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.ProductToCategoryService
{
    public class ProductToCategoryService : BaseService<ProductToCategory> , IProductToCategoryService
    {
        public ProductToCategoryService(DataContext db)
              : base(db)
        {
        }
    }
}
