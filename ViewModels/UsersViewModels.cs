using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.ViewModels
{
    public class UsersViewModels
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
       // public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //IList<string> RoleName { get; set; }
        public string RoleName { get; set; }
       public string RoleId { get; set; }
        //public List<string> RoleId { get; set; }
        public string SearchTerm { get; set; }
        //[NotMapped]
        // public int RolesId { get; set; }
        //public MultiSelectList RoleId { get; set; }
    }
}
