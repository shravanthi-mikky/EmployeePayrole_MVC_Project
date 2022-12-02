using Employee_mvc.Models;
using System.Collections.Generic;

namespace Employee_mvc.RepositoryLayer
{
    public interface IEmployeeRL
    {
        EmployeeModel AddEmployee(EmployeeModel emp);
        List<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetEmployeeData(int? id);
        public EmployeeModel UpdateEmployee(EmployeeModel emp);
        public void DeleteEmployee(int? id);
    }
}