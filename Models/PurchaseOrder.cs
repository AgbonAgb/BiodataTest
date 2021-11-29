using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BiodataTest.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int PoId { get; set; }
        public string PoNumber { get; set; }
        public string vendor { get; set; }
        public int DeliveryDays { get; set; }
        public string TermsofPayment { get; set; }
        public string ValidityOffer { get; set; }
        public string Warranty { get; set; }
       public List<PurchaseOrderDetails> PoDetails { get; set; }
    }
}
