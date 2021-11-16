using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BiodataTest.ViewModels
{
    public class BioDataViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
       [Display(Name ="Staff Id")]
        public int StaffId { get; set; }
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name ")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
    }
}
