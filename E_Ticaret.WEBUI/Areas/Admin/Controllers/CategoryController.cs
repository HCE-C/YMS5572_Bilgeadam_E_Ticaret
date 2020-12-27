using AutoMapper;
using E_Ticaret.Common.DTOs.Category;
using E_Ticaret.WEBUI.APIs;
using E_Ticaret.WEBUI.Areas.Admin.Models.CategoryViewModels;
using E_Ticaret.WEBUI.Infrastructure.Helpers;
using E_Ticaret.WEBUI.Models.MemberViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryApi _categoryApi;
        private readonly IMapper _mapper;

        public CategoryController(IWebHostEnvironment env, ICategoryApi categoryApi, IMapper mapper)
        {
            _env = env;
            _categoryApi = categoryApi;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Active"] = "Category";
            //TempData["Category"] = "active";
            var categoryResult = await _categoryApi.GetAll();
            if (categoryResult.IsSuccessStatusCode && categoryResult.Content.IsSuccess && categoryResult.Content.ResultData != null)
            {
                var categoryList = _mapper.Map<List<CategoryViewModel>>(categoryResult.Content.ResultData);
                return View(categoryList);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Active"] = "Category";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel model, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                bool imageResult;
                string imagePath = Upload.imageUpload(files, _env, out imageResult);
                if (imageResult)
                {
                    model.ImageFilename = imagePath;
                }
                else
                {
                    TempData["Message"] = imagePath;
                    return View(model);
                }
                var categoryResult = await _categoryApi.Post(_mapper.Map<CategoryRequest>(model));
                if (categoryResult.IsSuccessStatusCode && categoryResult.Content.IsSuccess && categoryResult.Content.ResultData != null)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewData["Active"] = "Category";
            var categoryResult = await _categoryApi.GetAll();
            if (categoryResult.IsSuccessStatusCode && categoryResult.Content.IsSuccess && categoryResult.Content.ResultData != null)
            {
                var category = _mapper.Map<List<UpdateCategoryViewModel>>(categoryResult.Content.ResultData);
                ViewBag.ParentName = category.Where(x=>x.ParentId == null);
                return View(category.FirstOrDefault(x=>x.Id == id));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryApi.Put(model.Id, _mapper.Map<CategoryRequest>(model));
                if(result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                    return RedirectToAction("Index");
            }
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Active"] = "Category";
            var categoryResult = await _categoryApi.Delete(id);
            if (categoryResult.IsSuccessStatusCode && categoryResult.Content.IsSuccess && categoryResult.Content.ResultData != null)
            {
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Bir şeyler ters gitti ...";
            return RedirectToAction("Index");
        }
    }
}
