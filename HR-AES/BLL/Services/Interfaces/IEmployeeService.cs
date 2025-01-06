using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetEmployees(int departmentId, int page);
        EmployeeDTO GetEmployeeById(int id);
    }
}
