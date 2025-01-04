using Microsoft.EntityFrameworkCore;
using Moq;
using DAL.Entities;
using Xunit;
using System.Collections.Generic;
using DAL.Repositories.Impl;

namespace DAL.Testts
{
    public class DeleteDepartmentTests
    {
        [Fact]
        public void DeleteDepartment_CallsDbSetRemoveMethod()
        {
            // Arrange
            var testDepartment = new Department
            {
                DepartmentId = 1,
                Name = DepartmentName.IT,
                Description = "Information Technology",
                Employees = new List<Employee>()
            };
            var mockDbSet = new Mock<DbSet<Department>>();
            mockDbSet.Setup(m => m.Find(1)).Returns(testDepartment);

            var mockContext = new Mock<DbContext>();
            mockContext.Setup(m => m.Set<Department>()).Returns(mockDbSet.Object);

            var repository = new DepartmentRepository(mockContext.Object);

            // Act
            repository.Delete(1);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Remove(testDepartment), Times.Once);
        }
    }
}

