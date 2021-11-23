using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BiodataTest.Models
{
    public class Dept
    {
        [Key]
        public int DeptId { get; set; }
        public string DepartmentName { get; set; }
    }
}
