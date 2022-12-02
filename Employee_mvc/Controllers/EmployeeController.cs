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

        //Details Api

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = employeeRL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        //Edit Api

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = employeeRL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        
        public IActionResult Edit(int id, [Bind] EmployeeModel employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeRL.UpdateEmployee(employee);
                return RedirectToAction("ListOfEmployee");
            }
            return View(employee);
        }

        //Delete API

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = employeeRL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            employeeRL.DeleteEmployee(id);
            return RedirectToAction("ListOfEmployee");
        }

    }
}
