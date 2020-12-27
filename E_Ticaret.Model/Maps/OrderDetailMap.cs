using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    class OrderDetailMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasExtended();

                entity.Property(o => o.VarKey).HasMaxLength(255).IsRequired();
                entity.Property(o => o.VarValue).HasMaxLength(65535);

                entity
                    .HasOne(od => od.Order)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(od => od.OrderId);

                entity
                    .HasOne(m => m.CreatedMemberOrderDetail)
                    .WithMany(m => m.CreatedMemberOrderDetails)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberOrderDetail)
                    .WithMany(m => m.ModifiedMemberOrderDetails)
                    .HasForeignKey(m => m.ModifiedMemberId);
            });
        }
    }
}
