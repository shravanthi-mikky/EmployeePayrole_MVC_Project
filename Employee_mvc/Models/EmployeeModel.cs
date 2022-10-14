using System;

namespace Employee_mvc.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Profile { get; set; }
        public string Gender { get; set; }

        public string Department { get; set; }
        public string Salary { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class EmployeeIdModel
    {
        public int EmployeeId { get; set; }
    }
}
