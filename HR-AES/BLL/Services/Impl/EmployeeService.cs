using System;
using System.Collections.Generic;
using BLL.DTO;
using DAL.Repositories.UnitOfWork;


namespace BLL.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private int pageSize = 10;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<EmployeeDTO> GetEmployees(int departmentId, int page)
        {
            var employees = _unitOfWork.Employees.GetAllByDepartment(departmentId, page, pageSize);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>())
                .CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(employees);
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            var employee = _unitOfWork.Employees.GetById(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>())
                .CreateMapper();
            return mapper.Map<Employee, EmployeeDTO>(employee);
        }
    }
}
