using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories.Impl
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context) : base(context) { }

        public Employee GetEmployeeWithRequests(int employeeId)
        {
            return _set.Include(e => e.Requests).FirstOrDefault(e => e.EmployeeId == employeeId);
        }
    }
}
