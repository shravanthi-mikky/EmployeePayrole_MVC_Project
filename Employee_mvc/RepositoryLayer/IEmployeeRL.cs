using Employee_mvc.Models;
using System.Collections.Generic;

namespace Employee_mvc.RepositoryLayer
{
    public interface IEmployeeRL
    {
        EmployeeModel AddEmployee(EmployeeModel emp);
        bool DeleteBook(EmployeeIdModel employeeDeleteModel);
        List<EmployeeModel> GetAllEmployees();
        object Retrive_Employee_Details(EmployeeIdModel employeeIdModel);
        EmployeeModel UpdateBook(EmployeeModel emp);
    }
}