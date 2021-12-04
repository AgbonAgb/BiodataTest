using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BiodataTest.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BiodataTest.ViewModels
{
    public class BioDataViewModel
    {
        [Key]
        public int StaffId { get; set; }
        public int StaffNumber { get; set; }
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name ")]
        public string LastName { get; set; }
        [BindProperty, MaxLength(50)]
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
        [BindNever]
        public string Location { get; set; }
        public int DeptId { get; set; }
        public string Department { get; set; }
        [BindNever]
        public List<StaffCost> staffCost { get; set; }
        public bool approved { get; set; }
        public bool available { get; set; }
        //public List<SelectListItem> Referer { get; set; }

    }
}
