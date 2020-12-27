using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class OrderItemSubscriptionMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItemSubscription>(entity =>
            {
                entity.HasExtended();

                entity
                    .HasOne(m => m.CreatedMemberOrderItemSubscription)
                    .WithMany(m => m.CreatedMemberOrderItemSubscriptions)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberOrderItemSubscription)
                    .WithMany(m => m.ModifiedMemberOrderItemSubscriptions)
                    .HasForeignKey(m => m.ModifiedMemberId);

            });

        }
    }
}
