using BLL.Services.Impl;
using CCL.Security.Identity;
using CCL.Security;
using DAL.Repositories.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Tests
{
	public class DepartmentServiceTests
	{
		private readonly Mock<IUnitOfWork> _unitOfWorkMock;
		private readonly DepartmentService _departmentService;

		public DepartmentServiceTests()
		{
			_unitOfWorkMock = new Mock<IUnitOfWork>();
			_departmentService = new DepartmentService(_unitOfWorkMock.Object);

			SecurityContext.SetUser(new Admin(1, "Admin", 2));
		}

		[Fact]
		public void GetDepartments_ShouldReturnDepartmentDTOs_IfUserAuthorized()
		{
			// Arrange
			var mockDepartments = new List<Department>
			{
				new Department { DepartmentId = 1, Name = DepartmentName.HR, Description = "Human Resources" },
				new Department { DepartmentId = 2, Name = DepartmentName.IT, Description = "Information Technology" }
			};

			_unitOfWorkMock.Setup(u => u.Departments.GetAll()).Returns(mockDepartments);

			// Act
			var result = _departmentService.GetDepartments();

			// Assert
			Assert.NotNull(result);
			Assert.Equal(2, result.Count());
			Assert.Collection(result,
				d =>
				{
					Assert.Equal(1, d.DepartmentId);
					Assert.Equal("HR", d.DepartmentName);
					Assert.Equal("Human Resources", d.Description);
				},
				d =>
				{
					Assert.Equal(2, d.DepartmentId);
					Assert.Equal("IT", d.DepartmentName);
					Assert.Equal("Information Technology", d.Description);
				});
		}

		[Fact]
		public void GetDepartmentById_ShouldReturnNull_IfDepartmentNotFound()
		{
			// Arrange
			_unitOfWorkMock.Setup(u => u.Departments.Get(It.IsAny<int>())).Returns((Department)null);

			// Act
			var result = _departmentService.GetDepartmentById(1);

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public void GetDepartmentById_ShouldReturnDepartmentDTO_IfDepartmentExists()
		{
			// Arrange
			var mockDepartment = new Department
			{
				DepartmentId = 1,
				Name = DepartmentName.HR,
				Description = "Human Resources"
			};

			_unitOfWorkMock.Setup(u => u.Departments.Get(1)).Returns(mockDepartment);

			// Act
			var result = _departmentService.GetDepartmentById(1);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(1, result.DepartmentId);
			Assert.Equal("HR", result.DepartmentName);
			Assert.Equal("Human Resources", result.Description);
		}
	}
}
