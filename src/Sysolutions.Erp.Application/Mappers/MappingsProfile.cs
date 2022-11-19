using AutoMapper;
using Sysolutions.Erp.Application.Dtos;
using Sysolutions.Erp.Application.Services.Accounts.Commands.AddAccountCommand;
using Sysolutions.Erp.Application.Services.Accounts.Commands.AddTokenCommand;
using Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountByAll;
using Sysolutions.Erp.Application.Services.Customers.Commands.AddCustomerCommand;
using Sysolutions.Erp.Application.Services.Customers.Commands.UpdateCustomerCommand;
using Sysolutions.Erp.Domain.Entities;

namespace Sysolutions.Erp.Application.Mappers
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<GetAccountByAllResponse, Account>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap()
                .ForMember(destination => destination.Code, source => source.MapFrom(src => src.CustomerId));
            CreateMap<AccountDto, Account>().ReverseMap();

            CreateMap<AddAccountCommand, Account>().ReverseMap();
            CreateMap<AddTokenResponse, Account>().ReverseMap();
            

            CreateMap<AddCustomerCommand, Customer>().ReverseMap()
                .ForMember(destination => destination.Code, source => source.MapFrom(src => src.CustomerId));
            CreateMap<UpdateCustomerCommand, Customer>().ReverseMap()
                .ForMember(destination => destination.Code, source => source.MapFrom(src => src.CustomerId));
        }
    }
}