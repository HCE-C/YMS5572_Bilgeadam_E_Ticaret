using E_Ticaret.Core.Entity;
using E_Ticaret.Model.Enums.ProductEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Model.Entities
{
    //Ürün
    public class Product : CoreEntity
    {
        public Product()
        {
            Prices = new HashSet<Price>();
            Pimages = new HashSet<Pimage>();
            OrderItems = new HashSet<OrderItem>();
            Products = new HashSet<Product>();
            CartItems = new HashSet<CartItem>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string FullName { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public decimal Price1 { get; set; }
        public int Warranty { get; set; }
        public int Tax { get; set; }
        public decimal StockAmount { get; set; }
        public decimal VolumetricWeight { get; set; }
        public decimal BuyingPrice { get; set; }
        public string StockTypeLabel { get; set; }
        public decimal Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal MoneyOrderDiscount { get; set; }
        public TaxIncluded TaxIncluded { get; set; }
        public string Distributor { get; set; }
        public IsGifted IsGifted { get; set; }
        public string Gift { get; set; }
        public CustomShippingDisabled CustomShippingDisabled { get; set; }
        public decimal CustomShippingCost { get; set; }
        public string MarketPriceDetail { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public string PageTitle { get; set; }
        public HasOption Variant { get; set; }
        public string ShortDetails { get; set; }
        public string SearchKeyWords { get; set; }
        public string InstallmentTreshold { get; set; }
        public int HomeSortOrder { get; set; }
        public int PopularSortOrder { get; set; }
        public int BrandSortOrder { get; set; }
        public int FeaturedSortOrder { get; set; }
        public int CampaignedSortOrder { get; set; }
        public int NewSortOrder { get; set; }
        public int DiscountedSortOrder { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int? ParentId { get; set; }
        public Product Parent { get; set; }
        public ICollection<Product> Products { get; set; }
        public ProductToCountDown CountDown { get; set; }
        public Member CreatedMemberProduct { get; set; }
        public Member ModifiedMemberProduct { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<Price> Prices { get; set; }
        public ICollection<Pimage> Pimages { get; set; }
        public ICollection<ProductToCategory> ProductToCategories { get; set; }

    }
}
