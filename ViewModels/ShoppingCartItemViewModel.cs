using BiodataTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.ViewModels
{
    public class ShoppingCartItemViewModel
    { [Key]

        public string EmployerId { get; set; }
        [NotMapped]
        public IEnumerable<ShoppingCartItem> Cartitems { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        //public IEnumerable<Skills> AllSkills { get; set; }
    }
}
