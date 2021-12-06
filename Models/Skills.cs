using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Models
{
    public class Skills
    {
       [Key]
        public int skillId { get; set; }
        [Display(Name ="Skill Code")]
        public string skillCode { get; set; }
        [Display(Name = "Skill Description")]
        [BindProperty, MaxLength(500)]
        public string skillDescription { get; set; }
        public int CategoryID { get; set; }
    }
}
