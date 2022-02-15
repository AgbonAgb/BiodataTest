using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiodataTest.Models
{
    public class EditViewData
    {
        public int CareerID { get; set; }
        public string CareerName { get; set; }
        public string CareerDesc { get; set; }
        public bool isActive { get; set; }
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }
        public IList<Category> CategoryName1 { get; set; }
        public string CareerImageUrl { get; set; }
    }
}
