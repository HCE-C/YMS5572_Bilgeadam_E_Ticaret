using E_Ticaret.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Ticaret.Model.SeedData
{
    public class ProductToCategorySeedData : IEntityTypeConfiguration<ProductToCategory>
    {
        public void Configure(EntityTypeBuilder<ProductToCategory> builder)
        {
            builder.HasData(
                new ProductToCategory
                {
                    Id = 1,
                    Status = Core.Entity.Enums.Status.Active,
                    CreatedMemberId = 1,
                    SortOrder = 1,
                    ProductId = 1,
                    CategoryId = 1
                });
        }
    }
}
