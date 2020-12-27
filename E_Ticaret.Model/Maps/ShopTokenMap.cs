using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class ShopTokenMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopToken>(entity =>
            {
                entity.HasExtended();

                entity.Property(s => s.Code).HasMaxLength(255);

                entity
                    .HasOne(m => m.CreatedMemberShopToken)
                    .WithMany(m => m.CreatedMemberShopTokens)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberShopToken)
                    .WithMany(m => m.ModifiedMemberShopTokens)
                    .HasForeignKey(m => m.ModifiedMemberId);
            });
        }
    }
}
