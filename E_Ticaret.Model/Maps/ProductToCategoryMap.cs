using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;


namespace E_Ticaret.Model.Maps
{
    public class ProductToCategoryMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductToCategory>(entity =>
            {
                entity.HasExtended();

                entity
                    .HasOne(p => p.Product)
                    .WithMany(p => p.ProductToCategories)
                    .HasForeignKey(p => p.ProductId);

                entity
                    .HasOne(p => p.Category)
                    .WithMany(p => p.ProductToCategories)
                    .HasForeignKey(p => p.CategoryId);

                entity
                    .HasOne(m => m.CreatedMemberProductToCategory)
                    .WithMany(m => m.CreatedMemberProductToCategories)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberProductToCategory)
                    .WithMany(m => m.ModifiedMemberProductToCategories)
                    .HasForeignKey(m => m.ModifiedMemberId);
            });
        }
    }
}
