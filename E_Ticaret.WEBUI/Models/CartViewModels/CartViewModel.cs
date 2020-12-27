using E_Ticaret.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.Models.CartViewModels
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public Locked Locked { get; set; }
        public int PromotionId { get; set; }
        public int MemberId { get; set; }
        public int ShopTokenId { get; set; }
    }
}
