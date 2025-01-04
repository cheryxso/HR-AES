using Microsoft.EntityFrameworkCore;
using Moq;
using DAL.Entities;
using Xunit;
using System;
using DAL.Repositories.Impl;

namespace DAL.Testts
{
    public class CreateEmployeeTests
    {
        [Fact]
        public void CreateEmployee_CallsDbSetAddMethod()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<Employee>>();
            var mockContext = new Mock<DbContext>();
            mockContext.Setup(m => m.Set<Employee>()).Returns(mockDbSet.Object);

            var repository = new EmployeeRepository(mockContext.Object);
            var testEmployee = new Employee
            {
                EmployeeId = 1,
                FirstName = "Katty",
                LastName = "Perry",
                Position = Position.Developer,
                HireDate = DateTime.Now,
                DepartmentId = 1,
                Department = new Department { DepartmentId = 1, Name = DepartmentName.IT },
                Requests = new List<Request>()
            };

            // Act
            repository.Create(testEmployee);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Add(testEmployee), Times.Once);
        }
    }
}
