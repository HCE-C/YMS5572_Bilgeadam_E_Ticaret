using E_Ticaret.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Ticaret.Model.SeedData
{
    class ShopTokenSeedData : IEntityTypeConfiguration<ShopToken>
    {
        public void Configure(EntityTypeBuilder<ShopToken> builder)
        {
            builder.HasData(
                new ShopToken()
                {
                    Id = 1,
                    Status = Core.Entity.Enums.Status.Active,
                    CreatedMemberId = 1,
                    Code = "1"
                });
        }
    }
}
