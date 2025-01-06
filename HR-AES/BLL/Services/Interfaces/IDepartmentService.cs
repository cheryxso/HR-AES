using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDTO> GetDepartments();
        DepartmentDTO GetDepartmentById(int id);
    }
}
