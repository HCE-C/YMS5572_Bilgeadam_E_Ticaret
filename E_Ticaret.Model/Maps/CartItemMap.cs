using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class CartItemMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasExtended();

                entity.Property(c => c.Quantity).IsRequired();

                entity
                    .HasOne(c => c.Category)
                    .WithMany(c => c.CartItems)
                    .HasForeignKey(c => c.CategoryId);

                entity
                    .HasOne(c => c.Cart)
                    .WithMany(c => c.CartItems)
                    .HasForeignKey(c => c.CartId);

                entity
                    .HasOne(c => c.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(c => c.ProductId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity
                    .HasOne(c => c.CreatedMemberCartItem)
                    .WithMany(m => m.CreatedMemberCartItems)
                    .HasForeignKey(c => c.CreatedMemberId);

                entity
                    .HasOne(c => c.ModifiedMemberCartItem)
                    .WithMany(m => m.ModifiedMemberCartItems)
                    .HasForeignKey(c => c.ModifiedMemberId);

            });
        }
    }
}
