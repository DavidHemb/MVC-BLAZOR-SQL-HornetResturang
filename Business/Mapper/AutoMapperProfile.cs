using AutoMapper;
using DataAccess.Models;
using Hornet_Models.ModelsDTO;
using Microsoft.AspNetCore.Identity;

namespace Business.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<IdentityUser, EmployeeDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ReverseMap();

            CreateMap<IdentityUser, CustomerDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ReverseMap();

            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();

            CreateMap<OrderProduct, OrderProductDTO>();
            CreateMap<OrderProductDTO, OrderProduct>();

            CreateMap<CreateOrderDTO, Order>();
        }
    }
}
