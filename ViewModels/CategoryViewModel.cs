using BiodataTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int CategoryID { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Category Code")]
        public string CategoryCode { get; set; }
        [NotMapped]
        public IEnumerable<Category> AllCategories { get; set; }

        //public CategoryViewModel(string test)
        //{
        //    // ...
        //}
        //public CategoryViewModel()
        //{
        //    // ...
        //}
    }

}
