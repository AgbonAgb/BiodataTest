using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace BiodataTest.Models
{
    public class BioData
    {
        [Key]
       //[BindNever]
        public int StaffId { get; set; }
        public int StaffNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; } 
        //public list<StaffCost> staffCost { get; set; }
        public List<StaffCost> staffCost { get; set; }
        public int DeptId { get; set; }
        public bool approved { get; set; }
        public bool available { get; set; }
        public string CvPath { get; set; }
        //public string Department { get; set; }
        //public string Referer { get; set; }


    }
}
