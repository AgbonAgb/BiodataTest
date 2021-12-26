using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using BiodataTest.Models;
using BiodataTest.Data;
using Microsoft.EntityFrameworkCore;

namespace BiodataTest.Services
{
    public class ShoppingCartItemServices : IShoppingCartItem
    {
        private readonly AppDbContext _appDbContext;

        public ShoppingCartItemServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<bool> AddToCart(ShoppingCartItem sci)
        {
            bool succ = false;
            decimal staffcost = await cost(sci.yearsExpe, sci.CareerID, sci.CategoryID);
            sci.Amount = staffcost;//        //  string costRang = await 

            if (staffcost != 0)
            {
                var chk = await _appDbContext.shoppingCartItem.Where(x => x.ApplicationId == sci.ApplicationId).ToListAsync();//.sh
                                                                                                                              // throw new NotImplementedException();
                if (chk.Count == 0)
                {

                    await _appDbContext.AddAsync(sci);
                    await _appDbContext.SaveChangesAsync();
                    succ = true;
                }
            }
            else
            { //alert cost not found
            }
           

            return succ;
        }

        private async Task<decimal> cost(int yearsExpe, int careerID, int categoryID)
        {
            var cost1 = await _appDbContext.yearsExperienceCost.Where(x=> x.CareerID== careerID && x.CategoryID== categoryID && (yearsExpe >=x.YearsLowerBound  && yearsExpe <= x.YearsHigherBound)).FirstOrDefaultAsync();

            decimal cost2 = cost1.amount;//= 0; ;// = decimal.Parse(cost1);

            return cost2;

        }



        public async Task<IEnumerable<ShoppingCartItem>> getMyCartItems(string Empid)
        {
            bool succ = false;
            //var chk = await _appDbContext.shoppingCartItem.Where(x => x.EmployerId == Empid && x.finalize==false).ToListAsync();//.sh

            var chk2 = await (from sh in _appDbContext.shoppingCartItem
                              join cat in _appDbContext.categorys on sh.CategoryID equals cat.CategoryID
                              join car in _appDbContext.careers on sh.CareerID equals car.CareerID
                              join app in _appDbContext.applications on sh.ApplicationId equals app.ApplicationId 
                              select new ShoppingCartItem
                              {
                                  ApplicationId = sh.ApplicationId,
                                  CategoryID = sh.CategoryID,
                                  CareerID = sh.CareerID,
                                  CategoryName = cat.CategoryName,
                                  CareerName = car.CareerName,
                                  EmployerId = sh.EmployerId,
                                  FirstName=sh.FirstName,
                                  LastName=sh.LastName,
                                  Amount=sh.Amount,
                                  transDate= sh.transDate,                                 
                                  finalize=sh.finalize,
                                  ShoppingCartItemId=sh.ShoppingCartItemId,
                                  yearsExpe=app.yearsExpe


                              }
                              ).Where(x => x.EmployerId == Empid && x.finalize == false).ToListAsync();//.ToListAsync();


            //use Join                                                                                                    // throw new NotImplementedException();
            //if (chk == null)
            //{

            //    await _appDbContext.AddAsync(sci);
            //    await _appDbContext.SaveChangesAsync();
            //    succ = true;
            //}

            return chk2;
        }
        public IEnumerable<ShoppingCartItem> getMyCartItems2(string Empid)
        {
            bool succ = false;
            //var chk = await _appDbContext.shoppingCartItem.Where(x => x.EmployerId == Empid && x.finalize==false).ToListAsync();//.sh

            var chk2 =  (from sh in _appDbContext.shoppingCartItem
                              join cat in _appDbContext.categorys on sh.CategoryID equals cat.CategoryID
                              join car in _appDbContext.careers on sh.CareerID equals car.CareerID
                              join app in _appDbContext.applications on sh.ApplicationId equals app.ApplicationId
                              select new ShoppingCartItem
                              {
                                  ApplicationId = sh.ApplicationId,
                                  CategoryID = sh.CategoryID,
                                  CareerID = sh.CareerID,
                                  CategoryName = cat.CategoryName,
                                  CareerName = car.CareerName,
                                  EmployerId = sh.EmployerId,
                                  FirstName = sh.FirstName,
                                  LastName = sh.LastName,
                                  Amount = sh.Amount,
                                  transDate = sh.transDate,
                                  finalize = sh.finalize,
                                  ShoppingCartItemId = sh.ShoppingCartItemId,
                                  yearsExpe = app.yearsExpe


                              }
                              ).Where(x => x.EmployerId == Empid && x.finalize == false).ToList();//.ToListAsync();


            //use Join                                                                                                    // throw new NotImplementedException();
            //if (chk == null)
            //{

            //    await _appDbContext.AddAsync(sci);
            //    await _appDbContext.SaveChangesAsync();
            //    succ = true;
            //}

            return chk2;
        }
        public async Task<decimal> GetShoppingCartTotal(string Empid)
        {
            var total = _appDbContext.shoppingCartItem.Where(c => c.EmployerId == Empid && c.finalize == false)
                .Select(c => c.Amount).Sum();
            return total;
        }
        public decimal GetShoppingCartTotal2(string Empid)
        {
            var total = _appDbContext.shoppingCartItem.Where(c => c.EmployerId == Empid && c.finalize == false)
                .Select(c => c.Amount).Sum();
            return total;
        }
        //int ShoppingitemQty(string Empid);
        public int ShoppingitemQty(string Empid)
        {
            var Qty = _appDbContext.shoppingCartItem.Where(c => c.EmployerId == Empid && c.finalize == false).Count();
                //.Select(c => c.Amount).Sum();
            return Qty;
        }
        public async Task<bool> RemoveItem(int Id)
        {
            bool succ = false;
            //find with shopingcartitemid
            var chk = await _appDbContext.shoppingCartItem.FindAsync(Id);//.Where(x => x.EmployerId == Empid && x.finalize == false).ToListAsync();//.sh
                                                                                                                                  // throw new NotImplementedException();
            if (chk != null)
            {

                 _appDbContext.Remove(chk);
                await _appDbContext.SaveChangesAsync();
                succ = true;
            }

            return succ;
            
        }
    }
}
