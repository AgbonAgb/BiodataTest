using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BiodataTest.Models
{
    public class PurchaseOrderDetails
    {
        [Key]
        public int poOrderDetailsId { get; set; }
        public int poId { get; set; }
        public string itemCategory { get; set; }
        public string item { get; set; }
        public string itemDesc { get; set; }
        public int Qty { get; set; }
        public decimal unitPrice { get; set; }
        public decimal totalPrice { get; set; }

    }
}
