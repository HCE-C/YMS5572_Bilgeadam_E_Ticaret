using E_Ticaret.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.ProductToCategory
{
    public class ProductToCategoryResponse : BaseDto
    {
        public int SortOrder { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
