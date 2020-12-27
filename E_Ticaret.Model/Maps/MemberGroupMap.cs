using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class MemberGroupMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberGroup>(entity =>
            {
                entity.HasExtended();

                entity.Property(m => m.Name).HasMaxLength(255).IsRequired();
                entity.Property(m => m.AllowedPaymentGateWays).HasMaxLength(512).IsRequired();
                entity.Property(m => m.PriceIndex).IsRequired();

                entity
                    .HasOne(m => m.CreatedMemberGroup)
                    .WithMany(m => m.CreatedMemberGroups)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberGroup)
                    .WithMany(m => m.ModifiedMemberGroups)
                    .HasForeignKey(m => m.ModifiedMemberId);

            });
        }
    }
}
