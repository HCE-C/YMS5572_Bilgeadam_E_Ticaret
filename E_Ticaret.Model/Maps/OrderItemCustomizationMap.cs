using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    class OrderItemCustomizationMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItemCustomization>(entity =>
            {
                entity.HasExtended();

                entity.Property(o => o.ProductCustomizationGroupName).HasMaxLength(255);
                entity.Property(o => o.ProductCustomizationFieldType).HasMaxLength(64);
                entity.Property(o => o.ProductCustomizationFieldName).HasMaxLength(255);
                entity.Property(o => o.ProductCustomizationFieldValue).HasMaxLength(65535);

                entity
                    .HasOne(oic => oic.OrderItem)
                    .WithMany(oi => oi.OrderItemCustomizations)
                    .HasForeignKey(oic => oic.OrderItemId);

                entity
                    .HasOne(m => m.CreatedMemberOrderItemCustomization)
                    .WithMany(m => m.CreatedMemberOrderItemCustomizations)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberOrderItemCustomization)
                    .WithMany(m => m.ModifiedMemberOrderItemCustomizations)
                    .HasForeignKey(m => m.ModifiedMemberId);
            });
        }
    }
}
