using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Repositories.UnitOfWork;

namespace BLL.Services.Impl
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private int pageSize = 10;

        public RequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<RequestDTO> GetRequests(int employeeId, int page)
        {
            var requests = _unitOfWork.Requests.GetAllByEmployee(employeeId, page, pageSize);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Request, RequestDTO>())
                .CreateMapper();
            return mapper.Map<IEnumerable<Request>, List<RequestDTO>>(requests);
        }

        public RequestDTO GetRequestById(int id)
        {
            var request = _unitOfWork.Requests.GetById(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Request, RequestDTO>())
                .CreateMapper();
            return mapper.Map<Request, RequestDTO>(request);
        }
    }
}
