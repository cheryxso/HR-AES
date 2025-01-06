using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security.Identity;
using CCL.Security;
using DAL.Entities;
using DAL.Repositories.UnitOfWork;
using BLL.Automapper;


namespace BLL.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<EmployeeDTO> GetEmployees(int departmentId)
        {
			var user = SecurityContext.GetUser();
			var userType = user.GetType();
			if (userType != typeof(Admin) && userType != typeof(HREmployee) && userType != typeof(HRSupervisor))
				throw new MethodAccessException();

			var employees = _unitOfWork.Employees.GetAll().Where(e => e.DepartmentId == departmentId).ToList();

			var mapperProfile = new EmployeeMapperProfile();
			var conf = new MapperConfiguration(cfg => cfg.AddProfile(mapperProfile));
			var mapper = new Mapper(conf);

            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(employees);
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
			var user = SecurityContext.GetUser();
			var userType = user.GetType();
			if (userType != typeof(Admin) && userType != typeof(HREmployee) && userType != typeof(HRSupervisor))
				throw new MethodAccessException();

			var employee = _unitOfWork.Employees.Get(id);

			var mapperProfile = new EmployeeMapperProfile();
			var conf = new MapperConfiguration(cfg => cfg.AddProfile(mapperProfile));
			var mapper = new Mapper(conf);

			return mapper.Map<Employee, EmployeeDTO>(employee);
        }
    }
}
