using E_Ticaret.API.Infrastructure.Models.Base;
using E_Ticaret.Common.Client.Services;
using E_Ticaret.Service.BillingAddressService;
using E_Ticaret.Service.Service.BillingAddressService;
using E_Ticaret.Service.Service.BrandService;
using E_Ticaret.Service.Service.CartItemAttributeService;
using E_Ticaret.Service.Service.CartItemService;
using E_Ticaret.Service.Service.CartService;
using E_Ticaret.Service.Service.CategoryService;
using E_Ticaret.Service.Service.CountryService;
using E_Ticaret.Service.Service.CurrencyService;
using E_Ticaret.Service.Service.LocationService;
using E_Ticaret.Service.Service.MailListGroupService;
using E_Ticaret.Service.Service.MailListService;
using E_Ticaret.Service.Service.MemberGroupService;
using E_Ticaret.Service.Service.MemberService;
using E_Ticaret.Service.Service.OrderDetailService;
using E_Ticaret.Service.Service.OrderItemCustomizationService;
using E_Ticaret.Service.Service.OrderItemService;
using E_Ticaret.Service.Service.OrderItemSubscriptionService;
using E_Ticaret.Service.Service.OrderService;
using E_Ticaret.Service.Service.PimageService;
using E_Ticaret.Service.Service.PriceService;
using E_Ticaret.Service.Service.ProductService;
using E_Ticaret.Service.Service.ProductToCategoryService;
using E_Ticaret.Service.Service.ProductToCountDownService;
using E_Ticaret.Service.Service.PromotionService;
using E_Ticaret.Service.Service.RegionService;
using E_Ticaret.Service.Service.ShippingAddressService;
using E_Ticaret.Service.Service.ShopTokenService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace E_Ticaret.API.Infrastructure.Extensions
{
    public static class AddDependencyInj
    {
        public static void AddInjection(this IServiceCollection services)
        {
            services.AddTransient<IBillingAddressService, BillingAddressService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICartItemService, CartItemService>();
            services.AddTransient<ICartItemAttributeService, CartItemAttributeService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IMailListService, MailListService>();
            services.AddTransient<IMailListGroupService, MailListGroupService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IMemberGroupService, MemberGroupService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<IOrderItemService, OrderItemService>();
            services.AddTransient<IOrderItemCustomizationService, OrderItemCustomizationService>();
            services.AddTransient<IOrderItemSubscriptionService, OrderItemSubscriptionService>();
            services.AddTransient<IPimageService, PimageService>();
            services.AddTransient<IPriceService, PriceService>();
            services.AddTransient<IPromotionService, PromotionService>();
            services.AddTransient<IRegionService, RegionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductToCategoryService, ProductToCategoryService>();
            services.AddTransient<IProductToCountDownService, ProductToCountDownService>();
            services.AddTransient<IShippingAddressService, ShippingAddressService>();
            services.AddTransient<IShopTokenService, ShopTokenService>();


            services.AddTransient<IWorkContext, ApiWorkContext>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
