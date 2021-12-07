using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.ViewModels
{
    public class CareerViewModel
    {
        [Key]
        public int CareerID { get; set; }
        [Display(Name = "Career Name")]
        public string CareerName { get; set; }
        [Display(Name = "Career Description")]
        public string CareerDesc { get; set; }
        public string CareerImageUrl { get; set; }
        [Display(Name = "Career Category")]
        public int CategoryID { get; set; }
        public string skills { get; set; }
        public int skillId { get; set; }
        [Required(ErrorMessage = "Please choose CV to upload")]
        [NotMapped]
        public IFormFile CareerImgfile { get; set; }
        public bool isActive { get; set; }
        public string CategoryName { get; set; }
        




    }
}
