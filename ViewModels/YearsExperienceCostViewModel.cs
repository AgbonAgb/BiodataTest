using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.ViewModels
{
    public class YearsExperienceCostViewModel
    {

        [Key]
        public int CostId { get; set; }
        [Display(Name = "Years Lower Bound")]
        public int YearsLowerBound { get; set; }
        [Display(Name = "Years Higher Bound")]
        public int YearsHigherBound { get; set; }
        public decimal amount { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CareerID { get; set; }
        public string CareerName { get; set; }
    }
}
