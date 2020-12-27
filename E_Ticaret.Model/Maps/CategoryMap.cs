using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class CategoryMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasExtended();

                entity.Property(c => c.Name).HasMaxLength(255).IsRequired();
                entity.Property(c => c.Slug).HasMaxLength(255);
                entity.Property(c => c.DistributorCode).HasMaxLength(255);
                entity.Property(c => c.ImageFilename).HasMaxLength(255);
                entity.Property(c => c.Distributor).HasMaxLength(128);
                entity.Property(c => c.ShowcaseContent).HasMaxLength(65535);
                entity.Property(c => c.MetaKeywords).HasMaxLength(65535);
                entity.Property(c => c.MetaDescription).HasMaxLength(65535);
                entity.Property(c => c.PageTitle).HasMaxLength(65535);
                entity.Property(c => c.ShowcaseContentDisplayType).IsRequired();

                entity
                    .HasOne(c => c.Parent)
                    .WithMany(c => c.SubCategories)
                    .HasForeignKey(c => c.ParentId);

                entity
                   .HasOne(c => c.CreatedMemberCategory)
                   .WithMany(m => m.CreatedMemberCategories)
                   .HasForeignKey(c => c.CreatedMemberId);

                entity
                    .HasOne(c => c.ModifiedMemberCategory)
                    .WithMany(m => m.ModifiedMemberCategories)
                    .HasForeignKey(c => c.ModifiedMemberId);
            });
        }
    }
}
