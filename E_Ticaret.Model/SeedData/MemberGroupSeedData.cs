using E_Ticaret.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Ticaret.Model.SeedData
{
    public class MemberGroupSeedData : IEntityTypeConfiguration<MemberGroup>
    {
        public void Configure(EntityTypeBuilder<MemberGroup> builder)
        {
            builder.HasData(
                new MemberGroup()
                {
                    Id = 1,
                    Status = Core.Entity.Enums.Status.Active,
                    Name = "Kullanıcılar",
                    PriceIndex = 1,
                    AllowedPaymentGateWays = "1"
                });
        }
    }
}
