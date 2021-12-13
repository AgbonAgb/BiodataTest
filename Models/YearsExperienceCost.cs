using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Models
{
    public class YearsExperienceCost
    {
        [Key]
        public int CostId { get; set; }
        public int YearsLowerBound { get; set; }
        public int YearsHigherBound { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; }
        public int CategoryID { get; set; }        
        public string CategoryName { get; set; }
        public int CareerID { get; set; }
        public string CareerName { get; set; }
    }
}
