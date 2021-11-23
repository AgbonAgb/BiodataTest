using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using BiodataTest.Models;
using BiodataTest.ViewModels;
using AutoMapper;

namespace BiodataTest.Controllers
{
    public class DeptController : Controller
    {
        private readonly IDept _idept;
        private readonly IMapper _mapper;
        public DeptController(IDept idept, IMapper mapper)
        {
            _idept = idept;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CreateDept()
        {
            DeptViewModel deptViewModel = new DeptViewModel();



            return View(deptViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> CreateDept(DeptViewModel deptViewModel)
        {
            var mapped = _mapper.Map<Dept>(deptViewModel);

            var created = await _idept.CreateDept(mapped);
            if(created)
            {

                return RedirectToAction("ExistingDept");
            }
            else
            {
                return RedirectToAction("deptViewModel");
            }
            

        }

        public async Task<IActionResult> ExistingDept()
        {
            var alldept = await _idept.GetDepts();

            return View(alldept);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
