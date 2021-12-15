using BiodataTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Interfaces
{
    public interface IShoppingCartItem
    {
        Task<bool> AddToCart(ShoppingCartItem sci);
        Task<bool> RemoveItem(int Id);
        Task<IEnumerable<ShoppingCartItem>> getMyCartItems(string Empid);//where finilize is 0
        Task<decimal> GetShoppingCartTotal(string Empid);
    }
}
