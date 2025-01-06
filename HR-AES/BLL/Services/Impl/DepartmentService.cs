using System;
using System.Collections.Generic;
using BLL.DTO;
using DAL.Repositories.UnitOfWork;

namespace BLL.Services.Impl
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private int pageSize = 10;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<DepartmentDTO> GetDepartments(int page)
        {
            var departments = _unitOfWork.Departments.GetAll(page, pageSize);
            var departmentDTOs = new List<DepartmentDTO>();

            foreach (var department in departments)
            {
                departmentDTOs.Add(new DepartmentDTO
                {
                    DepartmentId = department.DepartmentId,
                    DepartmentName = department.DepartmentName,
                    Description = department.Description
                });
            }

            return departmentDTOs;
        }

        public DepartmentDTO GetDepartmentById(int id)
        {
            var department = _unitOfWork.Departments.GetById(id);
            if (department == null) return null;

            return new DepartmentDTO
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                Description = department.Description
            };
        }
    }
}
