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
	public class EmployeeMapperProfile : Profile
	{
        public EmployeeMapperProfile()
        {
			CreateMap<Employee, EmployeeDTO>()
				.ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
				.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
				.ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.ToString()))
				.ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
				.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));

			CreateMap<EmployeeDTO, Employee>()
				.ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
				.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
				.ForMember(dest => dest.Position, opt => opt.MapFrom(src => Enum.Parse<Position>(src.Position)))
				.ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
				.ForMember(dest => dest.Department, opt => opt.Ignore())
				.ForMember(dest => dest.Requests, opt => opt.Ignore());
		}
    }
}
