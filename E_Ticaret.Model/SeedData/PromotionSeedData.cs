using E_Ticaret.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Ticaret.Model.SeedData
{
    public class PromotionSeedData : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.HasData(
                new Promotion()
                {
                    Id = 1,
                    Status = Core.Entity.Enums.Status.Active,
                    CreatedMemberId = 1,
                    Label = "Hepsi20"
                },
                new Promotion()
                {
                    Id = 2,
                    Status = Core.Entity.Enums.Status.Active,
                    CreatedMemberId = 1,
                    Label = "Indirim15"
                },
                new Promotion()
                {
                    Id = 3,
                    Status = Core.Entity.Enums.Status.Active,
                    CreatedMemberId = 1,
                    Label = "İndirimYOK"
                });
        }
    }
}
