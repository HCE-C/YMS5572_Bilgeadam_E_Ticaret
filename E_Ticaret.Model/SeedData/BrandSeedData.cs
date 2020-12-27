using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Enums.GeneralEnums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Ticaret.Model.SeedData
{
    public class BrandSeedData : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand
                {
                    Id = 3,                    
                    Name = "Ercan Mandıra",
                    Slug = "Apple",
                    SortOrder = 1,
                    DisplayShowcaseContent = DisplayShowcaseContent.Yes,
                    Status = Core.Entity.Enums.Status.Active
                });
        }
    }
}