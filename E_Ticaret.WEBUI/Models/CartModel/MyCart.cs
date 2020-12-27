using E_Ticaret.WEBUI.Models.CartItemViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.Models.CartModel
{
    public class MyCart
    {
        private Dictionary<int, MasterVM> _cart = null;
        public MyCart()
        {
            _cart = new Dictionary<int, MasterVM>();
        }

        #region Sepet_Listele
        public List<MasterVM> CartItemList
        {
            get
            {
                return _cart.Values.ToList();
            }
        }
        #endregion

        #region Sepet_Ekle
        public void AddCart(MasterVM item)
        {
            if (!_cart.ContainsKey(item.ProductId))
                _cart.Add(item.ProductId, item);
            else
                _cart[item.ProductId].Quantity++;
            
        }
        #endregion

        #region Sepet_Arttır
        public void IncreaseCart(int id) => _cart[id].Quantity++;
        #endregion

        #region Sepet_Azalt
        public void DecreaseCart(int id)
        {
            if (_cart[id].Quantity <= 0)
            {
                _cart.Remove(id);
            }
            _cart[id].Quantity--;
        }
        #endregion

        #region Sepet_Sil
        public void RemoveCart(int id) => _cart.Remove(id);
        #endregion
    }
}
