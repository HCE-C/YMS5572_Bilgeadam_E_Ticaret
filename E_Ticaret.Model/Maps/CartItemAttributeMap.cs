using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class CartItemAttributeMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItemAttribute>(entity =>
            {
                entity.HasExtended();

                entity.Property(c => c.Name).HasMaxLength(255);

                entity
                    .HasOne(c => c.CartItem)
                    .WithMany(c => c.Attributes)
                    .HasForeignKey(c => c.CartItemId);

                entity
                   .HasOne(c => c.CreatedMemberCartItemAttribute)
                   .WithMany(m => m.CreatedMemberCartItemAttributes)
                   .HasForeignKey(c => c.CreatedMemberId);

                entity
                    .HasOne(c => c.ModifiedMemberCartItemAttribute)
                    .WithMany(m => m.ModifiedMemberCartItemAttributes)
                    .HasForeignKey(c => c.ModifiedMemberId);
            });
        }
    }
}
