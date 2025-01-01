using System.Collections.Generic;

namespace DAL.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public DepartmentName Name { get; set; } 
        public string Description { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }

    public enum DepartmentName
    {
        HR,
        IT,
        Safety,
        Maintenance,
        Engineering,
        Security
    }
}
