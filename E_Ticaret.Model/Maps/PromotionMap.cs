using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;


namespace E_Ticaret.Model.Maps
{
    public class PromotionMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.HasExtended();

                entity.Property(p => p.Label).HasMaxLength(255);

                entity
                    .HasOne(m => m.CreatedMemberPromotion)
                    .WithMany(m => m.CreatedMemberPromotions)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberPromotion)
                    .WithMany(m => m.ModifiedMemberPromotions)
                    .HasForeignKey(m => m.ModifiedMemberId);
            });
        }
    }
}
