using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Data;
using BiodataTest.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using BiodataTest.ViewModels;

namespace BiodataTest.Components
{
    public class ShoppingCartSummary:ViewComponent
    {

       // private readonly ShoppingCart _shoppingCart;
        private readonly AppDbContext _appDbContext;
        private readonly IShoppingCartItem _shoppingCartItem;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCartSummary(AppDbContext appDbContext, IShoppingCartItem shoppingCartItem, IHttpContextAccessor httpContextAccessor)
        {
           // _shoppingCart = shoppingCart;
            _appDbContext = appDbContext;
            _shoppingCartItem = shoppingCartItem;
                _httpContextAccessor = httpContextAccessor;
        }

        public  IViewComponentResult Invoke()
        {
            //var items = _shoppingCart.GetShoppingCartItems();
            //_shoppingCart.ShoppingCartItems = items;
            string empid = "";
            ShoppingCartItemViewModel SPC = new ShoppingCartItemViewModel();
            if (HttpContext.User.Identity.Name != null)
            {
                empid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;//.

                //  var items = _shoppingCartItem.getMyCartItems(empid);


                ////ViewModels.ShoppingCartItemViewModel sc = new ViewModels.ShoppingCartItemViewModel()
                ////    sc.Cartitems2 = items;
                ////    sc.ShoppingCartTotal= _shoppingCartItem.getMyCartItems(empid);

               

                //spSPC.ShoppingCartTotal= "45000.00";

                SPC.Cartitems = _shoppingCartItem.getMyCartItems2(empid);
                SPC.ShoppingCartTotal = _shoppingCartItem.GetShoppingCartTotal2(empid);// decimal.Parse("25,00.00");
                SPC.ShoppingitemQty = _shoppingCartItem.ShoppingitemQty(empid);
                SPC.EmployerId = empid;
            }

           



            //var shoppingCartViewModel1 = items new shoppingCartViewModel
            //{
            //    ShoppingCart = _shoppingCart,
            //    ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            //}

            //var items = await _shoppingCartItem.getMyCartItems(empid);
            //decimal ShoppingCartTotal = await _shoppingCartItem.GetShoppingCartTotal(empid);/


            // _appDbContext.shoppingCartItem..GetShoppingCartItems();
            // _shoppingCartItem..ShoppingCartItems = items;

            //List<shoppingCartViewModel> list2 = existing.AsEnumerable()
            //             .Select(o => new shoppingCartViewModel
            //             {
            //                 RefererId = o.StaffId,
            //                 Referer = o.FirstName

            //             }).ToList();


            //var shoppingCartViewModel1  = items new shoppingCartViewModel
            //{
            //    ShoppingCart = _shoppingCart,
            //    ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            //};
            //return View(shoppingCartViewModel);
            return View(SPC);
        }
    }
}

