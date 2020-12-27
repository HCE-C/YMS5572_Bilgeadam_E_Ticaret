using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class ProductToCountDownMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductToCountDown>(entity =>
            {
                entity
                    .HasOne(pc => pc.Product)
                    .WithOne(p => p.CountDown)
                    .HasForeignKey<ProductToCountDown>(pc => pc.ProductId);

                entity
                   .HasOne(c => c.CreatedMemberProductToCountDown)
                   .WithMany(m => m.CreatedMemberProductToCountDowns)
                   .HasForeignKey(c => c.CreatedMemberId);

                entity
                    .HasOne(c => c.ModifiedMemberProductToCountDown)
                    .WithMany(m => m.ModifiedMemberProductToCountDowns)
                    .HasForeignKey(c => c.ModifiedMemberId);
            });
        }
    }
}
