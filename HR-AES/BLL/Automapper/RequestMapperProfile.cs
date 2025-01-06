using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Automapper
{
	public class RequestMapperProfile : Profile
	{
        public RequestMapperProfile()
        {
			CreateMap<Request, RequestDTO>()
				.ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.RequestId))
				.ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
				.ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee != null ? (src.Employee.FirstName + " " + src.Employee.LastName) : string.Empty))
				.ForMember(dest => dest.RequestType, opt => opt.MapFrom(src => src.RequestType.ToString()))
				.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
				.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
				.ForMember(dest => dest.RequestDate, opt => opt.MapFrom(src => src.RequestDate))
				.ForMember(dest => dest.ApproveDate, opt => opt.MapFrom(src => src.Status == RequestStatus.Approved ? (DateTime?)DateTime.Now : null));

			CreateMap<RequestDTO, Request>()
				.ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.RequestId))
				.ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
				.ForMember(dest => dest.Employee, opt => opt.Ignore())
				.ForMember(dest => dest.RequestType, opt => opt.MapFrom(src => Enum.Parse<RequestType>(src.RequestType)))
				.ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<RequestStatus>(src.Status)))
				.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
				.ForMember(dest => dest.RequestDate, opt => opt.MapFrom(src => src.RequestDate));
		}
    }
}
