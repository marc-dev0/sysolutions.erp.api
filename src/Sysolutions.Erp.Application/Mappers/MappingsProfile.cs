using AutoMapper;
using Sysolutions.Erp.Application.Dtos;
using Sysolutions.Erp.Application.Services.Accounts.Commands.AddAccountCommand;
using Sysolutions.Erp.Application.Services.Accounts.Commands.AddTokenCommand;
using Sysolutions.Erp.Application.Services.Accounts.Commands.UpdateAccountCommand;
using Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountByAll;
using Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountById;
using Sysolutions.Erp.Application.Services.Brands.Queries.GetBrandByAllQuery;
using Sysolutions.Erp.Application.Services.Categories.Queries.GetCategoryByAll;
using Sysolutions.Erp.Application.Services.Customers.Commands.AddCustomerCommand;
using Sysolutions.Erp.Application.Services.Customers.Commands.UpdateCustomerCommand;
using Sysolutions.Erp.Application.Services.Measures.Queries.GetMeasureByAll;
using Sysolutions.Erp.Application.Services.Products.Commands.AddProductCommand;
using Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll;
using Sysolutions.Erp.Application.Services.Profiles.Queries.GetProfileByAll;
using Sysolutions.Erp.Application.Services.Sales.Commands.AddSalesOrderCommand;
using Sysolutions.Erp.Application.Services.Sales.Queries.GetSalesOrderByAllQuery;
using Sysolutions.Erp.Application.Services.SubCategories.Queries.GetSubCategoryByCategoryId;
using Sysolutions.Erp.Domain.Entities;

namespace Sysolutions.Erp.Application.Mappers
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<GetAccountByAllResponse, Account>().ReverseMap();
            CreateMap<GetAccountByIdResponse, Account>().ReverseMap();
            CreateMap<Account, AddAccountCommand>().ReverseMap()
              .ForMember(destination => destination.State, source => source.MapFrom(src => src.StateCode));
            CreateMap<Account, UpdateAccountCommand>().ReverseMap()
              .ForMember(destination => destination.State, source => source.MapFrom(src => src.StateCode));
            CreateMap<AddTokenResponse, Account>().ReverseMap();
            CreateMap<AccountDto, Account>().ReverseMap();

            //Products
            CreateMap<GetProductByAllResponse, Product>().ReverseMap();
            CreateMap<Product, AddProductCommand>().ReverseMap();

            //Categories
            CreateMap<GetCategoryByAllResponse, Category>().ReverseMap();
            //SubCategories
            CreateMap<GetSubCategoryByCategoryIdResponse, SubCategory>().ReverseMap();
            //Measures
            CreateMap<GetMeasureByAllResponse, Measure>().ReverseMap();
            //Brands
            CreateMap<GetBrandByAllResponse, Brand>().ReverseMap();
            //Profiles
            CreateMap<GetProfileByAllResponse, Profiles>().ReverseMap();

            CreateMap<GetBaseSalesOrderByAllResponse, BaseSalesOrder>().ReverseMap();
            CreateMap<GetSalesOrderByAll, SalesOrder>().ReverseMap();
            CreateMap<GetSalesOrderDetailByAll, SalesOrderDetail>().ReverseMap();
            CreateMap<GetSalesOrderByAllQuery, SalesOrder>().ReverseMap();

            CreateMap<CustomerDto, Customer>().ReverseMap()
                .ForMember(destination => destination.Code, source => source.MapFrom(src => src.CustomerId));
            
            CreateMap<AddCustomerCommand, Customer>().ReverseMap()
                .ForMember(destination => destination.Code, source => source.MapFrom(src => src.CustomerId));
            CreateMap<UpdateCustomerCommand, Customer>().ReverseMap()
                .ForMember(destination => destination.Code, source => source.MapFrom(src => src.CustomerId));

            CreateMap<AddSalesOrderCommand, SalesOrder>().ReverseMap();
            CreateMap<AddSalesOrderDetailViewModel, SalesOrderDetail>().ReverseMap();
        }
    }
}