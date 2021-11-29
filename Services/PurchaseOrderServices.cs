using BiodataTest.Data;
using BiodataTest.Interfaces;
using BiodataTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Services
{

    public class PurchaseOrderServices : IPurchaseOrder
    {
        private readonly AppDbContext _appDbContext;
        //public readonly 
        public PurchaseOrderServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CreatePurchaseOrder(PurchaseOrder porder)
        {
            bool succ = false;

            var Chk = await _appDbContext.purchaseOrder.FindAsync(porder.PoId);
            if(Chk == null)
            {

               // porder.PoDetails = new List<PurchaseOrderDetails>();
                //adding the order with its details

                foreach (var orderDetails in porder.PoDetails)
                {
                    var orderDetail = new PurchaseOrderDetails
                    {
                        itemCategory = orderDetails.itemCategory,
                        item = orderDetails.item,
                        itemDesc = orderDetails.itemDesc,
                        Qty=orderDetails.Qty,
                        unitPrice=orderDetails.unitPrice,
                        totalPrice=orderDetails.totalPrice
                    };

                    porder.PoDetails.Add(orderDetail);
                  //await _appDbContext.purchaseOrderDetails.AddAsync(orderDetail);
                }

                await _appDbContext.AddAsync(porder);
                await _appDbContext.SaveChangesAsync();

                succ = true;
            }

            return succ;
        }

        public async Task<IEnumerable<PurchaseOrder>> getAllOrders()
        {
            var allPO = await _appDbContext.purchaseOrder.Include(s => s.PoDetails).ToListAsync();

            return allPO;
        }

        public async Task<PurchaseOrder> getOrderDetails(int Id)
        {
            var allPO = await _appDbContext.purchaseOrder.Include(sh => sh.PoDetails).Where(s => s.PoId == Id).FirstOrDefaultAsync();



            return allPO;
        }
    }
}
