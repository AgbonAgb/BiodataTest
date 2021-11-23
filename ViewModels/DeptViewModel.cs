using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BiodataTest.ViewModels
{
    public class DeptViewModel
    {
        [Key]
        public int DeptId { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
}
