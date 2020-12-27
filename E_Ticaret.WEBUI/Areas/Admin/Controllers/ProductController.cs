using AutoMapper;
using E_Ticaret.Common.DTOs.Pimage;
using E_Ticaret.Common.DTOs.Product;
using E_Ticaret.Core.Entity.Enums;
using E_Ticaret.WEBUI.APIs;
using E_Ticaret.WEBUI.Areas.Admin.Models.ProductViewModels;
using E_Ticaret.WEBUI.Infrastructure.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductApi _productApi;
        private readonly IPimageApi _pimageApi;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductApi productApi, IPimageApi pimageApi, IWebHostEnvironment env, IMapper mapper)
        {
            _productApi = productApi;
            _pimageApi = pimageApi;
            _env = env;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Active"] = "Product";
            var productResult = await _productApi.GetAll();
            var imageResult = await _pimageApi.GetAll();
            if (productResult.IsSuccessStatusCode && productResult.Content.IsSuccess && productResult.Content.ResultData != null)
            {
                var products = _mapper.Map<List<ProductViewModel>>(productResult.Content.ResultData);
                if (imageResult.IsSuccessStatusCode && imageResult.Content.IsSuccess && imageResult.Content.ResultData != null)
                {
                    var imageList = imageResult.Content.ResultData;
                    foreach (var image in imageList)
                    {
                        var product = products.Where(x => x.Id == image.ProductId).FirstOrDefault();
                        product.Pimage = image;
                        product.Pimage.Filename = image.Filename;
                    }
                }
                return View(products);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Active"] = "Product";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model, List<IFormFile> files)
        {
            bool uploadResult = false;
            if (ModelState.IsValid)
            {
                model.Status = Status.Active;
                var productResult = await _productApi.Post(_mapper.Map<ProductRequest>(model));
                if (productResult.IsSuccessStatusCode && productResult.Content.IsSuccess && productResult.Content.ResultData != null)
                {
                    var fName = Upload.imageUpload(files, _env, out uploadResult);
                    if (uploadResult)
                    {
                        PimageRequest image = new PimageRequest
                        {
                            Filename = fName,
                            ProductId = productResult.Content.ResultData.Id,
                            Extension = fName.Substring(fName.IndexOf('.')),
                            DirectoryName = "uploads",
                            Status = Status.Active,
                            Attachment = "",
                            SortOrder = 1
                        };
                        var productImageResult = await _pimageApi.Post(image);
                        if (!productImageResult.IsSuccessStatusCode || !productImageResult.Content.IsSuccess || productImageResult.Content.ResultData == null)
                            TempData["Message"] = "Resim veritabanına yüklenirken bir hata meydana geldi ...";

                    }
                    else
                    {
                        TempData["Message"] = fName;
                        return View(model);
                    }

                    return RedirectToAction("Index");
                }


            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewData["Active"] = "Product";
            var productResult = await _productApi.GetById(id);
            var imageResult = await _pimageApi.GetAll();
            if (productResult.IsSuccessStatusCode && productResult.Content.IsSuccess && productResult.Content.ResultData != null)
            {
                var product = _mapper.Map<UpdateProductViewModel>(productResult.Content.ResultData);
                if (imageResult.IsSuccessStatusCode && imageResult.Content.IsSuccess && imageResult.Content.ResultData != null)
                {
                    product.Pimage = imageResult.Content.ResultData.FirstOrDefault(x => x.ProductId == id);
                }
                return View(product);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductViewModel model, List<IFormFile> files)
        {
            bool uploadResult = false;
            if (ModelState.IsValid)
            {
                var productResult = await _productApi.Put(model.Id, _mapper.Map<ProductRequest>(model));
                if (productResult.IsSuccessStatusCode && productResult.Content.IsSuccess && productResult.Content.ResultData != null)
                {
                    var fName = Upload.imageUpload(files, _env, out uploadResult);
                    if (uploadResult)
                    {
                        PimageRequest image = new PimageRequest
                        {
                            Filename = fName,
                            ProductId = productResult.Content.ResultData.Id,
                            Extension = fName.Substring(fName.IndexOf('.')),
                            DirectoryName = "uploads",
                            Status = Status.Active,
                            Attachment = "",
                            SortOrder = 1
                        };
                        var productImageResult = await _pimageApi.Post(image);
                        if (!productImageResult.IsSuccessStatusCode || !productImageResult.Content.IsSuccess || productImageResult.Content.ResultData == null)
                            TempData["Message"] = "Resim veritabanına yüklenirken bir hata meydana geldi ...";

                    }
                    else
                    {
                        TempData["Message"] = fName;
                        return View(model);
                    }

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Active"] = "Product";
            var productResult = await _productApi.Delete(id);
            if (productResult.IsSuccessStatusCode && productResult.Content.IsSuccess && productResult.Content.ResultData != null)
                TempData["Message"] = "Başarıyla Silindi";
            TempData["Message"] = "Bir şeyler ters gitti ...";

            return RedirectToAction("Index");
        }
    }
}
