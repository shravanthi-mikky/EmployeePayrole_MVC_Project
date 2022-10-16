using Employee_mvc.Models;
using Employee_mvc.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Employee_mvc.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRL employeeRL;

        public EmployeeController(IEmployeeRL employeeRL){

            this.employeeRL = employeeRL;
            }
        public IActionResult ListOfEmployee()
        {
            List<EmployeeModel> emplist = new List<EmployeeModel>();
            emplist = employeeRL.GetAllEmployees().ToList();
            return View(emplist);
        }

        [HttpGet]
        public IActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmp([Bind] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                employeeRL.AddEmployee(employee);
                return RedirectToAction("ListOfEmployee");
            }
            return View(employee);
        }
    }
}
