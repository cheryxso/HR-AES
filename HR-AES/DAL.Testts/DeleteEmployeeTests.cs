using Microsoft.EntityFrameworkCore;
using Moq;
using DAL.Entities;
using Xunit;
using System;
using DAL.Repositories.Impl;

namespace DAL.Testts
{
    public class DeleteEmployeeTests
    {
        [Fact]
        public void DeleteEmployee_CallsDbSetRemoveMethod()
        {
            // Arrange
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
            var mockDbSet = new Mock<DbSet<Employee>>();
            mockDbSet.Setup(m => m.Find(1)).Returns(testEmployee);

            var mockContext = new Mock<DbContext>();
            mockContext.Setup(m => m.Set<Employee>()).Returns(mockDbSet.Object);

            var repository = new EmployeeRepository(mockContext.Object);

            // Act
            repository.Delete(1);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Remove(testEmployee), Times.Once);
        }
    }
}
