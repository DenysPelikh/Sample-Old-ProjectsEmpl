using System;
using System.Net.Mime;
using System.Web.Mvc;
using Empl.BL.Interfaces;
using Empl.ViewModels;

namespace Empl.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private const int DefaultPageSize = 5;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult Index(int page = 1, string filter = "All")
        {
            IndexViewModel model = _employeeService.GetFilteredEmployees(filter, DefaultPageSize, page);

            model.PageSize = DefaultPageSize;
            model.PageNumber = page;
            model.Filter = filter;

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            EmployeeViewModel employee = _employeeService.GetEmployee(id);
            return View(employee);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.CreateEmployee(employee);
                TempData["message"] = string.Format("Employee \"{0}\" has been added", employee.Name);
                return RedirectToAction("Index");
            }

            TempData["message"] = string.Format("Employee \"{0}\" not added", employee.Name);

            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            EmployeeViewModel employee = _employeeService.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.EditEmployee(employee);
                TempData["message"] = string.Format("Employee \"{0}\" has been update", employee.Name);
                return RedirectToAction("Index");
            }

            TempData["message"] = string.Format("Employee \"{0}\" not update", employee.Name);

            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            TempData["message"] = string.Format("Remove employee");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Generate()
        {
            _employeeService.GenerateReport();

            var fileName = string.Format("{0}{1}\\{2}.txt", AppDomain.CurrentDomain.BaseDirectory, "App_Data\\EmployeeFiles", "Report");
            return File(fileName, MediaTypeNames.Application.Octet, "Report.txt");
        }
    }
}
