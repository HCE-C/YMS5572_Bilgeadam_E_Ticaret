using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class CartMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasExtended();

                entity.Property(c => c.SessionId).HasMaxLength(255).IsRequired();

                entity
                    .HasOne(c => c.ChosenPromotion)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(c => c.PromotionId);

                entity
                    .HasOne(c => c.Member)
                    .WithOne(m => m.Cart)
                    .HasForeignKey<Cart>(c => c.MemberId);

                entity
                    .HasOne(c => c.ChoosenToken)
                    .WithMany(t => t.Carts)
                    .HasForeignKey(c => c.ShopTokenId);

                entity
                   .HasOne(c => c.CreatedMemberCart)
                   .WithMany(m => m.CreatedMemberCarts)
                   .HasForeignKey(c => c.CreatedMemberId);

                entity
                    .HasOne(c => c.CreatedMemberCart)
                    .WithMany(m => m.CreatedMemberCarts)
                    .HasForeignKey(c => c.ModifiedMemberId);
            });
        }
    }
}
