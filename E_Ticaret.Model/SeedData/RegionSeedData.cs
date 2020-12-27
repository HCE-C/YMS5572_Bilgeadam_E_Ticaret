using E_Ticaret.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Ticaret.Model.SeedData
{
    public class RegionSeedData : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasData(
                new Region()
                {
                    Id = 1,
                    Status = Core.Entity.Enums.Status.Active,
                    CreatedMemberId = 1,
                    Name = "İç Anadolu"
                },
                new Region()
                {
                    Id = 3,
                    Status = Core.Entity.Enums.Status.Active,
                    CreatedMemberId = 1,
                    Name = "Marmara"
                });
        }
    }
}
