using BiodataTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.ViewModels
{
    public class ShoppingCartItemViewModelSumary
    {
        [Key]

        public string EmployerId { get; set; }
        [NotMapped]
        public ShoppingCartItem Cartitems { get; set; }
        //public IEnumerable<ShoppingCartItem> Cartitems { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
