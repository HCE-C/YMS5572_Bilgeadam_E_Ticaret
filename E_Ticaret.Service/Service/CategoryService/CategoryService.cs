using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;

namespace E_Ticaret.Service.Service.CategoryService
{
    public class CategoryService : BaseService<Category> , ICategoryService
    {
        public CategoryService(DataContext db)
            : base(db)
        {
        }
    }
}
