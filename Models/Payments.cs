using System;
using System.ComponentModel.DataAnnotations;

namespace BiodataTest.Models
{
    public class Payments
    {
        [Key]
        public int Id { get; set; }
        public string EmployerId { get; set; }
        public string TransRef { get; set; }
        public string CybRef { get; set; }
        public DateTime TransDate { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public int Qty { get; set; }

    }
}
