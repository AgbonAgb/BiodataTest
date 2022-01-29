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
        IEnumerable<ShoppingCartItem> getMyCartItems2(string Empid);
        decimal GetShoppingCartTotal2(string Empid);
        int ShoppingitemQty(string Empid);
        Task<bool> AddPaymentTrans(Payments pay);
        Task<string> UpdatePaymentTrans(string transref);
        Task<bool> UpdateShoppingCarttable(string transref, string empid);


    }
}
