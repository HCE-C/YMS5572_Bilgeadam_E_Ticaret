using E_Ticaret.Core.Entity;

namespace E_Ticaret.Model.Entities
{
    //Sipariş Kalemi Özelleştirme
    public class OrderItemCustomization : CoreEntity
    {
        public int ProductCustomizationGroupId { get; set; }
        public string ProductCustomizationGroupName { get; set; }
        public int ProductCustomizationGroupSortOrder { get; set; }
        public int ProductCustomizationFieldId { get; set; }
        public string ProductCustomizationFieldType { get; set; }
        public string ProductCustomizationFieldName { get; set; }
        public string ProductCustomizationFieldValue { get; set; }
        public int CartItemAttributeId { get; set; }

        public int OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; }

        public Member CreatedMemberOrderItemCustomization { get; set; }
        public Member ModifiedMemberOrderItemCustomization { get; set; }
    }
}