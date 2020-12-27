using AutoMapper;
using E_Ticaret.WEBUI.APIs;
using E_Ticaret.WEBUI.Areas.Admin.Models.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly ICategoryApi _categoryApi;
        private readonly IMapper _mapper;

        public SideBarViewComponent(ICategoryApi categoryApi, IMapper mapper)
        {
            _categoryApi = categoryApi;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryResult = await _categoryApi.GetActive();
            if (categoryResult.IsSuccessStatusCode && categoryResult.Content.IsSuccess && categoryResult.Content.ResultData != null)
            {
                var categoryList = _mapper.Map<List<CategoryViewModel>>(categoryResult.Content.ResultData);
                return View(categoryList.Where(x=>x.ParentId == null).ToList());
            }
            return View();
        }
    }
}
