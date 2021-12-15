using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
//using AspNetCore.

namespace BiodataTest.Controllers
{
    public class ShoppingCartItemController : Controller
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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            string empid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;//.


            var remove = await _shoppingCartItem.RemoveItem(Id);
            if(remove==true)
            {
                return RedirectToAction("MyCart", "Career");
            }
            else
            {
                return RedirectToAction("MyCart", "Career");
            }
           
        }
    }
}
