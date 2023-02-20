using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using System;
using System.Collections.Generic;
namespace Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll
{
    public class GetProductByAllQuery : IRequest<Response<IEnumerable<GetProductByAllResponse>>>
    {
    }
}
