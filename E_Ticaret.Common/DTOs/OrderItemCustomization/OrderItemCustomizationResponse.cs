using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Common.DTOs.OrderItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.OrderItemCustomization
{
    public class OrderItemCustomizationResponse : BaseDto
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
        public OrderItemResponse OrderItem { get; set; }
    }
}
