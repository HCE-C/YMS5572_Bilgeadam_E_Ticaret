using AutoMapper;
using E_Ticaret.WEBUI.APIs;
using E_Ticaret.WEBUI.Areas.Admin.Models.ProductViewModels;
using E_Ticaret.WEBUI.Infrastructure.Extensions;
using E_Ticaret.WEBUI.Models;
using E_Ticaret.WEBUI.Models.AdressViewModels.ShippingAdressVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryApi _categoryApi;
        private readonly IProductApi _productApi;
        private readonly IPimageApi _pimageApi;
        private readonly ICartApi _cartApi;
        private readonly ICartItemApi _cartItemApi;
        private readonly IShippingApi _shippingApi;
        private readonly ICountryApi _countryApi;
        private readonly ILocationApi _locationApi;

        public ShopController(
            IMapper mapper, ICategoryApi categoryApi, IProductApi productApi,
            IPimageApi pimageApi, ICartApi cartApi, ICartItemApi cartItemApi, IShippingApi shippingApi,
            ICountryApi countryApi, ILocationApi locationApi)
        {
            _mapper = mapper;
            _categoryApi = categoryApi;
            _productApi = productApi;
            _pimageApi = pimageApi;
            _cartApi = cartApi;
            _cartItemApi = cartItemApi;
            _shippingApi = shippingApi;
            _countryApi = countryApi;
            _locationApi = locationApi;
        }

        public async Task<IActionResult> Index(string catInfo)
        {
            var _session = HttpContext.Session;

            TempData["CatInfo"] = catInfo;

            var productResult = await _productApi.GetActive();
            var pimageResult = await _pimageApi.GetAll();
            if (productResult.IsSuccessStatusCode && productResult.Content.IsSuccess && productResult.Content.ResultData != null)
            {
                var productList = _mapper.Map<List<ProductViewModel>>(productResult.Content.ResultData);
                decimal price = 0;
                int count = 0;
                foreach (var item in productList)
                {
                    item.Pimage = pimageResult.Content.ResultData.FirstOrDefault(x => x.ProductId == item.Id);
                    if (_session.Get("Sepet") != null)
                    {
                        var sessionCart = _session.GetObject<Dictionary<int, MasterVM>>("Sepet");

                        if (sessionCart.ContainsKey(item.Id))
                        {
                            ViewData[item.Id.ToString()] = sessionCart[item.Id].Quantity.ToString("F0");
                            price += sessionCart[item.Id].Quantity * item.Price1;
                            count = sessionCart.Count;
                        }
                        else
                        {
                            ViewData[item.Id.ToString()] = 0;
                        }

                    }

                }
                ViewData["Price"] = price.ToString("F2");
                ViewData["Count"] = count;
                return View(productList);
            }
            return View();
        }


        public IActionResult AddCart(int id)
        {
            var _session = HttpContext.Session;
            // Yeni bir sepet oluşturuluyorsa yapılacakları yaptım.
            // Login olmadan mevcut sepet için gelirse veya login olduktan sonra kendi kayıtlı sepeti varsa yapılacaklar....

            if (id > 0)
            {
                var _cartList = new Dictionary<int, MasterVM>();
                var _masterVM = new MasterVM
                {
                    SessionId = _session.Id,
                    Locked = 0,
                    ProductId = id,
                    CategoryId = 1
                };                

                var sessionCart =
                    _session.Get("Sepet") != null ?
                    _session.GetObject<Dictionary<int, MasterVM>>("Sepet") :
                    null;

                if (sessionCart == null)
                {
                    _masterVM.Quantity = 1;
                    _cartList.Add(id, _masterVM);
                    _session.SetObject<Dictionary<int, MasterVM>>("Sepet", _cartList);
                    sessionCart = _cartList;
                }
                else
                {
                    sessionCart = _session.GetObject<Dictionary<int, MasterVM>>("Sepet");
                    if (sessionCart.ContainsKey(id))
                    {
                        sessionCart[id].Quantity++;
                    }
                    else
                    {
                        _masterVM.Quantity = 1;
                        sessionCart.Add(id, _masterVM);
                    }
                    _session.SetObject<Dictionary<int, MasterVM>>("Sepet", sessionCart);
                }
                decimal price = 0;
                int count = 0;
                foreach (var item in sessionCart.Values)
                {
                    count += 1;
                    price += item.Price;
                }

                ViewData["Price"] = price.ToString("F2");
                ViewData["Count"] = count;

                ViewData[id.ToString()] = sessionCart[id].Quantity;
                return Json(new { quantity = sessionCart[id].Quantity });
            }

            return Json(new { message = "Id bilgisi gönderilemedi" });
        }


        public IActionResult RemoveCart(int id, bool deleteItem)
        {
            var _session = HttpContext.Session;
            if (id > 0)
            {
                var sessionCart =
                    _session.Get("Sepet") != null ?
                    _session.GetObject<Dictionary<int, MasterVM>>("Sepet") :
                    null;

                if (sessionCart != null)
                {
                    if (deleteItem)
                    {
                        sessionCart.Remove(id);
                    }
                    else
                    {
                        if (sessionCart[id].Quantity == 1)
                            sessionCart.Remove(id);
                        else
                            sessionCart[id].Quantity = sessionCart[id].Quantity - 1;
                    }

                    _session.SetObject("Sepet", sessionCart);
                }

                decimal price = 0;
                int count = 0;
                foreach (var item in sessionCart.Values)
                {
                    count += 1;
                    price += item.Price;
                }

                ViewData["Price"] = price.ToString("F2");
                ViewData["Count"] = count;

                var cartItemQuantity = sessionCart.ContainsKey(id) ? sessionCart[id].Quantity.ToString(): "";
                ViewData[id.ToString()] = cartItemQuantity;
                return Json(new { quantity = cartItemQuantity });
            }
            return Json(new { message = "Id bilgisi gönderilemedi" });
        }

        public IActionResult DelItem(int id)
        {
            var _session = HttpContext.Session;
            if (id > 0)
            {
                var sessionCart =
                    _session.Get("Sepet") != null ?
                    _session.GetObject<Dictionary<int, MasterVM>>("Sepet") :
                    null;
                if(sessionCart != null)
                {
                    sessionCart.Remove(id);
                    _session.SetObject<Dictionary<int, MasterVM>>("Sepet", sessionCart);

                    return Json(new { message = "İlgili id sepetten başarıyla silindi" });
                }

                decimal price = 0;
                int count = 0;
                foreach (var item in sessionCart.Values)
                {
                    count += 1;
                    price += item.Price;
                }

                ViewData["Price"] = price.ToString("F2");
                ViewData["Count"] = count;


                return Json(new { message = "Session'da cart bulunamadı" });
            }

            return Json(new { message = "Geçersiz id" });
        }

        public async Task<IActionResult> Cart()
        {
            var _session = HttpContext.Session;
            List<MasterVM> model = new List<MasterVM>();
            var productResult = await _productApi.GetActive();
            var pimageResult = await _pimageApi.GetAll();
            if (productResult.IsSuccessStatusCode && productResult.Content.IsSuccess && productResult.Content.ResultData != null)
            {
                var productList = _mapper.Map<List<ProductViewModel>>(productResult.Content.ResultData);
                decimal price = 0;
                int count = 0;
                foreach (var item in productList)
                {
                    item.Pimage = pimageResult.Content.ResultData.FirstOrDefault(x => x.ProductId == item.Id);
                    if (_session.Get("Sepet") != null)
                    {
                        var sessionCart = _session.GetObject<Dictionary<int, MasterVM>>("Sepet");

                        if (sessionCart.ContainsKey(item.Id))
                        {
                            sessionCart[item.Id].FilePath = item.Pimage.Filename;
                            sessionCart[item.Id].ProductName = item.Name;
                            sessionCart[item.Id].Price = item.Price1;
                            model.Add(sessionCart[item.Id]);
                            price += sessionCart[item.Id].Quantity * item.Price1;
                            count = sessionCart.Count;
                        }
                        else
                        {
                            ViewData[item.Id.ToString()] = 0;
                        }
                    }
                }
                ViewData["Price"] = price.ToString("F2");
                ViewData["Count"] = count;
            }            
            return View(model);
        }

        public async Task<IActionResult> Checkout()
        {
            int id = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

            var _session = HttpContext.Session;

            List<MasterVM> model = new List<MasterVM>();
            var productResult = await _productApi.GetActive();
            var shippingResult = await _shippingApi.GetById(id);
            var countryResult = await _countryApi.GetAll();
            var locationResult = await _locationApi.GetAll();
            ViewBag.Country = countryResult.Content.ResultData;
            ViewBag.Location = locationResult.Content.ResultData;
            if (productResult.IsSuccessStatusCode && productResult.Content.IsSuccess && productResult.Content.ResultData != null)
            {
                var productList = _mapper.Map<List<ProductViewModel>>(productResult.Content.ResultData);
                decimal price = 0;
                int count = 0;
                foreach (var item in productList)
                {
                    if (_session.Get("Sepet") != null)
                    {
                        var sessionCart = _session.GetObject<Dictionary<int, MasterVM>>("Sepet");

                        if (sessionCart.ContainsKey(item.Id))
                        {
                            sessionCart[item.Id].ProductName = item.Name;
                            sessionCart[item.Id].Price = item.Price1;
                            model.Add(sessionCart[item.Id]);
                            price += sessionCart[item.Id].Quantity * item.Price1;
                            count = sessionCart.Count;
                        }
                        else
                        {
                            ViewData[item.Id.ToString()] = 0;
                        }
                    }
                }
                ViewData["Count"] = count;
                ViewData["Price"] = price.ToString("F2");
                
                model.FirstOrDefault().UpdateShippingViewModel = _mapper.Map< UpdateShippingViewModel>(shippingResult.Content.ResultData);
            }
            return View(model);
        }
    }
}
