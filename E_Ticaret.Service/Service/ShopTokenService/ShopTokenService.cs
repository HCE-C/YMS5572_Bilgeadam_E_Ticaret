using E_Ticaret.Model.Context;
using E_Ticaret.Model.Entities;
using E_Ticaret.Service.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Service.Service.ShopTokenService
{
    public class ShopTokenService : BaseService<ShopToken>, IShopTokenService
    {
        public ShopTokenService(DataContext db)
             : base(db)
        {
        }
    }
}
