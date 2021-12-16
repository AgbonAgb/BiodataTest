using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using static BiodataTest.Controllers.Common.Enum;
//using AspNetCore.

namespace BiodataTest.Controllers
{
    public class ShoppingCartItemController :BaseController// Controller
    {
        private readonly IShoppingCartItem _shoppingCartItem;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ShoppingCartItemController(IShoppingCartItem shoppingCartItem, IHttpContextAccessor httpContextAccessor)
        {
            _shoppingCartItem = shoppingCartItem;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> CheckOut(int Id)
        {
           

            string empid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;//.
           // ShoppingCartItemViewModel SPC = new ShoppingCartItemViewModel();

            //spSPC.ShoppingCartTotal= "45000.00";

            var items = await _shoppingCartItem.getMyCartItems(empid);
           decimal ShoppingCartTotal = await _shoppingCartItem.GetShoppingCartTotal(empid);// decimal.Parse("25,00.00");

        //1 loop throught and set finalize to tue,
        //2. update application table employeer id
        //notify Admin and generate PO
        //Check awaiting ordeer and generate PO
           // SPC.EmployerId = empid;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            string empid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;//.


            var remove = await _shoppingCartItem.RemoveItem(Id);
            if(remove==true)
            {



                TempData["Message"] = "item removed from cart Successfull";

                dynamic transRef = TempData["Message"];

                Alert("success", transRef, NotificationType.success);/*as AlertMessage;*/
                return RedirectToAction("MyCart", "Career");
            }
            else
            {
                TempData["Message"] = "item could not be removed from cart";

                dynamic transRef = TempData["Message"];

                Alert("success", transRef, NotificationType.success);/*as AlertMessage;*/
                return RedirectToAction("MyCart", "Career");
            }
           
        }
    }
}
