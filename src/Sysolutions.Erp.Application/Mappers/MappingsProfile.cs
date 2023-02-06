using AutoMapper;
using Sysolutions.Erp.Application.Dtos;
using Sysolutions.Erp.Application.Services.Accounts.Commands.AddAccountCommand;
using Sysolutions.Erp.Application.Services.Accounts.Commands.AddTokenCommand;
using Sysolutions.Erp.Application.Services.Accounts.Commands.UpdateAccountCommand;
using Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountByAll;
using Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountById;
using Sysolutions.Erp.Application.Services.Brands.Commands;
using Sysolutions.Erp.Application.Services.Brands.Queries.GetBrandByAllQuery;
using Sysolutions.Erp.Application.Services.Categories.Commands;
using Sysolutions.Erp.Application.Services.Categories.Queries.GetCategoryByAll;
using Sysolutions.Erp.Application.Services.Customers.Commands.AddCustomerCommand;
using Sysolutions.Erp.Application.Services.Customers.Commands.UpdateCustomerCommand;
using Sysolutions.Erp.Application.Services.Measures.Commands.AddMeasureCommand;
using Sysolutions.Erp.Application.Services.Measures.Queries.GetMeasureByAll;
using Sysolutions.Erp.Application.Services.Products.Commands.AddProductCommand;
using Sysolutions.Erp.Application.Services.Products.Commands.DeleteProductCommand;
using Sysolutions.Erp.Application.Services.Products.Commands.UpdateProductCommand;
using Sysolutions.Erp.Application.Services.Products.Queries.GetPresentationsByProductId;
using Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll;
using Sysolutions.Erp.Application.Services.Products.Queries.GetProductByIdQuery;
using Sysolutions.Erp.Application.Services.Profiles.Queries.GetProfileByAll;
using Sysolutions.Erp.Application.Services.Sales.Commands.AddSalesOrderCommand;
using Sysolutions.Erp.Application.Services.Sales.Queries.GetSalesOrderByAllQuery;
using Sysolutions.Erp.Application.Services.Storages.Commands;
using Sysolutions.Erp.Application.Services.Storages.Queries.GetStorageByAllQuery;
using Sysolutions.Erp.Application.Services.Storages.Queries.GetStorageProductByStorageIdQuery;
using Sysolutions.Erp.Application.Services.SubCategories.Commands.AddSubCategoryCommand;
using Sysolutions.Erp.Application.Services.SubCategories.Queries.GetSubCategoryByAllQuery;
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
            CreateMap<GetProductPresentationByAllResponse, ProductPresentation>().ReverseMap();
            CreateMap<GetPresentationsByProductIdResponse, ProductPresentation>().ReverseMap();
            CreateMap<GetProdutPresentationByIdResponse, ProductPresentation>().ReverseMap();
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();

            CreateMap<Product, AddProductCommand>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();

            //Categories
            CreateMap<GetCategoryByAllResponse, Category>().ReverseMap();
            CreateMap<Category, AddCategoryCommand>().ReverseMap();

            //SubCategories
            CreateMap<GetSubCategoryByAllResponse, SubCategory>().ReverseMap();
            CreateMap<GetSubCategoryByCategoryIdResponse, SubCategory>().ReverseMap();
            CreateMap<SubCategory, AddSubCategoryCommand>().ReverseMap();

            //Measures
            CreateMap<GetMeasureByAllResponse, Measure>().ReverseMap();
            CreateMap<Measure, AddMeasureCommand>().ReverseMap();
            //Brands
            CreateMap<GetBrandByAllResponse, Brand>().ReverseMap();
            CreateMap<Brand, AddBrandCommand>().ReverseMap();

            //Storages
            CreateMap<GetStorageByAllResponse, Storage>().ReverseMap();
            CreateMap<Storage, AddStorageCommand>().ReverseMap();
            CreateMap<GetStorageProductByStorageIdResponse, StorageProduct>().ReverseMap();

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