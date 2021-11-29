using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Models;

namespace BiodataTest.Interfaces
{
    public interface IPurchaseOrder
    {
        Task<bool> CreatePurchaseOrder(PurchaseOrder porder);
        Task<PurchaseOrder> getOrderDetails(int Id);
        Task <IEnumerable<PurchaseOrder>> getAllOrders();
    }
}
