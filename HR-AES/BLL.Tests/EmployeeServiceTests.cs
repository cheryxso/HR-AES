using AutoMapper;
using BLL.Services.Impl;
using CCL.Security.Identity;
using CCL.Security;
using DAL.Entities;
using DAL.Repositories.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
	public class EmployeeServiceTests
	{
		private readonly Mock<IUnitOfWork> _unitOfWorkMock;
		private readonly EmployeeService _employeeService;

		public EmployeeServiceTests()
		{
			_unitOfWorkMock = new Mock<IUnitOfWork>();
			_employeeService = new EmployeeService(_unitOfWorkMock.Object);

			SecurityContext.SetUser(new Admin(1, "Admin", 2));
		}

		[Fact]
		public void GetEmployees_ShouldReturnEmployeeDTOs_IfUserAuthorized()
		{
			// Arrange
			var mockEmployees = new List<Employee>
			{
				new Employee { EmployeeId = 1, FirstName = "FirstName1", LastName = "LastName1", Position = Position.Developer, DepartmentId = 1 },
				new Employee { EmployeeId = 2, FirstName = "FirstName2", LastName = "LastName2", Position = Position.Security_Manager, DepartmentId = 1 }
			};

			_unitOfWorkMock.Setup(u => u.Employees.GetAll()).Returns(mockEmployees.AsQueryable());

			// Act
			var result = _employeeService.GetEmployees(1);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(2, result.Count());
			Assert.Collection(result,
				e =>
				{
					Assert.Equal(1, e.EmployeeId);
					Assert.Equal("FirstName1", e.FirstName);
					Assert.Equal("LastName1", e.LastName);
					Assert.Equal("Developer", e.Position);
				},
				e =>
				{
					Assert.Equal(2, e.EmployeeId);
					Assert.Equal("FirstName2", e.FirstName);
					Assert.Equal("LastName2", e.LastName);
					Assert.Equal("Security_Manager", e.Position);
				});
		}

		[Fact]
		public void GetEmployeeById_ShouldReturnNull_IfEmployeeNotFound()
		{
			// Arrange
			_unitOfWorkMock.Setup(u => u.Employees.Get(It.IsAny<int>())).Returns((Employee)null);

			// Act
			var result = _employeeService.GetEmployeeById(1);

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public void GetEmployeeById_ShouldReturnEmployeeDTO_IfEmployeeExists()
		{
			// Arrange
			var mockEmployee = new Employee
			{
				EmployeeId = 1,
				FirstName = "FirstName",
				LastName = "LastName",
				Position = Position.Developer,
				DepartmentId = 1
			};

			_unitOfWorkMock.Setup(u => u.Employees.Get(1)).Returns(mockEmployee);

			// Act
			var result = _employeeService.GetEmployeeById(1);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(1, result.EmployeeId);
			Assert.Equal("FirstName", result.FirstName);
			Assert.Equal("LastName", result.LastName);
			Assert.Equal("Developer", result.Position);
		}
	}
}
