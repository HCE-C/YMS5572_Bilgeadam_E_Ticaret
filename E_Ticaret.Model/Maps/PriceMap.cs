using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class PriceMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasExtended();
                entity.Property(p => p.Value).IsRequired();
                entity.Property(p => p.Type).IsRequired();

                entity
                    .HasOne(pp => pp.Product)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(pp => pp.ProductId);

                entity
                    .HasOne(m => m.CreatedMemberPrice)
                    .WithMany(m => m.CreatedMemberPrices)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberPrice)
                    .WithMany(m => m.ModifiedMemberPrices)
                    .HasForeignKey(m => m.ModifiedMemberId);
            });
        }
    }
}
