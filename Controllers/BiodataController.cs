using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using BiodataTest.ViewModels;
using BiodataTest.Models;

namespace BiodataTest.Controllers
{
    public class BiodataController : Controller
    {
        private IBiodata _bioData;
        public BiodataController(IBiodata bioData)
        {
            _bioData = bioData;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("CreateBiodata")]
        public async Task<IActionResult> CreateBiodata([FromBody] BioDataViewModel bioDataViewModel)
        {

            BioData bio = new BioData();

            bio.StaffId = bioDataViewModel.StaffId;
            bio.FirstName = bioDataViewModel.FirstName;
            bio.LastName = bioDataViewModel.LastName;
            bio.Address = bioDataViewModel.Address;
            bio.DOB = bioDataViewModel.DOB;

            var newbio = await _bioData.CreateBiodata(bio);
            if(newbio)
            {
                return View(bioDataViewModel);
            }
            else
            {
                return View(bioDataViewModel);
            }

        }
    }
}
