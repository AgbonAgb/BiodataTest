using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.ViewModels
{
    public class RoleViewModel
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        //[NotMapped]
        //public IEnumerable<int> RoleIdd { get; set; }
        //public MultiSelectList Rolenammes { get; set; }
    }
}
