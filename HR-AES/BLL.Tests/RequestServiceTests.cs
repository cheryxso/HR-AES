using AutoMapper;
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
	public class RequestServiceTests
	{
		private readonly Mock<IUnitOfWork> _unitOfWorkMock;
		private readonly RequestService _requestService;

		public RequestServiceTests()
		{
			_unitOfWorkMock = new Mock<IUnitOfWork>();
			_requestService = new RequestService(_unitOfWorkMock.Object);

			SecurityContext.SetUser(new Admin(1, "Admin", 2));
		}

		[Fact]
		public void GetRequests_ShouldReturnRequestDTOs_IfUserAuthorized()
		{
			// Arrange
			var mockRequests = new List<Request>
			{
				new Request { RequestId = 1, Description = "Request 1", EmployeeId = 1 },
				new Request { RequestId = 2, Description = "Request 2", EmployeeId = 1 }
			};

			_unitOfWorkMock.Setup(u => u.Requests.GetAll()).Returns(mockRequests.AsQueryable());

			// Act
			var result = _requestService.GetRequests(1);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(2, result.Count());
			Assert.Collection(result,
				r =>
				{
					Assert.Equal(1, r.RequestId);
					Assert.Equal("Request 1", r.Description);
				},
				r =>
				{
					Assert.Equal(2, r.RequestId);
					Assert.Equal("Request 2", r.Description);
				});
		}

		[Fact]
		public void GetRequestById_ShouldReturnNull_IfRequestNotFound()
		{
			// Arrange
			_unitOfWorkMock.Setup(u => u.Requests.Get(It.IsAny<int>())).Returns((Request)null);

			// Act
			var result = _requestService.GetRequestById(1);

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public void GetRequestById_ShouldReturnRequestDTO_IfRequestExists()
		{
			// Arrange
			var mockRequest = new Request
			{
				RequestId = 1,
				Description = "Request 1",
				EmployeeId = 1
			};

			_unitOfWorkMock.Setup(u => u.Requests.Get(1)).Returns(mockRequest);

			// Act
			var result = _requestService.GetRequestById(1);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(1, result.RequestId);
			Assert.Equal("Request 1", result.Description);
		}
	}
}
