﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Category Code")]
        public string CategoryCode { get; set; }
    }
}
