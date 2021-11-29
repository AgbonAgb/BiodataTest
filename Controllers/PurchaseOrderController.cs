using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using BiodataTest.Models;

namespace BiodataTest.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly IPurchaseOrder _purchaseOrder;

        public PurchaseOrderController(IPurchaseOrder purchaseOrder)
        {
            _purchaseOrder = purchaseOrder;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> createPurchaseOrder()
        {
            PurchaseOrder Pd = new PurchaseOrder();



            return View(Pd);
        }
        [HttpPost]
        public async Task<IActionResult> createPurchaseOrder(PurchaseOrder Pd)
        {
           



            return View(Pd);
        }
    }
}
