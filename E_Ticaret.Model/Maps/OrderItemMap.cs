using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Model.Maps
{
    public class OrderItemMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasExtended();

                entity.Property(o => o.ProductName).HasMaxLength(255).IsRequired();
                entity.Property(o => o.ProductSku).HasMaxLength(255).IsRequired();
                entity.Property(o => o.ProductBarcode).HasMaxLength(255);
                entity.Property(o => o.ProductPrice).IsRequired();
                entity.Property(o => o.ProductQuantity).IsRequired();
                entity.Property(o => o.ProductTax).IsRequired();
                entity.Property(o => o.ProductDiscount).IsRequired();
                entity.Property(o => o.ProductMoneyOrderDiscount).IsRequired();
                entity.Property(o => o.ProductWeight).IsRequired();
                entity.Property(o => o.ProductStockTypeLabel).IsRequired();
                entity.Property(o => o.Discount).IsRequired();

                entity
                    .HasOne(oi => oi.Order)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(oi => oi.OrderId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity
                    .HasOne(oi => oi.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(oi => oi.ProductId);

                entity
                    .HasOne(oi => oi.OrderItemSubscription)
                    .WithMany(os => os.OrderItems)
                    .HasForeignKey(oi => oi.OrderItemSubscriptionId);

                entity
                .HasOne(m => m.CreatedMemberOrderItem)
                .WithMany(m => m.CreatedMemberOrderItems)
                .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberOrderItem)
                    .WithMany(m => m.ModifiedMemberOrderItems)
                    .HasForeignKey(m => m.ModifiedMemberId);
            });
        }
    }
}
