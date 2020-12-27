using AutoMapper;
using E_Ticaret.Common.DTOs.Cart;
using E_Ticaret.Common.DTOs.CartItem;
using E_Ticaret.Common.DTOs.Login;
using E_Ticaret.Common.DTOs.Member;
using E_Ticaret.WEBUI.APIs;
using E_Ticaret.WEBUI.Areas.Admin.Models.CategoryViewModels;
using E_Ticaret.WEBUI.Infrastructure.Extensions;
using E_Ticaret.WEBUI.Models;
using E_Ticaret.WEBUI.Models.AccountViewModels;
using E_Ticaret.WEBUI.Models.MemberViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountApi _accountApi;
        private readonly IMapper _mapper;
        private readonly IMemberApi _memberApi;
        private readonly ICategoryApi _categoryApi;
        private readonly IProductApi _productApi;
        private readonly IPimageApi _pimageApi;
        private readonly ICartApi _cartApi;
        private readonly ICartItemApi _cartItemApi;
        public HomeController(IAccountApi accountApi, IMapper mapper, IMemberApi memberApi,
            ICategoryApi categoryApi, IProductApi productApi, IPimageApi pimageApi, ICartApi cartApi, ICartItemApi cartItemApi)
        {
            _accountApi = accountApi;
            _mapper = mapper;
            _memberApi = memberApi;
            _categoryApi = categoryApi;
            _productApi = productApi;
            _pimageApi = pimageApi;
            _cartApi = cartApi;
            _cartItemApi = cartItemApi;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            TempData["Inavlid"] = "";
            if (ModelState.IsValid)
            {
                var loginResult = await _accountApi.Login(_mapper.Map<LoginRequest>(loginVM));
                if (loginResult.IsSuccessStatusCode && loginResult.Content.IsSuccess)
                {
                    #region SepetGiriş
                    var _session = HttpContext.Session;

                    var cartResult = await _cartApi.GetById(loginResult.Content.ResultData.Id);
                    if (cartResult.IsSuccessStatusCode && cartResult.Content.IsSuccess && cartResult.Content.ResultData != null)
                    {
                        var cartItemResult = await _cartItemApi.GetById(cartResult.Content.ResultData.Id);

                        if (cartItemResult.IsSuccessStatusCode && cartItemResult.Content.IsSuccess && cartItemResult.Content.ResultData != null)
                        {
                            var sessionCart = new Dictionary<int, MasterVM>();
                            foreach (var item in cartItemResult.Content.ResultData)
                            {
                                var _masterVM = new MasterVM();
                                _masterVM.ProductId = item.ProductId;
                                _masterVM.Price = item.Product.Price1;
                                _masterVM.Quantity = item.Quantity;
                                _masterVM.SessionId = cartResult.Content.ResultData.SessionId;
                                _masterVM.MemberId = loginResult.Content.ResultData.Id;
                                sessionCart.Add(item.ProductId, _masterVM);
                            }

                            _session.SetObject("Sepet", sessionCart);
                        }
                    }
                    #endregion

                    MemberResponse member = loginResult.Content.ResultData;
                    var claims = new List<Claim>()
                    {
                        new Claim("Id",member.Id.ToString()),
                        new Claim(ClaimTypes.Name, member.Firstname),
                        new Claim(ClaimTypes.Surname, member.Surname),
                        new Claim(ClaimTypes.Email, member.Email)
                    };
                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    HttpContext.Response.Cookies.Append("BilgeAdamAccessToken", member.AccessToken.AccessToken);
                    //new Microsoft.AspNetCore.Http.CookieOptions { Expires = loginVM.IsPersist ? DateTimeOffset.Now.AddMinutes(60) : DateTimeOffset.Now });

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = loginVM.IsPersist,
                        ExpiresUtc = DateTime.Now.AddMinutes(10)
                    };
                    await HttpContext.SignInAsync(principal, authProperties);

                    if (member.Title.ToLower() == "admin")
                        return RedirectToAction("Index", "Main", new { area = "Admin" });
                    return RedirectToAction("Index", "Shop");
                }

            }

            TempData["Inavlid"] = "Geçersiz kullanıcı adı veya şifresi";
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(CreateMemberViewModel memberVM)
        {
            if (ModelState.IsValid)
            {
                var createResult = await _memberApi.PostMember(_mapper.Map<MemberRequest>(memberVM));
                if (createResult.IsSuccessStatusCode && createResult.Content.IsSuccess && createResult?.Content?.ResultData != null)
                    return RedirectToAction("Index");
                return RedirectToAction("Index");
            }
            return View("Index", memberVM);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            #region SepetiDBKaydet Göndermek
            var _session = HttpContext.Session;
            var sessionCart =
            _session.Get("Sepet") != null ?
            _session.GetObject<Dictionary<int, MasterVM>>("Sepet") :
            null;
            if (sessionCart != null)
            {
                var memberId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value); ;
                var cartResp = await _cartApi.GetById(memberId);
                if (cartResp.IsSuccessStatusCode && cartResp.Content.IsSuccess && cartResp.Content.ResultData != null)
                {
                    var CartItemtResp = await _cartItemApi.GetById(cartResp.Content.ResultData.Id);
                    var dbCartItems = CartItemtResp.Content.ResultData;
                    if (dbCartItems != null)
                    {
                        foreach (var item in sessionCart)
                        {
                            var any = dbCartItems.Any(x => x.ProductId == item.Value.ProductId);
                            if (any)
                            {
                                var dbCartItem = dbCartItems.Find(x => x.ProductId == item.Value.ProductId);
                                dbCartItem.Quantity = item.Value.Quantity;
                                await _cartItemApi.Put(dbCartItem.Id, _mapper.Map<CartItemRequest>(dbCartItem));
                            }
                            else
                            {
                                var cartItem = new CartItemRequest();
                                cartItem.Quantity = item.Value.Quantity;
                                cartItem.ProductId = item.Value.ProductId;
                                cartItem.CategoryId = 1;
                                cartItem.CartId = cartResp.Content.ResultData.Id;
                                var cartItemResut = await _cartItemApi.Post(cartItem);
                            }

                        }
                    }
                    else
                    {
                        foreach (var item in sessionCart)
                        {

                            var cartItem = new CartItemRequest();
                            cartItem.Quantity = item.Value.Quantity;
                            cartItem.ProductId = item.Value.ProductId;
                            cartItem.CategoryId = 1;
                            cartItem.CartId = cartResp.Content.ResultData.Id;
                            var cartItemResut = await _cartItemApi.Post(cartItem);

                        }
                    }

                }
                else
                {

                    var cart = new CartRequest();
                    cart.MemberId = memberId;
                    cart.SessionId = _session.Id;
                    cart.Locked = 0;
                    var cartResult = await _cartApi.Post(cart);

                    foreach (var item in sessionCart)
                    {
                        var cartItem = new CartItemRequest();
                        cartItem.Quantity = item.Value.Quantity;
                        cartItem.ProductId = item.Value.ProductId;
                        cartItem.CategoryId = 1;
                        cartItem.CartId = cartResult.Content.ResultData.Id;
                        var cartItemResut = await _cartItemApi.Post(cartItem);
                    }
                }
            }
            #endregion

            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<PartialViewResult> HeroSection()
        {
            var categoryResult = await _categoryApi.GetActive();
            if (categoryResult.IsSuccessStatusCode && categoryResult.Content.IsSuccess && categoryResult.Content.ResultData != null)
            {
                var categoryList = _mapper.Map<List<CategoryViewModel>>(categoryResult.Content.ResultData);
                return PartialView(categoryList);
            }

            return PartialView();
        }
    }
}
