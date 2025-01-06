using System;
using System.Collections.Generic;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Repositories.UnitOfWork;

namespace BLL.Services.Impl
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<DepartmentDTO> GetDepartments()
        {
            var user = SecurityContext.GetUser();
			var userType = user.GetType();
			if (userType != typeof(Admin) && userType != typeof(HREmployee) && userType != typeof(HRSupervisor))
                throw new MethodAccessException();

			var departments = _unitOfWork.Departments.GetAll();
            var departmentDTOs = new List<DepartmentDTO>();

            foreach (var department in departments)
            {
                departmentDTOs.Add(new DepartmentDTO
                {
                    DepartmentId = department.DepartmentId,
                    DepartmentName = department.Name.ToString(),
                    Description = department.Description
                });
            }

            return departmentDTOs;
        }

        public DepartmentDTO GetDepartmentById(int id)
        {
			var user = SecurityContext.GetUser();
			var userType = user.GetType();
			if (userType != typeof(Admin) && userType != typeof(HREmployee) && userType != typeof(HRSupervisor))
				throw new MethodAccessException();

			var department = _unitOfWork.Departments.Get(id);
            if (department == null) return null;

            return new DepartmentDTO
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.Name.ToString(),
                Description = department.Description
            };
        }
    }
}
