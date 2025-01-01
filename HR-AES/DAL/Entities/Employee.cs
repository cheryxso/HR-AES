using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; } 
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public IEnumerable<Request> Requests { get; set; }
    }

    public enum Position
    {
        HR_Leader,
        HR_Employee,
        IT_Manager,
        Developer,
        Safety_Engineer,
        Engineer,
        Security_Manager,
        Security_Officer
    }
}
