using E_Ticaret.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Ticaret.Model.SeedData
{
    public class ProductSeedData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Status = Core.Entity.Enums.Status.Active,
                    CreatedMemberId = 1,
                    Name = "Elma",
                    FullName = "Starkin Elma",
                    Sku = "1234",
                    Barcode = "Barcode",
                    Price1 = 6,
                    Warranty = 1,
                    Tax = 2,
                    StockAmount = 2500,
                    VolumetricWeight = 1,
                    BuyingPrice = 4.99M,
                    DiscountType = Enums.ProductEnums.DiscountType.DiscountedPrice,
                    TaxIncluded = Enums.ProductEnums.TaxIncluded.No,
                    IsGifted = Enums.ProductEnums.IsGifted.No,
                    Gift = "0",
                    CustomShippingDisabled = Enums.ProductEnums.CustomShippingDisabled.Selected,
                    CustomShippingCost = 15,
                    Variant = Enums.ProductEnums.HasOption.Empty,
                    ShortDetails = "1",
                    HomeSortOrder = 1,
                    PopularSortOrder = 1,
                    BrandSortOrder = 1,
                    FeaturedSortOrder = 1,
                    CampaignedSortOrder = 1,
                    NewSortOrder = 1,
                    DiscountedSortOrder = 1,
                    BrandId = 3,
                    CurrencyId = 2
                },
                new Product
                {
                    Id = 29,
                    Status = Core.Entity.Enums.Status.Active,
                    CreatedMemberId = 1,
                    Name = "Domates",
                    FullName = "Cherry Domates",
                    Sku = "1234",
                    Barcode = "Barcode",
                    Price1 = 4.50M,
                    Warranty = 1,
                    Tax = 2,
                    StockAmount = 2500,
                    VolumetricWeight = 1,
                    BuyingPrice = 4.99M,
                    DiscountType = Enums.ProductEnums.DiscountType.DiscountedPrice,
                    TaxIncluded = Enums.ProductEnums.TaxIncluded.No,
                    IsGifted = Enums.ProductEnums.IsGifted.No,
                    Gift = "0",
                    CustomShippingDisabled = Enums.ProductEnums.CustomShippingDisabled.Selected,
                    CustomShippingCost = 15,
                    Variant = Enums.ProductEnums.HasOption.Empty,
                    ShortDetails = "1",
                    HomeSortOrder = 1,
                    PopularSortOrder = 1,
                    BrandSortOrder = 1,
                    FeaturedSortOrder = 1,
                    CampaignedSortOrder = 1,
                    NewSortOrder = 1,
                    DiscountedSortOrder = 1,
                    BrandId = 3,
                    CurrencyId = 2
                },
                new Product
                {
                    Id = 30,
                    Status = Core.Entity.Enums.Status.Active,
                    CreatedMemberId = 1,
                    Name = "Muz",
                    FullName = "Çikita Muz",
                    Sku = "1234",
                    Barcode = "Barcode",
                    Price1 = 14,
                    Warranty = 1,
                    Tax = 2,
                    StockAmount = 2500,
                    VolumetricWeight = 1,
                    BuyingPrice = 4.99M,
                    DiscountType = Enums.ProductEnums.DiscountType.DiscountedPrice,
                    TaxIncluded = Enums.ProductEnums.TaxIncluded.No,
                    IsGifted = Enums.ProductEnums.IsGifted.No,
                    Gift = "0",
                    CustomShippingDisabled = Enums.ProductEnums.CustomShippingDisabled.Selected,
                    CustomShippingCost = 15,
                    Variant = Enums.ProductEnums.HasOption.Empty,
                    ShortDetails = "1",
                    HomeSortOrder = 1,
                    PopularSortOrder = 1,
                    BrandSortOrder = 1,
                    FeaturedSortOrder = 1,
                    CampaignedSortOrder = 1,
                    NewSortOrder = 1,
                    DiscountedSortOrder = 1,
                    BrandId = 3,
                    CurrencyId = 2
                }

                );
        }
    }
}
