using Microsoft.EntityFrameworkCore;
using Moq;
using DAL.Entities;
using Xunit;
using System.Collections.Generic;
using DAL.Repositories.Impl;

namespace DAL.Testts
{
    public class CreateDepartmentTests
    {
        [Fact]
        public void CreateDepartment_CallsDbSetAddMethod()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<Department>>();
            var mockContext = new Mock<DbContext>();
            mockContext.Setup(m => m.Set<Department>()).Returns(mockDbSet.Object);

            var repository = new DepartmentRepository(mockContext.Object);
            var testDepartment = new Department
            {
                DepartmentId = 1,
                Name = DepartmentName.IT,
                Description = "Information Technology Department",
                Employees = new List<Employee>()
            };

            // Act
            repository.Create(testDepartment);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Add(testDepartment), Times.Once);
        }
    }
}

