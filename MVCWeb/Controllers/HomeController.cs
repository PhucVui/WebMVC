using Microsoft.AspNetCore.Mvc;
using MVCWeb.Models;
using MVCWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWeb.Controllers
{
    public class HomeController : Controller    
    {
        private IEmployeeRepository employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            /*employeeRepository = new MockEmployeeRepository();*/
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(employeeRepository.Gets());
        }
      
        [HttpGet]
        public ViewResult Details(int? id)
        {
            
            var employee = employeeRepository.Get(id.Value);
            if(employee == null)
            {               
                return View("~/Views/Error/Error.cshtml",id.Value);
            }
            var detailViewModel = new HomeDetailsViewModel()
            {
                Employee = employeeRepository.Get(id??1),
                TitleName = "Ëmployee Detail"
            };

            return View(detailViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create (Employee model)
        {
            if(ModelState.IsValid)
            {
                var newEmp = employeeRepository.Create(model);
                return RedirectToAction("Details", new { id = newEmp.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {            
            var employee = employeeRepository.Get(id);
            if (employee == null)
            {
                return View("~/Views/Error/Error.cshtml", id);
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            if(employeeRepository.Edit(model) != null)
            {
                return RedirectToAction("Details", new {id = model.Id});
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if(employeeRepository.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
