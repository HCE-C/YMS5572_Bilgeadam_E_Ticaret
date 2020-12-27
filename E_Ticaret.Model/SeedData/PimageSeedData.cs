using E_Ticaret.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Ticaret.Model.SeedData
{
    public class PimageSeedData : IEntityTypeConfiguration<Pimage>
    {
        public void Configure(EntityTypeBuilder<Pimage> builder)
        {
            builder.HasData(
                new Pimage()
                {
                    Id = 7,
                    Status = Core.Entity.Enums.Status.Active,
                    Filename = "\\uploads\\a07a9f9b_7cfb_4bb8_92b1_2ab0e53d8686.jpeg",
                    CreatedMemberId = 1,
                    Extension = ".jpeg",
                    DirectoryName = "uploads",
                    SortOrder = 1,
                    ProductId = 1
                },
                new Pimage()
                {
                    Id = 12,
                    Status = Core.Entity.Enums.Status.Active,
                    Filename = "\\uploads\\b52d0061_2924_42db_ba94_5b0704a66106.jpeg",
                    CreatedMemberId = 1,
                    Extension = ".jpeg",
                    DirectoryName = "uploads",
                    SortOrder = 1,
                    ProductId = 29
                },
                new Pimage()
                {
                    Id = 17,
                    Status = Core.Entity.Enums.Status.Active,
                    Filename = "\\uploads\\2d37217f_c8ca_47d5_8262_ea81d3c5528c.jpeg",
                    CreatedMemberId = 1,
                    Extension = ".jpeg",
                    DirectoryName = "uploads",
                    SortOrder = 1,
                    ProductId = 30
                });
        }
    }
}
