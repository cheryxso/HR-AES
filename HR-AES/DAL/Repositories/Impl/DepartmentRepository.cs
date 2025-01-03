using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories.Impl
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext context) : base(context) { }

        public Department GetDepartmentWithEmployees(int departmentId)
        {
            return _set.Include(d => d.Employees).FirstOrDefault(d => d.DepartmentId == departmentId);
        }
    }
}

