using AutoMapper;
using Sysolutions.Security.Application.Dtos;
using Sysolutions.Security.Application.Services.Accounts.Commands.AddAccountCommand;
using Sysolutions.Security.Application.Services.Customers.Commands.AddCustomerCommand;
using Sysolutions.Security.Application.Services.Customers.Commands.UpdateCustomerCommand;
using Sysolutions.Security.Domain.Entities;

namespace Sysolutions.Security.Application.Mappers
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap()
                .ForMember(destination => destination.Code, source => source.MapFrom(src => src.CustomerId));
            CreateMap<AccountDto, Account>().ReverseMap();

            CreateMap<AddAccountCommand, Account>().ReverseMap();
            CreateMap<AddCustomerCommand, Customer>().ReverseMap()
                .ForMember(destination => destination.Code, source => source.MapFrom(src => src.CustomerId));
            CreateMap<UpdateCustomerCommand, Customer>().ReverseMap()
                .ForMember(destination => destination.Code, source => source.MapFrom(src => src.CustomerId));
        }
    }
}