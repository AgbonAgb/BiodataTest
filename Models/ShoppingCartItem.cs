using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId { get; set; }
        public int ApplicationId { get; set; }
        public int CategoryID { get; set; }
        public int CareerID { get; set; }
        public string CategoryName { get; set; }
        public string CareerName { get; set; }
        public string EmployerId { get; set; }
        public string FirstName { get; set; }     
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        public DateTime transDate { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ShoppingCartTotal { get; set; }
        public bool finalize { get; set; }
        //[NotMapped]
        public int yearsExpe { get; set; }
        [NotMapped]
        public IEnumerable<ShoppingCartItem> cartitems { get; set; }
        // public IEnumerable<Skills> AllSkills { get; set; }
    }
}
