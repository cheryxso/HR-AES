using Xunit;
using System.Collections.Generic;
using BLL.DTO;
using BLL.Services.Impl;
using Moq;
using BLL.Services.Interfaces;

namespace BLL.Tests
{
    public class DepartmentServiceTests
    {
        private readonly Mock<IDepartmentService> _mockDepartmentService;

        public DepartmentServiceTests()
        {
            _mockDepartmentService = new Mock<IDepartmentService>();
        }

        [Fact]
        public void GetDepartments_ShouldReturnDepartmentsList()
        {
            // Arrange
            var mockDepartments = new List<DepartmentDTO>
            {
                new DepartmentDTO { DepartmentId = 1, DepartmentName = "HR", Description = "Human Resources" },
                new DepartmentDTO { DepartmentId = 2, DepartmentName = "IT", Description = "Information Technology" }
            };

            _mockDepartmentService.Setup(service => service.GetDepartments(It.IsAny<int>())).Returns(mockDepartments);
            var departmentService = _mockDepartmentService.Object;

            // Act
            var result = departmentService.GetDepartments(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
