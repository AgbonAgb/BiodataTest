using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiodataTest.ViewModels
{
    public class BioDataViewModel
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        [Display(Name ="Staff Id")]
        public int StaffId { get; set; }
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name ")]
        public string LastName { get; set; }
        [BindProperty, MaxLength(10)]
        public string Address { get; set; }
        [Display(Name = "Date of Birth")]
        //[DataType(DataType.Date)]
       //[BindProperty]
       //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        //public DateTime? DOB { get; set; }
        public string Referer { get; set; }
        public int RefererId { get; set; }
        public int LocationId { get; set; }
        public List<SelectListItem> Location { get; set; }
        public int DeptId { get; set; }
        public string Department { get; set; }
        //public List<SelectListItem> Referer { get; set; }

    }
}
