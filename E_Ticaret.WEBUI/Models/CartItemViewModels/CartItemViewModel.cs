using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.Models.CartItemViewModels
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public int CategoryId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }
}
