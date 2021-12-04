using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Models
{
    public class StaffCost
    {
        //[Key]
        public int id { get; set; }
        //public int StaffId { get; set; }
        public decimal Cost { get; set; }
    }
}
