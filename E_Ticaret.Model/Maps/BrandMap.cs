using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class BrandMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasExtended();

                entity.Property(m => m.Name).HasMaxLength(255).IsRequired();
                entity.Property(m => m.Slug).HasMaxLength(255);
                entity.Property(m => m.DistibutorCode).HasMaxLength(255);
                entity.Property(m => m.Distributor).HasMaxLength(255);
                entity.Property(m => m.ImageFilename).HasMaxLength(255);
                entity.Property(m => m.ShowcaseContent).HasMaxLength(65535);
                entity.Property(m => m.MetaKeyWords).HasMaxLength(65535);
                entity.Property(m => m.MetaDescription).HasMaxLength(65535);
                entity.Property(m => m.PageTitle).HasMaxLength(255);

                entity
                    .HasMany(b => b.Products)
                    .WithOne(p => p.Brand)
                    .HasForeignKey(p => p.BrandId);

                entity
                    .HasOne(b => b.CreatedMemberBrand)
                    .WithMany(m => m.CreatedMemberBrands)
                    .HasForeignKey(b => b.CreatedMemberId);

                entity
                    .HasOne(b => b.ModifiedMemberBrand)
                    .WithMany(m => m.ModifiedMemberBrands)
                    .HasForeignKey(b => b.ModifiedMemberId);

            });
        }
    }
}
