using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.ViewModels
{
    public class ApplicationViewModel
    {
        [Key]
        public int ApplicationId { get; set; }
        public int EmployerId { get; set; }
        public int CareerID { get; set; }
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name ")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Current Address")]
        public string Address { get; set; }
        [NotMapped]
        public IFormFile CVfile { get; set; }
        public string CvPath { get; set; }
        public bool approved { get; set; }
        public bool available { get; set; }
        public bool POprocessing { get; set; }
        public bool iSActive { get; set; }
        public bool rejected { get; set; }
        [Display(Name = "Years of Experience")]
        [Range(1, 100)]
        public int yearsExpe { get; set; }
        public DateTime TransDate { get; set; }
        public string CareerName { get; set; }
        public string CategoryName { get; set; }
    }
}
