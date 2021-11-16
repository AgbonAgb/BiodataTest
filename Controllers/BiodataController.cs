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

        public async Task<IActionResult> existedBiodata()
        {

            var existing = await _bioData.GetexistingBiodata();

            return View(existing);
        }
        public IActionResult CreateBiodata()
        {
            BioDataViewModel Bid = new BioDataViewModel();


            return View(Bid);
        }

        //[FromBody] 
        //("CreateBiodata")
        //Biodata/CreateBiodata
        [HttpPost]
        public async Task<IActionResult> CreateBiodata(BioDataViewModel bioDataViewModel)
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
                //if sucess go to list page of existing
                //return View(bioDataViewModel);

                return RedirectToAction("existedBiodata");
            }
            else
            {
                return View(bioDataViewModel);
            }

        }
    }
}
