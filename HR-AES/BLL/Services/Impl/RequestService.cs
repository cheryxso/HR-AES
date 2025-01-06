using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security.Identity;
using CCL.Security;
using DAL.Entities;
using DAL.Repositories.UnitOfWork;
using BLL.Automapper;

namespace BLL.Services.Impl
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<RequestDTO> GetRequests(int employeeId)
        {
			var user = SecurityContext.GetUser();
			var userType = user.GetType();
			if (userType != typeof(Admin) && userType != typeof(HREmployee) && userType != typeof(HRSupervisor))
				throw new MethodAccessException();

			var requests = _unitOfWork.Requests.GetAll().Where(r => r.EmployeeId == employeeId).ToList();

			var mapperProfile = new RequestMapperProfile();
			var conf = new MapperConfiguration(cfg => cfg.AddProfile(mapperProfile));
			var mapper = new Mapper(conf);

			return mapper.Map<IEnumerable<Request>, List<RequestDTO>>(requests);
        }

        public RequestDTO GetRequestById(int id)
        {
			var user = SecurityContext.GetUser();
			var userType = user.GetType();
			if (userType != typeof(Admin) && userType != typeof(HREmployee) && userType != typeof(HRSupervisor))
				throw new MethodAccessException();

			var request = _unitOfWork.Requests.Get(id);

			var mapperProfile = new RequestMapperProfile();
			var conf = new MapperConfiguration(cfg => cfg.AddProfile(mapperProfile));
			var mapper = new Mapper(conf);

			return mapper.Map<Request, RequestDTO>(request);
        }
    }
}
