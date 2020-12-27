using E_Ticaret.Core.Entity;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Sipariş Kalemi Aboneliği
    public class OrderItemSubscription : CoreEntity
    {
        public OrderItemSubscription()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public ICollection<OrderItem> OrderItems { get; set; }

        public Member CreatedMemberOrderItemSubscription { get; set; }
        public Member ModifiedMemberOrderItemSubscription { get; set; }
    }
}