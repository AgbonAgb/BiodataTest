using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int CareerID { get; set; }
        public string CategoryName { get; set; }
        public string CareerName { get; set; }
        [NotMapped]
        public IEnumerable<Skills> AllSkills { get; set; }
    }
}
