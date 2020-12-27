using E_Ticaret.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Ticaret.Model.SeedData
{
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Meyve,Sebze",
                    ImageFilename = "\\uploads\\11263-meyve_sebze-43b02f.jpg",
                    Percent = 1,
                    CreatedMemberId = 1,
                    DisplayShowcaseContent = 1,
                    ShowcaseContent = "1",
                    ShowcaseContentDisplayType = ShowcaseContentDisplayType.CategoryContent,
                    HasChildren = HasChildren.No,
                    SortOrder = 1,
                    Status = Core.Entity.Enums.Status.Active
                },
                new Category()
                {
                    Id = 2,
                    Name = "Et,Tavuk,Balık",
                    ImageFilename = "\\uploads\\35c329ba_c5d0_46a8_96e1_809e17f9bce1.jpeg",
                    Percent = 1,
                    CreatedMemberId = 1,
                    DisplayShowcaseContent = 1,
                    ShowcaseContent = "1",
                    ShowcaseContentDisplayType = ShowcaseContentDisplayType.CategoryContent,
                    HasChildren = HasChildren.No,
                    SortOrder = 1,
                    Status = Core.Entity.Enums.Status.Active
                },
                new Category()
                {
                    Id = 3,
                    Name = "Süt,Kahvaltılık",
                    ImageFilename = "\\uploads\\33b521ee_6f2c_4f0f_b592_e8a0b5424479.jpeg",
                    Percent = 1,
                    CreatedMemberId = 1,
                    DisplayShowcaseContent = 1,
                    ShowcaseContent = "1",
                    ShowcaseContentDisplayType = ShowcaseContentDisplayType.CategoryContent,
                    HasChildren = HasChildren.No,
                    SortOrder = 1,
                    Status = Core.Entity.Enums.Status.Active
                });
        }
    }
}